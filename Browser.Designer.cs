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
            this.ButtonGo = new System.Windows.Forms.ToolStripButton();
            this.AddressBar = new System.Windows.Forms.ToolStripTextBox();
            this.ButtonAddTab = new System.Windows.Forms.ToolStripButton();
            this.ButtonTabRemove = new System.Windows.Forms.ToolStripButton();
            this.menuButton = new System.Windows.Forms.ToolStripButton();
            this.historyButton = new System.Windows.Forms.ToolStripButton();
            this.BrowserTabs = new System.Windows.Forms.TabControl();
            this.Skytab1 = new System.Windows.Forms.TabPage();
            this.Skytab2 = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.BrowserTabs.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.PaleTurquoise;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonGo,
            this.AddressBar,
            this.ButtonAddTab,
            this.ButtonTabRemove,
            this.menuButton,
            this.historyButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(831, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonGo
            // 
            this.ButtonGo.BackColor = System.Drawing.Color.LavenderBlush;
            this.ButtonGo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonGo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonGo.Image = ((System.Drawing.Image)(resources.GetObject("ButtonGo.Image")));
            this.ButtonGo.ImageTransparentColor = System.Drawing.Color.White;
            this.ButtonGo.Name = "ButtonGo";
            this.ButtonGo.Size = new System.Drawing.Size(36, 36);
            this.ButtonGo.Text = "Go";
            this.ButtonGo.Click += new System.EventHandler(this.ButtonGo_Click);
            // 
            // AddressBar
            // 
            this.AddressBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddressBar.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBar.Margin = new System.Windows.Forms.Padding(0);
            this.AddressBar.Name = "AddressBar";
            this.AddressBar.Size = new System.Drawing.Size(301, 39);
            this.AddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressBar_KeyDown);
            // 
            // ButtonAddTab
            // 
            this.ButtonAddTab.BackColor = System.Drawing.Color.PowderBlue;
            this.ButtonAddTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonAddTab.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddTab.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddTab.Image")));
            this.ButtonAddTab.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ButtonAddTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAddTab.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.ButtonAddTab.Name = "ButtonAddTab";
            this.ButtonAddTab.RightToLeftAutoMirrorImage = true;
            this.ButtonAddTab.Size = new System.Drawing.Size(34, 36);
            this.ButtonAddTab.Text = "+";
            this.ButtonAddTab.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.ButtonAddTab.Click += new System.EventHandler(this.ButtonAddTab_Click);
            // 
            // ButtonTabRemove
            // 
            this.ButtonTabRemove.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ButtonTabRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ButtonTabRemove.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonTabRemove.Image = ((System.Drawing.Image)(resources.GetObject("ButtonTabRemove.Image")));
            this.ButtonTabRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonTabRemove.Name = "ButtonTabRemove";
            this.ButtonTabRemove.Size = new System.Drawing.Size(32, 36);
            this.ButtonTabRemove.Text = "-";
            this.ButtonTabRemove.Click += new System.EventHandler(this.ButtonTabRemove_Click);
            // 
            // menuButton
            // 
            this.menuButton.BackColor = System.Drawing.Color.CornflowerBlue;
            this.menuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuButton.Image = global::ChromiumBrowserWinForms.Properties.Resources.Menu_Shape;
            this.menuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(51, 36);
            this.menuButton.Text = "Menu";
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.LightSteelBlue;
            this.historyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.historyButton.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyButton.Image = ((System.Drawing.Image)(resources.GetObject("historyButton.Image")));
            this.historyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(65, 36);
            this.historyButton.Text = "History";
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // BrowserTabs
            // 
            this.BrowserTabs.Controls.Add(this.Skytab1);
            this.BrowserTabs.Controls.Add(this.Skytab2);
            this.BrowserTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowserTabs.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowserTabs.ItemSize = new System.Drawing.Size(150, 25);
            this.BrowserTabs.Location = new System.Drawing.Point(0, 39);
            this.BrowserTabs.Margin = new System.Windows.Forms.Padding(2);
            this.BrowserTabs.Name = "BrowserTabs";
            this.BrowserTabs.SelectedIndex = 0;
            this.BrowserTabs.ShowToolTips = true;
            this.BrowserTabs.Size = new System.Drawing.Size(831, 507);
            this.BrowserTabs.TabIndex = 1;
            this.BrowserTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.BrowserTabs_Selected);
            // 
            // Skytab1
            // 
            this.Skytab1.AutoScroll = true;
            this.Skytab1.Location = new System.Drawing.Point(4, 29);
            this.Skytab1.Margin = new System.Windows.Forms.Padding(2);
            this.Skytab1.Name = "Skytab1";
            this.Skytab1.Padding = new System.Windows.Forms.Padding(2);
            this.Skytab1.Size = new System.Drawing.Size(823, 474);
            this.Skytab1.TabIndex = 0;
            this.Skytab1.Text = "Skytab";
            this.Skytab1.UseVisualStyleBackColor = true;
            // 
            // Skytab2
            // 
            this.Skytab2.Location = new System.Drawing.Point(4, 29);
            this.Skytab2.Margin = new System.Windows.Forms.Padding(0);
            this.Skytab2.Name = "Skytab2";
            this.Skytab2.Padding = new System.Windows.Forms.Padding(2);
            this.Skytab2.Size = new System.Drawing.Size(823, 474);
            this.Skytab2.TabIndex = 1;
            this.Skytab2.Text = "Skytab";
            this.Skytab2.UseVisualStyleBackColor = true;
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
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
        private System.Windows.Forms.TabControl BrowserTabs;
        private System.Windows.Forms.TabPage Skytab1;
        private System.Windows.Forms.TabPage Skytab2;
        private System.Windows.Forms.ToolStripButton ButtonAddTab;
        private System.Windows.Forms.ToolStripButton ButtonTabRemove;
        private System.Windows.Forms.ToolStripButton historyButton;
        private System.Windows.Forms.ToolStripButton menuButton;
    }
}

