using System;
using System.Collections.Generic;
using System.Linq;
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
            var tagList = new string[] { "nature" }.ToList();
            var excludeList = new string[] { "women" }.ToList();
            var query = new WallbaseQuery(tagList, excludeList);
            string uri = query.GetWallpaperUri();
            Assert.IsTrue(uri.Contains("http://wallpapers.wallbase.cc/"));
        }

        [TestMethod]
        public void TestDownloadWallpaper()
        {
            string localPath = WindowsOpsTest.BaseDirectory + @"\nature\";
            var tagList = new string[] { "nature" }.ToList();
            var excludeList = new string[] { "women" }.ToList();
            var query = new WallbaseQuery(tagList, excludeList);
            query.DownloadWallpaper(localPath);
        }
    }
}
