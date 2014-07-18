using Microsoft.VisualStudio.TestTools.UnitTesting;
using WallChanger;

namespace UnitTestProject
{
    [TestClass]
    public class WallpaperTest
    {
        [TestMethod]
        public void TestSetWallpaperFromUri()
        {
            string uri = WindowsOpsTest.BaseDirectory + @"nature\wallpaper-2172376.jpg";
            Wallpaper.SetDesktopWallpaper(uri, WallpaperStyle.Fill);
        }
    }
}