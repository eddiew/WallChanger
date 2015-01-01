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
        public void TestDownloadWallpaper()
        {
            string localPath = WindowsOpsTest.BaseDirectory + @"\nature\";
            var tag = "nature";
            var excludeList = new string[] { "women" }.ToList();
            var query = new WallbaseQuery(tag, excludeList);
            query.DownloadWallpaper(localPath);
        }
    }
}
