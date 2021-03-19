using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChromiumBrowserWinForms
{
    public partial class BrowserMenu : Form
    {
        public BrowserMenu()
        {
            InitializeComponent();
            InitializeBrowserMenu();
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

    }
}
