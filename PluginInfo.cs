using GeniePlugin.Interfaces;
using System.Net;
using System.Text.RegularExpressions;

namespace SimuCoins
{
    public class PluginInfo : IPlugin
    {
        private static IHost? coin;
        private MainForm? form;
        private NoGUI? noForm;

        private static readonly HttpClient httpClient = new();
        private static readonly HttpClientHandler httpClientHandler = new() { CookieContainer = new() };
        private static string _pagecontent = string.Empty;
        private static string _token = string.Empty;

        internal const string BalanceUrl = "https://store.play.net/store/purchase/dr";
        internal const string ClaimUrl = "https://store.play.net/Store/ClaimReward";
        internal const string LoginUrl = "https://store.play.net/Account/SignIn?returnURL=%2FAccount%2FSignIn";
        internal const string SignOutUrl = "https://store.play.net/Account/SignOut";
        internal const string StoreUrl = "https://store.play.net/";

        internal const string BalancePattern = "<h1 class=\"balance centered sans_serif\">You Have <span class=\"blue\">(\\d+)</span><img src=\"https://www.play.net/images/layout/store/icons/sc_icon_28_w.png\">!</h1>";
        internal const string ClaimPattern = "<h1 class=\"RewardMessage centered sans_serif\">Subscription Reward: (\\d+) Free SimuCoins</h1>";
        internal const string NamePattern = "<div\\s+class=\"login\\s+sans_serif\">\\s*(\\S+)\\s+|\\s+<a\\s+href=\"/Account/SignOut\">SIGN OUT</a>\\s*</div>";
        internal const string TimePattern = "<h1 class=\"RewardMessage centered sans_serif\">(.*?)</h1>";

        public bool Enabled { get; set; } = true;

        public static IHost? Coin { get => coin; set => coin = value; }

        public string Name => "SimuCoins";

        public string Version => "2.1.0";

        public string Description => "Log into SimuCoins store to check current coins, time left and auto claim coins when available";

        public string Author => "Thires <Thiresdr@gmail.com>";

        public async void Initialize(IHost host)
        {
            coin = host;
            noForm = new NoGUI();
            await InitializeAsync();
        }

        private static async Task InitializeAsync()
        {
            await LoadPage();
        }

        internal static string PageContent
        {
            get => _pagecontent;
            set => _pagecontent = value;
        }

        internal static string Token
        {
            get => _token;
            set => _token = value;
        }

        private async static Task LoadPage()
        {
            HttpResponseMessage response = await httpClient.GetAsync(LoginUrl);
            PageContent = await response.Content.ReadAsStringAsync();
            Token = Regex.Match(PageContent, "<input name=\"__RequestVerificationToken\" type=\"hidden\" value=\"(.*?)\" />").Groups[1].Value;
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
            if (Regex.IsMatch(text, @"^/(sct|sctext|sc|simucoins|scall|sca)(\shelp)$|^/simucoins($|\s)|^/sc($|\s)|^/sct($|\s)|^/sctext($|\s)|^/scall($|\s)|^/sca($|\s)", RegexOptions.IgnoreCase))
            {
                _ = ParseInputAsync(text);
                return "";
            }
            return text;
        }

        public async Task ParseInputAsync(string text)
        {
            if (Regex.IsMatch(text, @"^/(sct|sctext|sc|simucoins|scall|sca)(\shelp)$", RegexOptions.IgnoreCase))
            {
                Coin?.EchoText("\r\nUse the GUI to enter accounts that will be saved with successful logins.\r\nAll methods will claim coins if they are available.\r\nCommands for Simucoins:\r\n/sc or /simucoins will open the GUI.\r\n/sc or /simucoins <username> <password> logs in using the GUI.\r\n/sct or /sctext <username> <password> displays text version.\r\n/sca or /scall will display text and log into each account that is saved within the xml.\r\n\r\n#trigger {^Welcome to DragonRealms \\(\\w+\\) v\\d+\\.\\d+$} {#put /sca}\r\n#trigger save\r\n");
            }
            else if (Regex.IsMatch(text, @"^/sct($|\s)|^/sctext($|\s)", RegexOptions.IgnoreCase))
            {
                var arguments = text.Split(' ');
                if (arguments.Length == 3)
                    noForm?.NoGUILogin(arguments[1], arguments[2]);
                else
                    Coin?.EchoText("Usage: /sct <username> <password> or /sctext <username> <password>");
            }
            else if (Regex.IsMatch(text, @"^/simucoins($|\s)|^/sc($|\s)", RegexOptions.IgnoreCase))
            {
                Show();
                var arguments = text.Split(' ');
                if (arguments.Length == 1) { }
                else if (arguments.Length == 3)
                {
                    if (form != null)
                    {
                        form.UserName = arguments[1];
                        form.Password = arguments[2];
                        await form.GUILogin();
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
        }

        internal static async Task SignOut()
        {
            string url = PluginInfo.SignOutUrl;

            try
            {
                using var httpClient = new HttpClient(new HttpClientHandler { CookieContainer = new CookieContainer() });
                var response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                httpClient.Dispose();
                httpClientHandler.Dispose();
            }
            catch (HttpRequestException ex)
            {
                Coin?.EchoText($"SignOut: {ex.Message}");
            }
        }

        public void ParseXML(string xml)
        {
        }

        public void ParentClosing()
        {
        }
    }
}