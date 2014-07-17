using System;
using WallChanger;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class WallpaperTest
    {
        [TestMethod]
        public void TestSetWallpaperFromUri()
        {
            string uri = @"C:\Users\wangeddx\Pictures\BackgroundChanger\wallpaper-2172376.jpg";
            Wallpaper.SetDesktopWallpaper(uri, WallpaperStyle.Fill);
        }
    }
}
