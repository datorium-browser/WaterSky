using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.WinForms;
using ChromiumBrowserWinForms;
using System.Net.NetworkInformation;

namespace WaterSkyWinForms
{
    public partial class Browser : Form
    {
        public ChromiumWebBrowser chromeBrowser = null;
        public TabPage settingsTab = null;
        Timer downloadsTimer = new Timer();
        Timer downloadCancelTimer = new Timer();
        TabPage tp = null;
        string waterskyHome = "watersky://home/";
        string pageNotFound = "watersky://Page_Not_Found/";
        string waterskyHistory = "watersky://history/";
        string workingDir;
        string projectDir;
        string resourcesDir;
        string addressbarPlaceholder = "Enter address or search for a keyword";
        public TableLayoutPanel downloadsTableLayoutPanel;
        private bool menuIsOpen { get; set; }
        BrowserMenu menu;
        DownloadHandler downloadHandler;
        RadioButton radioBtn;
        Button downloadsBtn;
       private Label downloadsLbl = new Label();
        List<RadioButton> radioButtons = new List<RadioButton>();
        //excluded .in domain, because it intefiers with some latvian sites
        string[] domains = { ".com", ".uk", ".de", ".ru", ".org", ".net", /*".in",*/ ".ir", ".br", ".au", ".eu", ".lv", ".lt", ".ee" }; // index: 13
        bool incognitoEnabled = false;

        public Browser()
        {
            BrowserMenu menu2 = new BrowserMenu(this);
            DownloadHandler downloadHndlr = new DownloadHandler(this);
            downloadHandler = downloadHndlr;
            menu = menu2;
            InitializeComponent();
            GetDirectory();
            InitializeChromium();
            InitializeTableLayoutPanel();
            InitializeMenuWindow();
            InitializeBrowserSettings();
            InitializeHandlers();
            InitializeDownloadsTimer();
            InitializeDownloadCancelTimer();
        }

        public void InitializeChromium()
        {
            if (!Cef.IsInitialized)
            {
                CefSettings settings = new CefSettings();
                // Initialize cef with the provided settings

                InitializeHomePage(settings);
                InitializePageNotFound(settings);
                InitializeHistory(settings);
                Cef.Initialize(settings);
            }

            // Create the first browser tab            
            BrowserTabs.TabPages.Clear();
            AddBrowserTab();
            menuIsOpen = false;
            BrowserTabs.SendToBack();
            this.MinimumSize = new Size(900, 800);
            AddressBar.Width = 450;
            DoubleBuffered = true;
            toolStrip1.SendToBack();
            this.CenterToScreen();
            AddDownloadsLabel();
            CreateDownloadsBtn();
        }

        private void GetDirectory()
        {
            // This will get the current WORKING directory (i.e. ...\bin\Debug)
            workingDir = Environment.CurrentDirectory;
            // This will get the current PROJECT directory
            projectDir = Directory.GetParent(workingDir).Parent.Parent.FullName;
            // This will get the Resources folder directory (i.e. ...\WaterSkyBrowser\Resources)
            resourcesDir = projectDir + @"\Resources";
        }

        private void InitializeHomePage(CefSettings settings)
        {
                settings.RegisterScheme(new CefCustomScheme
                {
                    SchemeName = "watersky",
                    DomainName = "home",
                    SchemeHandlerFactory = new FolderSchemeHandlerFactory(
           rootFolder: resourcesDir + @"\home-page",
           hostName: "home",
           defaultPage: "home-index.html" // will default to index.html
            )
                });
        }

        private void InitializePageNotFound(CefSettings settings)
        {
                        settings.RegisterScheme(new CefCustomScheme
                        {
                            SchemeName = "watersky",
                            DomainName = "Page_Not_Found",
                            SchemeHandlerFactory = new FolderSchemeHandlerFactory(
            rootFolder: resourcesDir + @"\webpage-timeout",
            hostName: "Page_Not_Found",
            defaultPage: "index.html" // will default to index.html
            )
                        });
        }

        private void InitializeHistory(CefSettings settings)
        {
                        settings.RegisterScheme(new CefCustomScheme
                        {
                            SchemeName = "watersky",
                            DomainName = "history",
                            SchemeHandlerFactory = new FolderSchemeHandlerFactory(
            rootFolder: resourcesDir + @"\history-page",
            hostName: "history",
            defaultPage: "index.html" // will default to index.html
            )
                        });
        }

        private void InitializeHandlers()
        {
            chromeBrowser.DownloadHandler = downloadHandler;
        }

        private void InitializeTableLayoutPanel()
        {
            downloadsTableLayoutPanel = new TableLayoutPanel();
            downloadsTableLayoutPanel.Dock = DockStyle.Bottom;
            downloadsTableLayoutPanel.Height = 50;
            downloadsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            downloadsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            this.downloadsTableLayoutPanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.None;
            this.Controls.Add(downloadsTableLayoutPanel);
            downloadsTableLayoutPanel.Controls.Add(downloadsLbl, 0, 0);
            downloadsTableLayoutPanel.Controls.Add(downloadsBtn, 1, 0);
            downloadsTableLayoutPanel.Visible = false;
        }

        private void InitializeDownloadsTimer()
        {
            downloadsTimer.Interval = 10;
            downloadsTimer.Tick += DownloadsTimer_Tick;

        }

        private void InitializeDownloadCancelTimer()
        {
            downloadCancelTimer.Interval = 10;
            downloadCancelTimer.Tick += DownloadCancelTimer_Tick;
            downloadCancelTimer.Start();
        }

        private void DownloadCancelTimer_Tick(object sender, EventArgs e)
        {
            if(downloadHandler.DownloadCancelled == true)
            {
                downloadsTableLayoutPanel.Visible = false;
                downloadsTimer.Stop();
            }
            if(downloadHandler.FileIsDownloading == true)
            {
                downloadsTimer.Start();
            }
        }

        private void DownloadsTimer_Tick(object sender, EventArgs e)
        {
            ShowDownloadsPanel();
        }

        private void ChromeBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {

            this.Invoke(new MethodInvoker(() =>
            {

                var selectedTabPage = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
                AddressBar.Text = e.Address;
                if(e.Address == waterskyHome || selectedTabPage.Text == "Home")
                {
                    AddressBar.Text = addressbarPlaceholder;
                    AddressBar.ForeColor = Color.Gray;
                }
                else
                {
                    AddressBar.ForeColor = Color.Black;
                }

            }));
        }

        private void ChromeBrowser_TitleChanged(object sender, TitleChangedEventArgs e)
        {
            try
            {
                var selectedBrowser = (ChromiumWebBrowser)sender;
                this.Invoke(new MethodInvoker(() =>
                {
                    selectedBrowser.Parent.Text = e.Title;
                }));
            }
            catch
            {
                
            }

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
                AddUrlToHistory(AddressBar.Text);
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

            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                selectedTabPage.Load(pageNotFound);
                return;
            }

            foreach (string dom in domains)
            {
                if (!url.Contains(dom))
                {
                    selectedTabPage.Load(pageNotFound);
                    continue;
                }
                continue;
            }

            foreach(string dom in domains)
            {
                if (url.Contains("www.") && url.Contains(dom))
                {
                    selectedTabPage.Load(url);
                    
                }
            }

            for(int i = 0; i < 13; i++)
            {
                if(radioButtons[0].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(google);
                }
            }

            for (int i = 0; i < 13; i++)
            {
                if (radioButtons[1].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(duckduckgo);
                }
            }

            for (int i = 0; i < 13; i++)
            {
                if (radioButtons[2].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(bing);
                }
            }

            for (int i = 0; i < 13; i++)
            {
                if (radioButtons[3].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {

                    selectedTabPage.Load(yahoo);
                }
            }

            for (int i = 0; i < 13; i++)
            {
                if (radioButtons[4].Checked && !url.Contains("http://") && !url.Contains("https://") && !url.Contains("www.") && !url.Contains(domains[i]))
                {
                    selectedTabPage.Load(qwant);
                }
            }
        }

        private void AddUrlToHistory( string url)
        {
            if (AddressBar.Text.Contains(waterskyHome) || AddressBar.Text.Contains(pageNotFound) || AddressBar.Text.Contains(waterskyHistory))
            {
                return;
            }
            if(incognitoEnabled == true)
            {
                return;
            }
            else if(incognitoEnabled == false)
            {
                using(StreamWriter fileOutput = new StreamWriter(Path.Combine(resourcesDir + @"\history-page", "index.html"), true))
                {
                    fileOutput.WriteLine($"<div class=cloud><span class=cloud-icon></span>{ DateTime.Now } { url }</div>");
                }
            }

        }

        public void LoadHomePage()
        {
            var selectedTabPage = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedTabPage.Load(waterskyHome);
            menu.Hide();
        }

        private void ButtonAddTab_Click(object sender, EventArgs e)
        {
            AddBrowserTab();
        }

        public void AddBrowserTab()
        {
            tp = new TabPage();
            tp.Text = "New Tab";
            BrowserTabs.TabPages.Add(tp);
            var browser = new ChromiumWebBrowser(waterskyHome);
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

        private void CreateDownloadsBtn()
        {
            downloadsBtn = new Button();
            downloadsBtn.Dock = DockStyle.Bottom;
            downloadsBtn.Height = 50;
            downloadsBtn.Font = new Font("Helvetica", 18);
            downloadsBtn.Text = "Open Folder";
            downloadsBtn.BringToFront();
            downloadsBtn.Click += DownloadsBtn_Click;
        }

        private void DownloadsBtn_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", "/select, " + downloadHandler.filePath);
            downloadsTableLayoutPanel.Visible = false;
            downloadsLbl.Text = "Your file is downloading, please wait...";
        }

        private void AddDownloadsLabel() 
        {
            downloadsLbl.Text = "Your file is downloading, please wait...";
            downloadsLbl.Font = new Font("Helvetica", 24);
            downloadsLbl.AutoSize = false;
            downloadsLbl.TextAlign = ContentAlignment.MiddleCenter;
            downloadsLbl.Dock = DockStyle.Bottom;
            downloadsLbl.Height = 50;
            downloadsLbl.BackColor = Color.Turquoise;
            downloadsLbl.ForeColor = Color.Black;
            downloadsLbl.BringToFront();
        }

        private void ShowDownloadsPanel()  
        {
            if(downloadHandler.DownloadCancelled == true)
            {
                downloadsTableLayoutPanel.Visible = false;
                downloadHandler.DownloadCancelled = false;
                downloadHandler.FileIsDownloading = false;
                downloadHandler.DownloadComplete = false;
                downloadsTimer.Stop();
            }
            if(downloadHandler.FileIsDownloading == true && downloadHandler.DownloadComplete == false)
            {
                downloadsTableLayoutPanel.Visible = true;
                downloadsBtn.Visible = false;
            }
            if(downloadHandler.DownloadComplete == true)
            {
                downloadsLbl.Text = "Download complete";
                downloadsBtn.Visible = true;
                downloadHandler.DownloadCancelled = false;
                downloadHandler.FileIsDownloading = false;
                downloadHandler.DownloadComplete = false;
                downloadsTimer.Stop();
            }
        }

        private void ButtonTabRemove_Click(object sender, EventArgs e)
        {
            var selectedTabPage = BrowserTabs.SelectedTab;

            if (BrowserTabs.TabPages.Count > 1)
            {
                BrowserTabs.TabPages.Remove(selectedTabPage);
                selectedTabPage = BrowserTabs.TabPages[BrowserTabs.TabPages.Count - 1];
                BrowserTabs.SelectTab(selectedTabPage);
                SyncAddressBarToUrl();
            }            
        }

        private void historyButton_Click(object sender, EventArgs e)
        {
            var selectedTabPage = (ChromiumWebBrowser)BrowserTabs.SelectedTab.Controls[0];
            selectedTabPage.Load(waterskyHistory);
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
            menu.Top = this.Top + 70;
            menu.Left = this.Left + (this.Width - 1460);
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

        private void SyncAddressBarToUrl()
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

        private void BrowserTabs_Click(object sender, EventArgs e)
        {
            SyncAddressBarToUrl();
        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            if(BrowserTabs.TabPages.Count > 1)
            {
                result = MessageBox.Show($"You are about to close {BrowserTabs.TabPages.Count} tabs. Are you sure you want to continue?","Close all tabs?", MessageBoxButtons.YesNo);

                if(result == DialogResult.Yes)
                {
                    
                }
                else if(result == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private int getHoverTabIndex(TabControl tc)
        {
            for (int i = 0; i < tc.TabPages.Count; i++)
            {
                if (tc.GetTabRect(i).Contains(tc.PointToClient(Cursor.Position)))
                    return i;
            }

            return -1;
        }

        private void swapTabPages(TabControl tc, TabPage src, TabPage dst)
        {
            int index_src = tc.TabPages.IndexOf(src);
            int index_dst = tc.TabPages.IndexOf(dst);
            tc.TabPages[index_dst] = src;
            tc.TabPages[index_src] = dst;
            tc.Refresh();
        }

        private void BrowserTabs_MouseDown(object sender, MouseEventArgs e)
        {
            // store clicked tab
            TabControl tc = (TabControl)sender;
            int hover_index = this.getHoverTabIndex(tc);
            if (hover_index >= 0) { tc.Tag = tc.TabPages[hover_index]; }
        }

        private void BrowserTabs_MouseUp(object sender, MouseEventArgs e)
        {
            // clear stored tab
            TabControl tc = (TabControl)sender;
            tc.Tag = null;
        }

        private void BrowserTabs_MouseMove(object sender, MouseEventArgs e) 
        {
            // mouse button down? tab was clicked?
            TabControl tc = (TabControl)sender;
            if ((e.Button != MouseButtons.Left) || (tc.Tag == null)) return;
            TabPage clickedTab = (TabPage)tc.Tag;
            int clicked_index = tc.TabPages.IndexOf(clickedTab);

            // start drag n drop
            tc.DoDragDrop(clickedTab, DragDropEffects.All);

            //Syncronise url to addressbar
            SyncAddressBarToUrl();
        }

        private void BrowserTabs_DragOver(object sender, DragEventArgs e)
        {
            TabControl tc = (TabControl)sender;

            // a tab is draged?
            if (e.Data.GetData(typeof(TabPage)) == null) return;
            TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
            int dragTab_index = tc.TabPages.IndexOf(dragTab);

            // hover over a tab?
            int hoverTab_index = this.getHoverTabIndex(tc);
            if (hoverTab_index < 0) { e.Effect = DragDropEffects.None; return; }
            TabPage hoverTab = tc.TabPages[hoverTab_index];
            e.Effect = DragDropEffects.Move;

            // start of drag?
            if (dragTab == hoverTab) return;

            // swap dragTab & hoverTab - avoids toggeling
            Rectangle dragTabRect = tc.GetTabRect(dragTab_index);
            Rectangle hoverTabRect = tc.GetTabRect(hoverTab_index);

            if (dragTabRect.Width < hoverTabRect.Width)
            {
                Point tcLocation = tc.PointToScreen(tc.Location);

                if (dragTab_index < hoverTab_index)
                {
                    if ((e.X - tcLocation.X) > ((hoverTabRect.X + hoverTabRect.Width) - dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
                else if (dragTab_index > hoverTab_index)
                {
                    if ((e.X - tcLocation.X) < (hoverTabRect.X + dragTabRect.Width))
                        this.swapTabPages(tc, dragTab, hoverTab);
                }
            }
            else this.swapTabPages(tc, dragTab, hoverTab);

            // select new pos of dragTab
            tc.SelectedIndex = tc.TabPages.IndexOf(dragTab);

            //Syncronise url to addressbar
            SyncAddressBarToUrl();
        }

        private void AddressBar_Enter(object sender, EventArgs e)
        {
            if (AddressBar.Text == addressbarPlaceholder)
            {
                AddressBar.Text = null;
                AddressBar.ForeColor = Color.Black;
            }
        }

        private void AddressBar_Leave(object sender, EventArgs e)
        {
            if (AddressBar.Text.Trim() == "")
            {
                AddressBar.Text = addressbarPlaceholder;
                AddressBar.ForeColor = Color.Gray;
            }
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            AddressBar.Text = addressbarPlaceholder;
        }

        private void incognitoButton_Click(object sender, EventArgs e)
        {
            if (incognitoEnabled == false)
            {
                incognitoEnabled = true;
                incognitoButton.BackColor = Color.Red;
            }
            else
            {
                incognitoEnabled = false;
                incognitoButton.BackColor = Color.Transparent;
            }
        }
    }
}
