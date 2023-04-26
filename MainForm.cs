using System.Net;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace SimuCoins
{
    public partial class MainForm : Form
    {
        // Create an HttpClient to handle HTTP requests and responses
        // Create a CookieContainer to store cookies
        private readonly HttpClient httpClient = new(new HttpClientHandler { CookieContainer = new CookieContainer() });

        private bool isClosingDueToEscKey = false;

        private static string xmlPath = Application.StartupPath;

        public string UserName
        {
            get { return UserNameCB.Text; }
            set { UserNameCB.Text = value; }
        }

        public string Password
        {
            get { return PasswordTB.Text; }
            set { PasswordTB.Text = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            // Register the event handlers.
            KeyDown += MainForm_KeyDown;
            FormClosing += MainForm_FormClosing;
            FormClosed += MainForm_FormClosed;

            ClearBTN.GotFocus += Button_GotFocus;
            ClearBTN.LostFocus += Button_LostFocus;
            RemoveBTN.GotFocus += Button_GotFocus;
            RemoveBTN.LostFocus += Button_LostFocus;
            LoginBTN.GotFocus += Button_GotFocus;
            LoginBTN.LostFocus += Button_LostFocus;

            timeLBL.Text = "";
            coinsLBL.Text = "";
            tempLBL.Text = "";

            xmlPath = Path.Combine(PluginInfo.Coin?.get_Variable("PluginPath") ?? "", "SimuCoins.xml");

            if (File.Exists(xmlPath))
            {
                LoadXML();
            }
            else
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.AppendChild(xmlDocument.CreateElement("users"));
                xmlDocument.Save(xmlPath);
            }
        }

        private void SaveXML()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);

            var root = xmlDocument.DocumentElement ?? xmlDocument.CreateElement("users");
            xmlDocument.AppendChild(root);

            var userName = UserNameCB.Text;
            var password = PasswordTB.Text;

            // Encrypt the password
            string encryptedPassword = EncryptDecrypt.Encrypt(password);

            // Check if the username already exists in the XML file
            if (root.SelectSingleNode($"user[@username='{userName.ToUpper()}']") is XmlElement userNode)
            {
                // Replace the current password with the new generated password
                userNode.SetAttribute("password", encryptedPassword);
            }
            else
            {
                // Create a new user node
                userNode = xmlDocument.CreateElement("user");
                userNode.SetAttribute("username", userName.ToUpper());
                userNode.SetAttribute("password", encryptedPassword);
                root.AppendChild(userNode);

                // Add the username to the combo box
                UserNameCB.Items.Add(userName.ToUpper());
            }

            // Save the selected item before clearing the combobox
            var selectedItem = UserNameCB.SelectedItem;

            xmlDocument.Save(xmlPath);
            UserNameCB.Items.Clear();
            LoadXML();

            // Set the selected item again
            if (selectedItem != null && UserNameCB.Items.Contains(selectedItem))
            {
                UserNameCB.SelectedItem = selectedItem;
            }
        }

        private void LoadXML()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlPath);
            if (xmlDocument.DocumentElement != null)
            {
                foreach (var userName in from XmlNode node in xmlDocument.DocumentElement.ChildNodes
                                         let userName = node.Attributes?.GetNamedItem("username")?.Value
                                         let password = node.Attributes?.GetNamedItem("password")?.Value
                                         where !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password)
                                         select userName)
                {
                    // Add the username to the combo box
                    UserNameCB.Items.Add(userName.ToUpper());
                }
            }
        }

        private void UserNameCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = UserNameCB.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedItem))
            {
                // Load the password for the selected user from the XML file
                var xmlDocument = new XmlDocument();
                xmlDocument.Load(xmlPath);
                if (xmlDocument.DocumentElement != null)
                {
                    foreach (var password in from XmlNode node in xmlDocument.DocumentElement.ChildNodes
                                             let userName = node.Attributes?.GetNamedItem("username")?.Value
                                             let password = node.Attributes?.GetNamedItem("password")?.Value
                                             where userName == selectedItem && !string.IsNullOrEmpty(password)
                                             select password)
                    {
                        PasswordTB.Text = EncryptDecrypt.Decrypt(password);
                        break;
                    }
                }
            }
        }

        public void GUILogin()
        {
            Login();
        }

        private async void Login()
        {
            try
            {
                SuspendLayout();
                UserNameCB.Enabled = false;
                PasswordTB.Enabled = false;
                LoginBTN.Enabled = false;
                RemoveBTN.Enabled = false;
                ClearBTN.Enabled = false;

                string url = PluginInfo.LoginUrl; // URL for the login page

                var response = await httpClient.GetAsync(url); // Send GET request to the login page
                var pageContent = await response.Content.ReadAsStringAsync(); // Read the response content as a string
                string token = Regex.Match(pageContent, "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(.*?)\" />").Groups[1].Value; // Extract the verification token from the page content

                // Get the username and password from the text boxes
                string username = UserNameCB.Text.ToUpper();
                string password = PasswordTB.Text;

                string postData = $"__RequestVerificationToken={token}&UserName={username}&Password={password}&RememberMe=true"; // Create the POST data to send to the login page

                var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"); // Create the content object to send with the POST request
                response = await httpClient.PostAsync(url, content); // Send POST request to the login page
                _ = await response.Content.ReadAsStringAsync(); // Read the response content as a string

                if (response.RequestMessage?.RequestUri?.ToString() == PluginInfo.StoreUrl) // Check if the login was successful
                {
                    statusLBL.Text = "Login Successful";
                    await UpdateBalance();
                    SaveXML();
                    if (!UserNameCB.Items.Contains(UserNameCB.Text.ToUpper()))
                    {
                        UserNameCB.Items.Add(UserNameCB.Text.ToUpper());
                    }
                }
                else
                {
                    timeLBL.Text = "There is a problem with your account.";
                    tempLBL.Text = "Please contact customer service for assistance.";
                    statusLBL.Text = "Incorrect Username and/or Password";
                }
                UserNameCB.Enabled = true;
                UserNameCB.Focus();
                PasswordTB.Enabled = true;
                LoginBTN.Enabled = true;
                RemoveBTN.Enabled = true;
                ClearBTN.Enabled = true;
                ResumeLayout();
            }
            catch (HttpRequestException)
            {
                statusLBL.Text = "No Connection available";
            }
        }

        private async Task UpdateBalance() // Update the SimuCoins balance and claim any available rewards
        {
            try
            {
                var response = await httpClient.GetAsync(PluginInfo.BalanceUrl);
                var pageContent = await response.Content.ReadAsStringAsync();
                UpdateTimeLBL(pageContent); // Update the time label with the next subscription bonus time
                UpdateBalanceLBL(pageContent); // Update the balance label with the current SimuCoins balance
                var claimAmount = GetClaimAmount(pageContent); // Get the claim amount, if available
                if (!string.IsNullOrEmpty(claimAmount))
                {
                    await ClaimReward();
                }
            }
            catch (Exception ex)
            {
                PluginInfo.Coin?.EchoText($"UpdateBalance: {ex.Message}");
            }
            await SignOut();
        }

        private void UpdateTimeLBL(string pageContent)
        {
            var time = Regex.Match(pageContent, PluginInfo.TimePattern).Groups[1].Value;
            timeLBL.Text = time;
        }

        private void UpdateBalanceLBL(string pageContent)
        {
            this.SuspendLayout();
            var balance = Regex.Match(pageContent, PluginInfo.BalancePattern).Groups[1].Value;
            coinsLBL.Text = $"You Have {balance}";
            iconPIC.Visible = true;
            iconPIC.Image = Properties.Resources.icon;
            iconPIC.Location = new Point(coinsLBL.Right - 5, 30);
            exclamationLBL.Location = new Point(iconPIC.Right - 5, 22);
            exclamationLBL.Visible = true;
            this.ResumeLayout();
        }

        private static string? GetClaimAmount(string pageContent)
        {
            var match = Regex.Match(pageContent, PluginInfo.ClaimPattern);
            return match.Success ? match.Groups[1].Value : null;
        }

        private async Task<bool> ClaimReward()
        {
            try
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("game", "DR"),
                    new KeyValuePair<string, string>("filter", ""),
                    new KeyValuePair<string, string>("itemSearch", "")
                });

                var response = await httpClient.PostAsync(PluginInfo.ClaimUrl, formContent);

                if (response.IsSuccessStatusCode)
                {
                    var claimPageContent = await response.Content.ReadAsStringAsync();
                    var match = Regex.Match(claimPageContent, @"<h1 class=""RewardMessage centered sans_serif"">Claimed (\d+) SimuCoin reward!</h1>");
                    if (match.Success)
                    {
                        var claimAmount = match.Groups[1].Value;
                        timeLBL.Text = $"Subscription Reward: {claimAmount} Free SimuCoins";
                        statusLBL.Text = $"Claimed {claimAmount} SimuCoins";
                        UpdateBalanceLBL(claimPageContent);
                        return true;
                    }
                    else
                    {
                        statusLBL.Text = "Claim Failed";
                        return false;
                    }
                }
                else
                {
                    // handle error response
                    PluginInfo.Coin?.EchoText("Request failed: " + response.StatusCode);
                    return false;
                }
            }
            catch (Exception ex)
            {
                PluginInfo.Coin?.EchoText($"ClaimReward: {ex.Message}");
                return false;
            }
        }

        private static async Task SignOut()
        {
            string url = PluginInfo.SignOutUrl;

            try
            {
                using var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = new CookieContainer() });
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that might occur
                PluginInfo.Coin?.EchoText($"SignOut: {ex.Message}");
            }
        }


        private void Button_GotFocus(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = Color.LightBlue;
            }
        }

        private void Button_LostFocus(object? sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackColor = DefaultBackColor;
            }
        }

        // The ClearBTN_Click event handler clears the GUI.
        private void ClearBTN_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            UserNameCB.Enabled = false;
            PasswordTB.Enabled = false;
            LoginBTN.Enabled = false;
            RemoveBTN.Enabled = false;
            ClearBTN.Enabled = false;
            timeLBL.Text = "";
            coinsLBL.Text = "";
            tempLBL.Text = "";
            iconPIC.Visible = false;
            UserNameCB.Text = "";
            PasswordTB.Text = "";
            statusLBL.Text = "Cleared";
            exclamationLBL.Visible = false;

            UserNameCB.Enabled = true;
            UserNameCB.Focus();
            PasswordTB.Enabled = true;
            LoginBTN.Enabled = true;
            RemoveBTN.Enabled = true;
            ClearBTN.Enabled = true;
            this.ResumeLayout();
        }

        private void LoginBTN_Click(object sender, EventArgs e)
        {
            this.SuspendLayout();
            coinsLBL.Text = "";
            timeLBL.Text = "";
            tempLBL.Text = "";
            iconPIC.Visible = false;
            exclamationLBL.Visible = false;
            this.ResumeLayout();
            Login();
        }

        // The passwordTB_KeyDown event handler checks if the Caps Lock key is on and updates the user interface accordingly. If the Enter key is pressed, it suppresses the key press and performs a click on the login button.
        private void PasswordTB_KeyDown(object sender, KeyEventArgs e)
        {
            var capsLockOn = Control.IsKeyLocked(Keys.CapsLock);
            statusLBL.Text = $"Caps Lock is {(capsLockOn ? "on" : "off")}.";

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginBTN.PerformClick();
            }
        }

        // If the Enter key is pressed, it suppresses the key press and performs a click on the login button.
        private void UserNameCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginBTN.PerformClick();
            }

            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                e.SuppressKeyPress = true;

                var currentIndex = UserNameCB.SelectedIndex;
                var itemCount = UserNameCB.Items.Count;

                if (e.KeyCode == Keys.Up)
                {
                    currentIndex--;
                    if (currentIndex < 0)
                    {
                        currentIndex = itemCount - 1;
                    }
                }
                else if (e.KeyCode == Keys.Down)
                {
                    currentIndex++;
                    if (currentIndex >= itemCount)
                    {
                        currentIndex = 0;
                    }
                }
                UserNameCB.SelectedIndex = currentIndex;
            }
        }

        private void RemoveBTN_Click(object sender, EventArgs e)
        {
            // Get the selected user from the combo box
            var selectedUser = UserNameCB.SelectedItem?.ToString();

            UserNameCB.Enabled = false;
            PasswordTB.Enabled = false;
            LoginBTN.Enabled = false;
            RemoveBTN.Enabled = false;
            ClearBTN.Enabled = false;

            if (!string.IsNullOrEmpty(selectedUser))
            {
                // Ask the user to confirm the deletion
                var result = MessageBox.Show($"Are you sure you want to delete the user '{selectedUser}'?", "Confirm Deletion",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Load the XML document
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlPath);

                    // Find the XML node for the selected user
                    var userNode = xmlDocument.SelectSingleNode($"//user[@username='{selectedUser}']");

                    if (userNode != null)
                    {
                        UserNameCB.Text = "";
                        PasswordTB.Text = "";
                        statusLBL.Text = $"Removed: {selectedUser}";
                        // Remove the user node from the XML document
                        xmlDocument.DocumentElement?.RemoveChild(userNode);

                        // Save the updated XML file
                        xmlDocument.Save(xmlPath);

                        // Clear the combo box and reload the user list
                        UserNameCB.Items.Clear();
                        LoadXML();
                    }
                }
            }
            UserNameCB.Enabled = true;
            UserNameCB.Focus();
            PasswordTB.Enabled = true;
            LoginBTN.Enabled = true;
            RemoveBTN.Enabled = true;
            ClearBTN.Enabled = true;
        }

        // If the Escape key is pressed, it will close the plugin.
        private void MainForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                isClosingDueToEscKey = true;
                this.Close();
            }
        }

        private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (isClosingDueToEscKey)
            {
                // Unregister the event handlers before closing the form.
                this.KeyDown -= (s, ev) => MainForm_KeyDown(s, ev);
                this.FormClosing -= (s, ev) => MainForm_FormClosing(s, ev);
            }
            else
            {
                isClosingDueToEscKey = true;
                this.Close();
            }
        }

        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            // Unregister the event handlers after the form has closed.
            this.KeyDown -= (s, ev) => MainForm_KeyDown(s, ev);
            this.FormClosing -= (s, ev) => MainForm_FormClosing(s, ev);
            this.FormClosed -= (s, ev) => MainForm_FormClosed(s, ev);
        }
    }
}
