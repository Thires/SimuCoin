using GeniePlugin.Interfaces;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace SimuCoin
{
    public partial class mainForm : Form
    {
        private CookieContainer cookies = new CookieContainer();

        public mainForm()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string url = "https://store.play.net/Account/SignIn?returnURL=%2FAccount%2FSignIn";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = cookies;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string pageContent = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    pageContent = reader.ReadToEnd();
                }
            }

            string token = Regex.Match(pageContent, "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(.*?)\" />").Groups[1].Value;

            string username = userNameTB.Text;
            string password = passwordTB.Text;

            string postData = string.Format("__RequestVerificationToken={0}&UserName={1}&Password={2}&RememberMe=true", token, username, password);

            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.CookieContainer = cookies;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;

            using (Stream stream = request.GetRequestStream())
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(postData);
                }
            }

            response = (HttpWebResponse)request.GetResponse();

            pageContent = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    pageContent = reader.ReadToEnd();
                }
            }

            if (response.ResponseUri.ToString() == "https://store.play.net/")
            {
                statusLabel.Text = "Login successful";
                UpdateBalance();
            }
            else
            {
                statusLabel.Text = "Login failed";
            }
        }

        private void UpdateBalance()
        {
            string url = "https://store.play.net/store/purchase/dr";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = cookies;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            string pageContent = string.Empty;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    pageContent = reader.ReadToEnd();
                }
            }


            string time = Regex.Match(pageContent, "<h1\\s+class=\"RewardMessage\\s+centered\\s+sans_serif\">Next Subscription Bonus in\\s+(.*?)</h1>").Groups[1].Value;
            timeLabel.Text = "Next Subscription Bonus in " + time;

            string balance = Regex.Match(pageContent, "<span class=\"blue\" id=\"side_balance\">(.*?)</span>").Groups[1].Value;
            currentCoinsLabel.Text = "You Have " + balance;

            string claim = Regex.Match(pageContent, "< h1 class=\"RewardMessage centered sans_serif\">Claimed (.*?) SimuCoin reward!</h1>").Groups[1].Value;
            claimButton.Visible = true;
            claimButton.Text = "Claim Reward!";
        }

        private void signoutButton_Click(object sender, EventArgs e)
        {
            string url = "https://store.play.net/Account/SignOut";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.CookieContainer = cookies;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            statusLabel.Text = "Signed out";
        }

        private void passwordTB_KeyDown(object sender, KeyEventArgs e)
        {
            var capsLockOn = Control.IsKeyLocked(Keys.CapsLock);
            statusLabel.Text = $"Caps Lock is {(capsLockOn ? "on" : "off")}.";
        }

        private void claimButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented");
        }
    }
}
