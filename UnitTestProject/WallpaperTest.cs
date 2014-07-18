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
            string uri = @"C:\Users\wangeddx\Pictures\BackgroundChanger\nature\wallpaper-2172376.jpg";// TODO: make portable
            Wallpaper.SetDesktopWallpaper(uri, WallpaperStyle.Fill);
        }
    }
}