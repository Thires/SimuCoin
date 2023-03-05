using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GeniePlugin.Interfaces;

namespace SimuCoin
{
    public class Plugin : GeniePlugin.Interfaces.IPlugin
    {
        static void Main(string[] args)
        {
        }

        public IHost? _host;
        private mainForm? Frm;

        public void Initialize(IHost host)
        {
            _host = host;
        }

        public void Show()
        {
            if (Frm == null || Frm.IsDisposed)
                Frm = new mainForm();

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
            get { return "Log into SimuCoin store to check current coins and time"; }
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