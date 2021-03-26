using CefSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WaterSkyWinForms;

namespace ChromiumBrowserWinForms
{
    public class DownloadHandler : IDownloadHandler
    {
        


        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        string filePath = null;  

        public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
        {
            OnBeforeDownloadFired?.Invoke(this, downloadItem);

            if (!callback.IsDisposed)
            {
                using (callback)
                {
                    callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
                }
            }
        }


        Browser mainBrowser;

        public DownloadHandler(Browser browser)
        {
            this.mainBrowser = browser;
        }
        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            mainBrowser = new Browser();
            OnDownloadUpdatedFired?.Invoke(this, downloadItem);
            filePath = downloadItem.FullPath.ToString();

            if (downloadItem.IsInProgress)
            {
                mainBrowser.ShowDownloadsLabel();
            }
            else if (downloadItem.IsComplete)
            {
                Process.Start("explorer.exe", "/select, " + filePath);
                
            }
            
        }

    }
}
