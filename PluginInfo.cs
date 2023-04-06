using GeniePlugin.Interfaces;
using System.Text.RegularExpressions;

namespace SimuCoin
{
    public class PluginInfo : IPlugin
    {
        private static IHost? coin;
        private MainForm? form;
        private NoGUI? noFrom;

        private bool _enabled = true;

        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }

        public static IHost? Coin { get => coin; set => coin = value; }

        public string Name => "SimuCoin";

        public string Version => "1.8";

        public string Description => "Log into SimuCoin store to check current coins, time left and auto claim coins when available";

        public string Author => "Thires <Thiresdr@gmail.com>";

        public void Initialize(IHost host)
        {
            coin = host;
            noFrom = new NoGUI();
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
            if (Regex.IsMatch(text, @"^/scnf($|\s)|^/sct($|\s)", RegexOptions.IgnoreCase))
            {
                var arguments = text.Split(' ');
                if (arguments.Length == 3)
                {
                    noFrom?.PluginNoFormLogin(arguments[1], arguments[2]);
                }
                else
                {
                    Coin?.EchoText("Invalid arguments. Usage: /scnf <username> <password> or /sct <username> <password>");
                }
            }
            else if (Regex.IsMatch(text, @"^/simucoin($|\s)|^/sc($|\s)", RegexOptions.IgnoreCase))
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
                        form.PluginInfoLogin();
                    }
                }
                else
                {
                    Coin?.EchoText("Invalid arguments. Usage: /simucoin or /sc <username> <password>");
                }
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