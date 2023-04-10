﻿using GeniePlugin.Interfaces;
using System.Text.RegularExpressions;

namespace SimuCoins
{
    public class PluginInfo : IPlugin
    {
        private static IHost? coin;
        private MainForm? form;
        private NoGUI? noForm;

        public const string BalanceUrl = "https://store.play.net/store/purchase/dr";
        public const string ClaimUrl = "https://store.play.net/Store/ClaimReward";
        public const string LoginUrl = "https://store.play.net/Account/SignIn?returnURL=%2FAccount%2FSignIn";
        public const string SignOutUrl = "https://store.play.net/Account/SignOut";
        public const string StoreUrl = "https://store.play.net/";

        public const string BalancePattern = "<span class=\"blue\" id=\"side_balance\">(.*?)</span>";
        public const string ClaimPattern = "<h1 class=\"RewardMessage centered sans_serif\">Subscription Reward: (\\d+) Free SimuCoins</h1>";
        public const string NamePattern = @"<div\s+class=""login\s+sans_serif"">\s*(\S+)\s+\|\s+<a\s+href=""/Account/SignOut"">SIGN OUT</a>\s*</div>";
        public const string RewardPattern = @"<h1 class=""RewardMessage centered sans_serif"">Claimed (\d+) SimuCoins reward!</h1>";
        public const string TimePattern = "<h1\\s+class=\"RewardMessage\\s+centered\\s+sans_serif\">Next Subscription Bonus in\\s+(.*?)</h1>";

        private bool _enabled = true;

        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        public static IHost? Coin { get => coin; set => coin = value; }

        public string Name => "SimuCoins";

        public string Version => "2.0";

        public string Description => "Log into SimuCoins store to check current coins, time left and auto claim coins when available";

        public string Author => "Thires <Thiresdr@gmail.com>";

        public void Initialize(IHost host)
        {
            coin = host;
            noForm = new NoGUI();
        }

        public void Show()
        {
            if (form == null || form.IsDisposed)
            {
                form = new MainForm();
            }
            form.Show();
        }

        public void VariableChanged(string variable)
        {
        }

        public string ParseText(string text, string window)
        {
            return text;
        }

        public string ParseInput(string text)
        {
            if (Regex.IsMatch(text, @"^/sct($|\s)", RegexOptions.IgnoreCase))
            {
                var arguments = text.Split(' ');
                if (arguments.Length == 3)
                {
                    noForm?.NoGUILogin(arguments[1], arguments[2]);
                }
                else
                {
                    Coin?.EchoText("Usage: /sct <username> <password>");
                }
            }
            else if (Regex.IsMatch(text, @"^/simucoins($|\s)|^/sc($|\s)|^/scg($|\s)", RegexOptions.IgnoreCase))
            {
                Show();
                var arguments = text.Split(' ');
                if (arguments.Length == 1)
                {
                    return string.Empty;
                }
                else if (arguments.Length == 3)
                {
                    if (form != null)
                    {
                        form.UserName = arguments[1];
                        form.Password = arguments[2];
                        form.GUILogin();
                    }
                }
                else
                {
                    Coin?.EchoText("Usage: /simucoins or /sc <username> <password>");
                }
            }
            else if (Regex.IsMatch(text, @"^/scall($|\s)|^/sca($|\s)", RegexOptions.IgnoreCase))
            {
                noForm?.DoAll();
            }
            return text;
        }

        public void ParseXML(string xml)
        {
        }

        public void ParentClosing()
        {
        }
    }
}