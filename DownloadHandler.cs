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
        
        Browser mainBrowser;

        public bool FileIsDownloading;
        public bool DownloadComplete;
        public bool DownloadCancelled;

        public DownloadHandler(Browser browser)
        {
            this.mainBrowser = browser;
        }


        public event EventHandler<DownloadItem> OnBeforeDownloadFired;

        public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

        public string filePath = null;  

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


        public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
        {
            mainBrowser = new Browser();
            OnDownloadUpdatedFired?.Invoke(this, downloadItem);
            filePath = downloadItem.FullPath.ToString();
            
            if (downloadItem.IsInProgress)
            {
                FileIsDownloading = true;
            }
            else if (downloadItem.IsComplete)
            {
                DownloadComplete = true;
            }
            else if (downloadItem.IsCancelled)
            {
                DownloadCancelled = true;
            }
            
        }

    }
}
