using GeniePlugin.Interfaces;
using System.Text.RegularExpressions;
using System.Windows.Forms;

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

        public const string BalancePattern = "<h1 class=\"balance centered sans_serif\">You Have <span class=\"blue\">(\\d+)</span><img src=\"https://www.play.net/images/layout/store/icons/sc_icon_28_w.png\">!</h1>";
        public const string ClaimPattern = "<h1 class=\"RewardMessage centered sans_serif\">Subscription Reward: (\\d+) Free SimuCoins</h1>";
        public const string NamePattern = "<div\\s+class=\"login\\s+sans_serif\">\\s*(\\S+)\\s+|\\s+<a\\s+href=\"/Account/SignOut\">SIGN OUT</a>\\s*</div>";
        public const string TimePattern = "<h1 class=\"RewardMessage centered sans_serif\">(.*?)</h1>";

        private bool _enabled = true;

        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        public static IHost? Coin { get => coin; set => coin = value; }

        public string Name => "SimuCoins";

        public string Version => "2.0.4";

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

        public string? ParseInput(string text)
        {
            if (Regex.IsMatch(text, @"(^/sct|sctext|sc|scg|simucoins|scall|sca)(\shelp)$", RegexOptions.IgnoreCase))
            {
                Coin?.EchoText("\r\nUse the GUI to enter accounts that will be saved with successful logins.\r\nAll methods will claim coins if they are available.\r\nCommands for Simucoins:\r\n/sc or /simucoins will open the GUI.\r\n/sc or /simucoins <username> <password> logs in using the GUI.\r\n/sct or /sctext <username> <password> displays text version.\r\n/sca or /scall will display text and log into each account that is saved within the xml.\r\n");
                return "";
            }
            else if (Regex.IsMatch(text, @"^/sct($|\s)|^/sctext($|\s)", RegexOptions.IgnoreCase))
            {
                var arguments = text.Split(' ');
                if (arguments.Length == 3)
                    noForm?.NoGUILogin(arguments[1], arguments[2]);
                else
                    Coin?.EchoText("Usage: /sct <username> <password> or /sctext <username> <password>");
                return "";
            }
            else if (Regex.IsMatch(text, @"^/simucoins($|\s)|^/sc($|\s)", RegexOptions.IgnoreCase))
            {
                Show();
                var arguments = text.Split(' ');
                if (arguments.Length == 1) {}
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
                return "";
            }
            else if (Regex.IsMatch(text, @"^/scall($|\s)|^/sca($|\s)", RegexOptions.IgnoreCase))
            {
                noForm?.DoAll();
                return "";
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