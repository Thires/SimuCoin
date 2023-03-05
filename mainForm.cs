using GeniePlugin.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuCoin
{
    public partial class mainForm : Form
    {
        private readonly HttpClient httpClient = new HttpClient(new HttpClientHandler { CookieContainer = new CookieContainer() });
        private CookieContainer cookies = new CookieContainer();

        public mainForm()
        {
            InitializeComponent();
        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            string url = "https://store.play.net/Account/SignIn?returnURL=%2FAccount%2FSignIn";

            var response = await httpClient.GetAsync(url);
            var pageContent = await response.Content.ReadAsStringAsync();

            string token = Regex.Match(pageContent, "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(.*?)\" />").Groups[1].Value;

            string username = userNameTB.Text;
            string password = passwordTB.Text;

            string postData = $"__RequestVerificationToken={token}&UserName={username}&Password={password}&RememberMe=true";

            var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
            response = await httpClient.PostAsync(url, content);
            pageContent = await response.Content.ReadAsStringAsync();

            if (response.RequestMessage?.RequestUri?.ToString() == "https://store.play.net/")
            {
                statusLabel.Text = "Login successful";
                UpdateBalance();
            }
            else
            {
                statusLabel.Text = "Login failed";
            }
        }

        private async void UpdateBalance()
        {
            string url = "https://store.play.net/store/purchase/dr";

            var response = await httpClient.GetAsync(url);
            var pageContent = await response.Content.ReadAsStringAsync();

            string time = Regex.Match(pageContent, "<h1\\s+class=\"RewardMessage\\s+centered\\s+sans_serif\">Next Subscription Bonus in\\s+(.*?)</h1>").Groups[1].Value;
            timeLabel.Text = "Next Subscription Bonus in " + time;

            string balance = Regex.Match(pageContent, "<span class=\"blue\" id=\"side_balance\">(.*?)</span>").Groups[1].Value;
            currentCoinsLabel.Text = "You Have " + balance;
            iconPictureBox.Visible = true;
            iconPictureBox.Image = SimuCoin.Properties.Resources.sc_icon_28_w;
            iconPictureBox.Location = new Point(currentCoinsLabel.Right, currentCoinsLabel.Top);


            //string claimed = Regex.Match(pageContent, "< h1 class=\"RewardMessage centered sans_serif\">Claimed (.*?) SimuCoin reward!</h1>").Groups[1].Value;
            string claimAmount = Regex.Match(pageContent, "<h1 class=\"RewardMessage centered sans_serif\">Subscription Reward: (\\d+) Free SimuCoins</h1>").Groups[1].Value;
            claimButton.Visible = true;
            claimButton.Text = "Claim " + claimAmount;
        }

        private async void signoutButton_Click(object sender, EventArgs e)
        {
            string url = "https://store.play.net/Account/SignOut";

            using (var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = cookies }))
            {
                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    timeLabel.Text = "Next Subscription Bonus in";
                    currentCoinsLabel.Text = "You Have";
                    iconPictureBox.Visible = false;
                    statusLabel.Text = "Signed out";
                }
                else
                {
                    statusLabel.Text = "Signout failed";
                }
            }
        }

        private void passwordTB_KeyDown(object sender, KeyEventArgs e)
        {
            var capsLockOn = Control.IsKeyLocked(Keys.CapsLock);
            statusLabel.Text = $"Caps Lock is {(capsLockOn ? "on" : "off")}.";

            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loginButton.PerformClick();
            }
        }

        private void claimButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }
    }
}
