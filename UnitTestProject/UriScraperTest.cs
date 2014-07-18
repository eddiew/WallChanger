using System;
using WallChanger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UriScraperTest
    {
        [TestMethod]
        public void TestGetWallpaperUri()
        {
            string tag = "nature";
            string uri = UriScraper.GetWallpaperUri(tag);
            Assert.IsTrue(uri.Contains("http://wallpapers.wallbase.cc/"));
        }

        [TestMethod]
        public void TestDownloadWallpaper()
        {
            string localPath = WindowsOpsTest.BaseDirectory + @"\nature\";
            string uri = "http://wallpapers.wallbase.cc/rozne/wallpaper-2172376.jpg";
            UriScraper.DownloadWallpaper(uri, localPath);
        }
    }
}
