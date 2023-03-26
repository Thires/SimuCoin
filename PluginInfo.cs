using GeniePlugin.Interfaces;

namespace SimuCoin
{
    public class PluginInfo : GeniePlugin.Interfaces.IPlugin
    {
        static void Main()
        {
        }

        private static IHost? coin;
        private MainForm? Frm;
        private NoGUI? nFrm;

        public void Initialize(IHost host)
        {
            Coin = host;
            nFrm = new NoGUI();
        }

        public void Show()
        {
            if (Frm == null || Frm.IsDisposed)
            {
                Frm = new MainForm();
            }
            Frm.Show();
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
            if (text.ToLower().StartsWith("/simucoin ") || text.ToLower().StartsWith("/sc "))
            {
                var arguments = text.Split(' ');
                if (arguments.Length == 3)
                {
                    Show();
                    if (Frm != null && arguments.Length == 3)
                    {
                        Frm.UserName = arguments[1];
                        Frm.Password = arguments[2];
                        Frm.PluginInfoLogin();
                    }
                }
                else
                {
                    // Invalid number of arguments
                    Coin?.EchoText("Invalid arguments. Usage: /simucoin or /sc <username> <password>");
                }
            }
            else if (text.ToLower().StartsWith("/scnf "))
            {
                var arguments = text.Split(' ');
                if (arguments.Length == 3)
                {
                    nFrm?.PluginNoFormLogin(arguments[1], arguments[2]);
                }
                else
                {
                    // Invalid number of arguments
                    Coin?.EchoText("Invalid arguments. Usage: /scnf <username> <password>");
                }
            }
            else if (text.ToLower().StartsWith("/simucoin") || text.ToLower().StartsWith("/sc"))
            {
                Show();
                return string.Empty;
            }
            return text;
        }

        public void ParseXML(string xml)
        {

        }

        public void ParentClosing()
        {

        }

        public string Name
        {
            get { return "SimuCoin"; }
        }

        public string Version
        {
            get { return "1.3"; }
        }

        public string Description
        {
            get { return "Log into SimuCoin store to check current coins, time left and claim coins"; }
        }

        public string Author
        {
            get { return "Thires"; }
        }

        private bool _enabled = true;

        public bool Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }
        public static IHost? Coin { get => coin; set => coin = value; }
    }
}