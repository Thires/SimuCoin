﻿using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace SimuCoin
{
    public class NoGUI : HttpClient, IDisposable
    {
        // Create an HttpClient to handle HTTP requests and responses
        // Create a CookieContainer to store cookies
        private static readonly HttpClientHandler httpClientHandler = new() { CookieContainer = new() };
        private readonly HttpClient httpClient = new(new HttpClientHandler { CookieContainer = new() });

        // URLs and patterns used for scraping the SimuCoin balance and rewards
        private const string BalanceUrl = "https://store.play.net/store/purchase/dr";
        private const string TimePattern = "<h1\\s+class=\"RewardMessage\\s+centered\\s+sans_serif\">Next Subscription Bonus in\\s+(.*?)</h1>";
        private const string BalancePattern = "<span class=\"blue\" id=\"side_balance\">(.*?)</span>";
        private const string ClaimPattern = "<h1 class=\"RewardMessage centered sans_serif\">Subscription Reward: (\\d+) Free SimuCoins</h1>";

        private bool disposed = false;

        protected override void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                httpClient.Dispose();
                httpClientHandler.Dispose();
            }

            disposed = true;

            base.Dispose(disposing);
        }

        public void PluginNoFormLogin(string username, string password)
        {
            Task.Run(async () => await Login(username, password));
        }

        private async Task Login(string username, string password)
        {
            try
            {
                string url = "https://store.play.net/Account/SignIn?returnURL=%2FAccount%2FSignIn"; // URL for the login page

                var response = await httpClient.GetAsync(url); // Send GET request to the login page
                var pageContent = await response.Content.ReadAsStringAsync(); // Read the response content as a string
                string token = Regex.Match(pageContent, "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(.*?)\" />").Groups[1].Value; // Extract the verification token from the page content

                string postData = $"__RequestVerificationToken={token}&UserName={username}&Password={password}&RememberMe=true"; // Create the POST data to send to the login page

                var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded"); // Create the content object to send with the POST request

                response = await httpClient.PostAsync(url, content); // Send POST request to the login page
                _ = await response.Content.ReadAsStringAsync(); // Read the response content as a string


                if (response.RequestMessage?.RequestUri?.ToString() == "https://store.play.net/") // Check if the login was successful
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

        }

        private async Task DisplayBalance()
        {
            try
            {
                var response = await httpClient.GetAsync(BalanceUrl);
                var pageContent = await response.Content.ReadAsStringAsync();

                Match match = Regex.Match(pageContent, @"<div\s+class=""login\s+sans_serif"">\s*(\S+)\s+\|\s+<a\s+href=""/Account/SignOut"">SIGN OUT</a>\s*</div>");
                PluginInfo.Coin?.EchoText("\r\nAccount: " + match.Groups[1].Value);
                var claimAmount = GetClaimAmount(pageContent);
                if (!string.IsNullOrEmpty(claimAmount))
                {
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
                PluginInfo.Coin?.EchoText($"UpdateBalance: {ex.Message}");
            }

            await SignOut();
        }


        private static void UpdateTime(string pageContent)
        {
            var time = Regex.Match(pageContent, TimePattern).Groups[1].Value;
            PluginInfo.Coin?.EchoText($"Next Subscription Bonus in {time}");
        }

        private static void UpdateBalance(string pageContent)
        {
            var balance = Regex.Match(pageContent, BalancePattern).Groups[1].Value;
            PluginInfo.Coin?.EchoText($"You Have {balance} SimuCoins!");
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
                        PluginInfo.Coin?.EchoText($"Claimed {claimAmount} SimuCoins");
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

        private static async Task SignOut()
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
                PluginInfo.Coin?.EchoText($"Signout: {ex.Message}");
            }
        }
    }
}