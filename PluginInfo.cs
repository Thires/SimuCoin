using GeniePlugin.Interfaces;

namespace SimuCoin
{
    public class PluginInfo : GeniePlugin.Interfaces.IPlugin
    {
        static void Main()
        {
        }

        public static IHost? _coin;
        private mainForm? Frm;

        public void Initialize(IHost host)
        {
            _coin = host;
        }

        public void Show()
        {
            if (Frm == null || Frm.IsDisposed)
            {
                Frm = new mainForm();
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
                    _coin?.EchoText("Invalid arguments. Usage: /simucoin or /sc <username> <password>");
                }
            }
            else
            {
                if (text.ToLower().StartsWith("/simucoin") || text.ToLower().StartsWith("/sc"))
                {
                    Show();
                    return string.Empty;
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

        public string Name
        {
            get { return "SimuCoin"; }
        }

        public string Version
        {
            get { return "1.0"; }
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
            get { return _enabled; }
            set { _enabled = value; }
        }


    }
}