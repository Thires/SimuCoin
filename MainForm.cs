using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace SimuCoin
{
    public partial class MainForm : Form
    {
        // Create an HttpClient to handle HTTP requests and responses
        // Create a CookieContainer to store cookies
        private readonly HttpClient httpClient = new(new HttpClientHandler { CookieContainer = new CookieContainer() });

        // URLs and patterns used for scraping the SimuCoin balance and rewards
        private const string BalanceUrl = "https://store.play.net/store/purchase/dr";
        private const string TimePattern = "<h1\\s+class=\"RewardMessage\\s+centered\\s+sans_serif\">Next Subscription Bonus in\\s+(.*?)</h1>";
        private const string BalancePattern = "<span class=\"blue\" id=\"side_balance\">(.*?)</span>";
        private const string ClaimPattern = "<h1 class=\"RewardMessage centered sans_serif\">Subscription Reward: (\\d+) Free SimuCoins</h1>";

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

            xmlPath = Path.Combine(PluginInfo.Coin?.get_Variable("PluginPath") ?? "", "SimuCoin.xml");

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

            xmlDocument.Save(xmlPath);
            UserNameCB.Items.Clear();
            LoadXML();
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

        private async void Login()
        {
            string url = "https://store.play.net/Account/SignIn?returnURL=%2FAccount%2FSignIn"; // URL for the login page

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


            if (response.RequestMessage?.RequestUri?.ToString() == "https://store.play.net/") // Check if the login was successful
            {
                statusLabel.Text = "Login Successful";
                UpdateBalance();
                SaveXML();
                if (!UserNameCB.Items.Contains(UserNameCB.Text.ToUpper()))
                {
                    UserNameCB.Items.Add(UserNameCB.Text.ToUpper());
                }
            }
            else
            {
                statusLabel.Text = "Incorrect Username and/or Password";
            }
        }

        public void PluginInfoLogin()
        {
            Login();
        }

        private async void UpdateBalance() // Update the SimuCoin balance and claim any available rewards
        {
            try
            {
                var pageContent = await GetPageContent(BalanceUrl); // Get the balance page content
                UpdateTimeLabel(pageContent); // Update the time label with the next subscription bonus time
                UpdateBalanceLabel(pageContent); // Update the balance label with the current SimuCoin balance
                var claimAmount = GetClaimAmount(pageContent); // Get the claim amount, if available
                if (!string.IsNullOrEmpty(claimAmount))
                {
                    var success = await ClaimReward();
                    if (success)
                    {
                        statusLabel.Text = $"Claimed {claimAmount} SimuCoins";
                    }
                    else
                    {
                        statusLabel.Text = "Claim Failed";
                    }
                }
            }
            catch (Exception ex)
            {
                PluginInfo.Coin?.EchoText($"UpdateBalance: {ex.Message}");
            }
        }

        private async Task<string> GetPageContent(string url)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(10)); // timeout after 10 seconds
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            var response = await httpClient.SendAsync(request, cts.Token);
            return await response.Content.ReadAsStringAsync();
        }

        private void UpdateTimeLabel(string pageContent)
        {
            var time = Regex.Match(pageContent, TimePattern).Groups[1].Value;
            timeLeftLabel.Text = $"Next Subscription Bonus in {time}";
        }

        private void UpdateBalanceLabel(string pageContent)
        {
            var balance = Regex.Match(pageContent, BalancePattern).Groups[1].Value;
            currentCoinsLabel.Text = $"You Have {balance}";
            iconPictureBox.Visible = true;
            iconPictureBox.Image = SimuCoin.Properties.Resources.icon;
            iconPictureBox.Location = new Point(currentCoinsLabel.Right - 5, 30);
            exclamationLabel.Location = new System.Drawing.Point(iconPictureBox.Right - 5, 22);
            exclamationLabel.Visible = true;
        }

        private static string? GetClaimAmount(string pageContent)
        {
            var match = Regex.Match(pageContent, ClaimPattern);
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

                var response = await httpClient.PostAsync("https://store.play.net/Store/ClaimReward", formContent);

                if (response.IsSuccessStatusCode)
                {
                    var claimPageContent = await response.Content.ReadAsStringAsync();

                    var match = Regex.Match(claimPageContent, @"<h1 class=""RewardMessage centered sans_serif"">Claimed (\d+) SimuCoin reward!</h1>");
                    if (match.Success)
                    {
                        var claimAmount = match.Groups[1].Value;
                        statusLabel.Text = $"Claimed {claimAmount} SimuCoins";
                        UpdateBalanceLabel(claimPageContent);
                        return true;
                    }
                    else
                    {
                        statusLabel.Text = "Claim Failed";
                        return false;
                    }
                }
                else
                {
                    // handle error response
                    PluginInfo.Coin?.EchoText("Request failed with status code: " + response.StatusCode);
                    return false;
                }
            }
            catch (Exception ex)
            {
                PluginInfo.Coin?.EchoText($"ClaimReward: {ex.Message}");
                return false;
            }
        }

        // The signoutButton_Click event handler sends a GET request to the signout page to sign the user out. It then updates the user interface to show that the user is signed out.
        private async void SignoutButton_Click(object sender, EventArgs e)
        {
            string url = "https://store.play.net/Account/SignOut";
            try
            {
                using var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = new CookieContainer() });
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();

                timeLeftLabel.Text = "Next Subscription Bonus in";
                currentCoinsLabel.Text = "You Have";
                iconPictureBox.Visible = false;
                UserNameCB.Text = "";
                PasswordTB.Text = "";
                statusLabel.Text = "Signed Out";
                exclamationLabel.Visible = false;
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions that might occur
                PluginInfo.Coin?.EchoText($"SignoutButton_Click: {ex.Message}");
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Login();
        }

        // The passwordTB_KeyDown event handler checks if the Caps Lock key is on and updates the user interface accordingly. If the Enter key is pressed, it suppresses the key press and performs a click on the login button.
        private void PasswordTB_KeyDown(object sender, KeyEventArgs e)
        {
            var capsLockOn = Control.IsKeyLocked(Keys.CapsLock);
            statusLabel.Text = $"Caps Lock is {(capsLockOn ? "on" : "off")}.";

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginButton.PerformClick();
            }
        }

        // If the Enter key is pressed, it suppresses the key press and performs a click on the login button.
        private void UserNameCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                LoginButton.PerformClick();
            }
        }

        // If the Escape key is pressed, it will close the plugin.
        private async void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                isClosingDueToEscKey = true;

                string url = "https://store.play.net/Account/SignOut";

                try
                {
                    using var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = new CookieContainer() });
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    // Handle any exceptions that might occur
                    PluginInfo.Coin?.EchoText("-----------------------\n" + "SimuCoin Signout Failed\n" + "-----------------------\r\n");
                    PluginInfo.Coin?.EchoText($"MainForm_KeyDown: {ex.Message}");
                }
                this.Close();
            }
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isClosingDueToEscKey)
            {
                string url = "https://store.play.net/Account/SignOut";

                try
                {
                    using var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = new CookieContainer() });
                    var response = await httpClient.GetAsync(url);
                    response.EnsureSuccessStatusCode();
                }
                catch (HttpRequestException ex)
                {
                    // Handle any exceptions that might occur
                    PluginInfo.Coin?.EchoText("-----------------------\n" + "SimuCoin Signout Failed\n" + "-----------------------\r\n");
                    PluginInfo.Coin?.EchoText($"MainForm_FormClosinmg: {ex.Message}");
                }
            }
        }
    }
}
