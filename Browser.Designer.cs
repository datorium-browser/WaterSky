namespace WaterSkyWinForms
{
    partial class Browser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Browser));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonForward = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonReload = new System.Windows.Forms.ToolStripButton();
            this.ButtonGo = new System.Windows.Forms.ToolStripButton();
            this.AddressBar = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonAddTab = new System.Windows.Forms.ToolStripButton();
            this.ButtonTabRemove = new System.Windows.Forms.ToolStripButton();
            this.historyButton = new System.Windows.Forms.ToolStripButton();
            this.menuButton = new System.Windows.Forms.ToolStripButton();
            this.BrowserTabs = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.BrowserTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonBack,
            this.toolStripButtonForward,
            this.toolStripButtonReload,
            this.ButtonGo,
            this.AddressBar,
            this.ButtonAddTab,
            this.ButtonTabRemove,
            this.menuButton,
            this.historyButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 36);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonBack
            // 
            this.toolStripButtonBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonBack.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBack.Image")));
            this.toolStripButtonBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBack.Name = "toolStripButtonBack";
            this.toolStripButtonBack.Size = new System.Drawing.Size(36, 33);
            this.toolStripButtonBack.Text = "Back";
            this.toolStripButtonBack.Click += new System.EventHandler(this.toolStripButtonBack_Click);
            // 
            // toolStripButtonForward
            // 
            this.toolStripButtonForward.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonForward.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonForward.Image")));
            this.toolStripButtonForward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonForward.Name = "toolStripButtonForward";
            this.toolStripButtonForward.Size = new System.Drawing.Size(54, 33);
            this.toolStripButtonForward.Text = "Forward";
            this.toolStripButtonForward.Click += new System.EventHandler(this.toolStripButtonForward_Click);
            // 
            // toolStripButtonReload
            // 
            this.toolStripButtonReload.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonReload.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonReload.Image")));
            this.toolStripButtonReload.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonReload.Name = "toolStripButtonReload";
            this.toolStripButtonReload.Size = new System.Drawing.Size(47, 33);
            this.toolStripButtonReload.Text = "Reload";
            this.toolStripButtonReload.Click += new System.EventHandler(this.toolStripButtonReload_Click);
            // 
            // ButtonGo
            // 
            this.ButtonGo.BackColor = System.Drawing.Color.LavenderBlush;
            this.ButtonGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonGo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ButtonGo.Image = ((System.Drawing.Image)(resources.GetObject("ButtonGo.Image")));
            this.ButtonGo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonGo.Name = "ButtonGo";
            this.ButtonGo.Size = new System.Drawing.Size(36, 33);
            this.ButtonGo.Text = "Go";
            this.ButtonGo.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // AddressBar
            // 
            this.AddressBar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.AddressBar.Margin = new System.Windows.Forms.Padding(0);
            this.AddressBar.Name = "AddressBar";
            this.AddressBar.Size = new System.Drawing.Size(301, 36);
            this.AddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressBar_KeyDown);
            // 
            // ButtonAddTab
            // 
            this.ButtonAddTab.BackColor = System.Drawing.Color.PowderBlue;
            this.ButtonAddTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonAddTab.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ButtonAddTab.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddTab.Image")));
            this.ButtonAddTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAddTab.Name = "ButtonAddTab";
            this.ButtonAddTab.Size = new System.Drawing.Size(38, 33);
            this.ButtonAddTab.Text = "+";
            this.ButtonAddTab.Click += new System.EventHandler(this.ButtonAddTab_Click);
            // 
            // ButtonTabRemove
            // 
            this.ButtonTabRemove.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ButtonTabRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonTabRemove.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ButtonTabRemove.Image = ((System.Drawing.Image)(resources.GetObject("ButtonTabRemove.Image")));
            this.ButtonTabRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonTabRemove.Name = "ButtonTabRemove";
            this.ButtonTabRemove.Size = new System.Drawing.Size(29, 33);
            this.ButtonTabRemove.Text = "-";
            this.ButtonTabRemove.Click += new System.EventHandler(this.ButtonTabRemove_Click);
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.historyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.historyButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.historyButton.Image = ((System.Drawing.Image)(resources.GetObject("historyButton.Image")));
            this.historyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(59, 33);
            this.historyButton.Text = "History";
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuButton.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.menuButton.Image = ((System.Drawing.Image)(resources.GetObject("menuButton.Image")));
            this.menuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(46, 33);
            this.menuButton.Text = "Menu";
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // BrowserTabs
            // 
            this.BrowserTabs.Controls.Add(this.tabPage1);
            this.BrowserTabs.Controls.Add(this.tabPage2);
            this.BrowserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserTabs.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.BrowserTabs.Location = new System.Drawing.Point(0, 36);
            this.BrowserTabs.Margin = new System.Windows.Forms.Padding(2);
            this.BrowserTabs.Name = "BrowserTabs";
            this.BrowserTabs.SelectedIndex = 0;
            this.BrowserTabs.Size = new System.Drawing.Size(831, 510);
            this.BrowserTabs.TabIndex = 1;
            this.BrowserTabs.Click += new System.EventHandler(this.BrowserTabs_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(823, 484);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(823, 484);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 546);
            this.Controls.Add(this.BrowserTabs);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Browser";
            this.Text = "WaterSky";
            this.LocationChanged += new System.EventHandler(this.Browser_LocationChanged);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.BrowserTabs.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonGo;
        private System.Windows.Forms.ToolStripTextBox AddressBar;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton ButtonAddTab;
        private System.Windows.Forms.ToolStripButton ButtonTabRemove;
        private System.Windows.Forms.ToolStripButton historyButton;
        private System.Windows.Forms.ToolStripButton menuButton;
        public System.Windows.Forms.TabControl BrowserTabs;
        private System.Windows.Forms.ToolStripButton toolStripButtonBack;
        private System.Windows.Forms.ToolStripButton toolStripButtonForward;
        private System.Windows.Forms.ToolStripButton toolStripButtonReload;
    }
}

