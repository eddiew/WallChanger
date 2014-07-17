using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WallChanger
{
    public class WallChanger : ServiceBase
    {
        private Timer timer;
        const String tag = "nature";

        static void Main(string[] args)
        {
            Run(new WallChanger());
        }

        public WallChanger()
        {
            ServiceName = "WallChanger";
            CanStop = true;
            CanPauseAndContinue = true;
            AutoLog = true;
        }

        protected override void OnStart(string[] args)
        {
            string uri = UriScraper.GetWallpaperUri(tag);
            string localPath = UriScraper.DownloadWallpaper(uri);
            Wallpaper.SetDesktopWallpaper(localPath, WallpaperStyle.Fill);
            var tick = new TimerCallback(SwitchBg);
            timer = new Timer(tick, null, 0, 30*60*1000);
        }

        protected override void OnStop()
        {
            timer.Dispose();
        }

        private void SwitchBg(Object state)
        {
            string uri = UriScraper.GetWallpaperUri(tag);
            string localPath = UriScraper.DownloadWallpaper(uri);
            Wallpaper.SetDesktopWallpaper(localPath, WallpaperStyle.Fill);
        }
    }
}
