using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterSkyWinForms;

namespace ChromiumBrowserWinForms
{
    public partial class BrowserMenu : Form
    {
        Browser mainBrowser = null;
        public BrowserMenu(Browser tc)
        {
            InitializeComponent();
            InitializeBrowserMenu();
            this.mainBrowser = tc;
        }

        public void InitializeBrowserMenu()
        {
            MaximizeBox = false;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.BackColor = Color.FromArgb(0, 168, 242);
            this.BackgroundImage = Properties.Resources.Menu_Shape;
        }


        private void buttonSettings_Click(object sender, EventArgs e)
        {
            mainBrowser.OpenBrowserSettings();
        }

        private void buttonNewSession_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
