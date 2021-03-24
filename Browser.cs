using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public TabPage settingsTab = null;
        TabPage tp = null;
        private string homeUrl = "https://datorium.eu";
        private bool menuIsOpen { get; set; }
        BrowserMenu menu;
        RadioButton radioBtn;
        DownloadHandler downloadHandler = new DownloadHandler();
        List<RadioButton> radioButtons = new List<RadioButton>();

        string[] domains = { ".com", ".uk", ".de", ".ru", ".org", ".net", ".in", ".ir", ".br", ".au", ".eu", ".lv", ".lt", ".ee" }; // index: 13

        public Browser()
        {
            BrowserMenu menu2 = new BrowserMenu(this);

            menu = menu2;
            InitializeComponent();
            InitializeChromium();
            InitializeMenuWindow();
            InitializeBrowserSettings();
            InitializeHandlers();
        }

        public void InitializeChromium()
        {
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                // Initialize cef with the provided settings
                Cef.Initialize(settings);
            }

            // Create the first browser tab            
            BrowserTabs.TabPages.Clear();
            AddBrowserTab();
            menuIsOpen = false;
            this.MinimumSize = new Size(800, 600);
            DoubleBuffered = true;
            this.CenterToScreen();
        }

        private void InitializeHandlers()
        {
            chromeBrowser.DownloadHandler = downloadHandler;
        }

        private void ChromeBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {

            this.Invoke(new MethodInvoker(() =>
            {
                AddressBar.Text = e.Address;
            }));
        }

        private void ChromeBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {

            var selectedBrowser = (ChromiumWebBrowser)sender;
            this.Invoke(new MethodInvoker(() =>
            {
                selectedBrowser.Parent.Text = e.Title;
            }));

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
            string google = $"https://www.google.com/search?q= {url}";
            string duckduckgo = $"https://duckduckgo.com?q= {url}";
            string bing = $"https://www.bing.com/search?q= {url}";
            string yahoo = $"https://search.yahoo.com/search?p= {url}";
            string qwant = $"https://www.qwant.com/?q= {url}";
            var selectedTabPage = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];

            for (int i = 0; i < 14; i++)
            {
                if (url.Contains("http://") || url.Contains("https://") || url.Contains("www.") || url.Contains(domains[i]))
                {
                    selectedTabPage.Load(url);
                }
            }

            for(int i = 0; i < 14; i++)
            {
                if(radioButtons[0].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(google);
                }
            }

            for (int i = 0; i < 14; i++)
            {
                if (radioButtons[1].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(duckduckgo);
                }
            }

            for (int i = 0; i < 14; i++)
            {
                if (radioButtons[2].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(bing);
                }
            }

            for (int i = 0; i < 14; i++)
            {
                if (radioButtons[3].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {

                    selectedTabPage.Load(yahoo);
                }
            }

            for (int i = 0; i < 14; i++)
            {
                if (radioButtons[4].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(qwant);
                }
            }

        }

        private void ButtonAddTab_Click(object sender, EventArgs e)
        {
            AddBrowserTab();
        }

        public void AddBrowserTab()
        {
            tp = new TabPage();
            tp.Text = "Skytab";
            BrowserTabs.TabPages.Add(tp);
            var browser = new ChromiumWebBrowser(homeUrl);
            tp.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;
            chromeBrowser = browser;
            chromeBrowser.TitleChanged += ChromeBrowser_TitleChanged;
            chromeBrowser.AddressChanged += ChromeBrowser_AddressChanged;
            BrowserTabs.SelectTab(tp);

        }

        private void InitializeBrowserSettings()
        {
            settingsTab = new TabPage();
            settingsTab.Text = "Settings";
            settingsTab.Paint += SettingsTab_Paint;
            AddHeaderLabel();
            AddRadioBtn();
            AddSearchEngineLabel();
        }

        public void OpenBrowserSettings()
        {
            BrowserTabs.TabPages.Add(settingsTab);
            BrowserTabs.SelectTab(settingsTab);
            menu.Hide();
        }

        private void SettingsTab_Paint(object sender, PaintEventArgs e)
        {
            SetSettingsBg(e);
            DrawHorLine(e);
        }

        private void SetSettingsBg(PaintEventArgs e)
        {
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                                                   //Original color: Color.FromArgb(59, 180, 228),
                                                   Color.FromArgb(17, 157, 218),
                                                   Color.White,
                                                   45F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void DrawHorLine(PaintEventArgs e)
        {
            var width = settingsTab.Width;

            Pen line = new Pen(Color.White, 3);

            PointF point1 = new PointF(15.0F, 100.0F);
            PointF point2 = new PointF(width - 15.0F, 100.0F);

            e.Graphics.DrawLine(line, point1, point2);
        }

        private void AddHeaderLabel()
        {
            Label lbl = new Label();
            lbl.Text = "Settings";
            lbl.Font = new Font("Helvetica", 24);
            lbl.AutoSize = false;
            lbl.Size = new Size(150, 100);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = Color.White;
            settingsTab.Controls.Add(lbl);

        }

        private void AddSearchEngineLabel()
        {
            Label lbl = new Label();
            lbl.Text = "Search engine";
            lbl.Font = new Font("Helvetica", 20);
            lbl.AutoSize = false;
            lbl.Size = new Size(200, 300);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.BackColor = Color.Transparent;
            lbl.ForeColor = Color.White;
            settingsTab.Controls.Add(lbl);

        }

        private void AddRadioBtn()
        {
            string[] searchEngines = { "Google", "DuckDuckGo", "Bing", "Yahoo", "Qwant"};
            int loc = 40;
            for(int i = 0; i < 5; i++)
            {
                radioBtn = new RadioButton();
                radioBtn.Name = "searchEngine" + i;
                radioBtn.Checked = false;
                radioBtn.Text = searchEngines[i];
                radioBtn.AutoSize = false;
                radioBtn.Size = new Size(180, 30);
                radioBtn.ForeColor = Color.White;
                radioBtn.BackColor = Color.Transparent;
                radioBtn.Font = new Font("Helvetica", 18);
                radioBtn.Location = new Point(20, 150 + loc);
                loc += 40;
                radioButtons.Add(radioBtn);
                settingsTab.Controls.Add(radioBtn);
            }
            radioButtons[1].Checked = true;
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
        private void toolStripButtonBack_Click(object sender, EventArgs e)
        {
            chromeBrowser.Back();
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            chromeBrowser.Forward();
        }

        private void toolStripButtonReload_Click(object sender, EventArgs e)
        {
            chromeBrowser.Reload();
        }

        private void BrowserTabs_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedBrowser = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];

                this.Invoke(new MethodInvoker(() =>
                {
                    AddressBar.Text = selectedBrowser.Address;
                }));
            }
            catch
            {

            }

        }

    }
}
