using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using ChromiumBrowserWinForms;

namespace WaterSkyWinForms
{
    public partial class Browser : Form
    {
        public ChromiumWebBrowser chromeBrowser = null;
        private string homeUrl = "https://datorium.eu";
        private bool menuIsOpen { get; set; }
        BrowserMenu menu = new BrowserMenu();

        public Browser()
        {
            InitializeComponent();
            InitializeChromium();
            InitializeMenuWindow();
        }

        public void InitializeChromium()
        {
            CefSettings settings = new CefSettings();
            // Initialize cef with the provided settings
            Cef.Initialize(settings);
            // Create the first browser tab            
            BrowserTabs.TabPages.Clear();
            AddBrowserTab();
            menuIsOpen = false;
        }

        private void InitializeMenuWindow()
        {
            menu.InitializeBrowserMenu();
            menu.Height = 500;
            menu.Width = 500;
        }

        private void ButtonGo_Click(object sender, EventArgs e)
        {
            Navigate();
        }

        private void AddressBar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                Navigate();
            }
        }

        private void Navigate()
        {
            string url = AddressBar.Text;

            if (url.Contains("http://") || url.Contains("https://") || url.Contains("www."))
            {
                chromeBrowser.Load(url);
            }
            else
            {
                chromeBrowser.Load($"https://duckduckgo.com?q= {url}");
            }            
        }

        private void ButtonAddTab_Click(object sender, EventArgs e)
        {
            AddBrowserTab();
        }

        private void AddBrowserTab()
        {
            var tp = new TabPage();
            tp.Text = "Tab";
            BrowserTabs.TabPages.Add(tp);
            var browser = new ChromiumWebBrowser(homeUrl);
            tp.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            
            chromeBrowser = browser;
            BrowserTabs.SelectTab(tp);
        }

        private void BrowserTabs_Selected(object sender, TabControlEventArgs e)
        {
            chromeBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
        }

        private void ButtonTabRemove_Click(object sender, EventArgs e)
        {
            var tp = BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 1];
            
            if(BrowserTabs.TabPages.Count > 1)
            {
                BrowserTabs.TabPages.Remove(tp);
                tp = BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 1];
                BrowserTabs.SelectTab(tp);
            }            
        }

        private void historyButton_Click(object sender, EventArgs e)
        {

        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            OpenMenu();
        }

        private void OpenMenu()
        {
            if (!menuIsOpen)
            {
                menu.Show();
                menuIsOpen = false;
            }
            else
            {
                menu.Hide();
                menuIsOpen = true;
            }
            menuIsOpen = !menuIsOpen;
        }

        private void Browser_LocationChanged(object sender, EventArgs e)
        {
            ChangeMenuLocation();
        }

        private void ChangeMenuLocation()
        {
            menu.Top = this.Top + 60;
            menu.Left = this.Left + (this.Width - 605);
        }

    }
}
