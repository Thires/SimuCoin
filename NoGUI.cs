using System.Net;
using System.Text.RegularExpressions;
using System.Xml;

namespace SimuCoins
{
    public class NoGUI : HttpClient, IDisposable
    {
        // Create an HttpClient to handle HTTP requests and responses
        private readonly HttpClient httpClient = new(new HttpClientHandler { CookieContainer = new() });

        private static bool noShowEcho = false;

        public NoGUI()
        {
            httpClient.Timeout = TimeSpan.FromSeconds(30);
        }

        private static List<(string, string)> LoadXML()
        {
            var users = new List<(string, string)>();

            string pluginPath = PluginInfo.Coin?.get_Variable("PluginPath") ?? string.Empty;
            if (!string.IsNullOrEmpty(pluginPath))
            {
                string xmlPath = Path.Combine(pluginPath, "SimuCoins.xml");

                if (File.Exists(xmlPath))
                {
                    var xmlDocument = new XmlDocument();
                    xmlDocument.Load(xmlPath);

                    var userNodes = xmlDocument.SelectNodes("//user");
                    if (userNodes != null)
                    {
                        foreach (XmlNode userNode in userNodes)
                        {
                            string? username = userNode.Attributes?["username"]?.Value;
                            string? password = userNode.Attributes?["password"]?.Value;

                            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                            {
                                users.Add((username, password));
                            }
                        }
                    }
                }
            }
            return users;
        }

        internal async Task DoAll()
        {
            noShowEcho = true;
            var users = LoadXML();
            PluginInfo.Coin?.EchoText("\r\nChecking Account(s)...\r\n");
            foreach (var (username, password) in users)
            {
                await Login(username, EncryptDecrypt.Decrypt(password));
            }
            PluginInfo.Coin?.EchoText("Account(s) Checked...\r\n");
        }

        internal void NoGUILogin(string username, string password)
        {
            noShowEcho = false;
            Task.Run(async () => await Login(username, password));
        }

        private async Task<bool> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            try
            {
                string url = PluginInfo.LoginUrl; // URL for the login page

                var response = await httpClient.GetAsync(url); // Send GET request to the login page
                string token = PluginInfo.Token; // Extract the verification token from the page content

                var content = new FormUrlEncodedContent(new Dictionary<string, string>  // Create the content object to send with the POST request
                {
                    { "__RequestVerificationToken", token },
                    { "UserName", username },
                    { "Password", password },
                    { "RememberMe", "true" }
                });

                response = await httpClient.PostAsync(url, content); // Send POST request to the login page
                _ = await response.Content.ReadAsStringAsync(); // Read the response content as a string


                if (response.RequestMessage?.RequestUri?.ToString() == PluginInfo.StoreUrl) // Check if the login was successful
                {
                    await DisplayBalance();
                }
                else
                {
                    PluginInfo.Coin?.EchoText("\r\nIncorrect Username and/or Password\r\n");
                }
            }
            catch (HttpRequestException)
            {
                PluginInfo.Coin?.EchoText("No Connection available");
            }
            return true;
        }

        private async Task DisplayBalance()
        {
            try
            {
                var response = await httpClient.GetAsync(PluginInfo.BalanceUrl);
                var pageContent = await response.Content.ReadAsStringAsync();

                Match match = Regex.Match(pageContent, PluginInfo.NamePattern);
                if (!noShowEcho)
                    PluginInfo.Coin?.EchoText("\n\rAccount: " + match.Groups[1].Value);
                var claimAmount = GetClaimAmount(pageContent);
                if (!string.IsNullOrEmpty(claimAmount))
                {
                    if (noShowEcho)
                        PluginInfo.Coin?.EchoText("Account: " + match.Groups[1].Value);
                    UpdateBalance(pageContent);
                    await ClaimReward();
                }
                else
                {
                    UpdateTime(pageContent);
                    UpdateBalance(pageContent);
                }
            }
            catch (Exception ex)
            {
                PluginInfo.Coin?.EchoText($"DisplayBalance: {ex.Message}");
            }
            await PluginInfo.SignOut();
        }

        private static void UpdateTime(string pageContent)
        {
            var time = Regex.Match(pageContent, PluginInfo.TimePattern).Groups[1].Value;
            if (!noShowEcho)
                PluginInfo.Coin?.EchoText(time);
        }

        private static void UpdateBalance(string pageContent)
        {
            var balance = Regex.Match(pageContent, PluginInfo.BalancePattern).Groups[1].Value;
            if (!noShowEcho)
                PluginInfo.Coin?.EchoText($"You Have {balance} SimuCoins!\r\n");
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
                        PluginInfo.Coin?.EchoText($"Claimed {claimAmount} SimuCoins\r\n");
                        UpdateBalance(claimPageContent);
                        return true;
                    }
                    else
                    {
                        PluginInfo.Coin?.EchoText("Claim Failed");
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
    }
}