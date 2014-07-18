using System;
using System.IO;
using System.Runtime.InteropServices;

namespace WallChanger
{
    public class WindowsOps
    {
        public static string BaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\BackgroundChanger\";
        private static readonly Random random = new Random();
        public static readonly string[] Tags =
        {
            "nature",
            "landscapes",
            "cityscapes",
            "steampunk"
        };

        static void Main(string[] args)
        {
            ChangeWall();
        }

        public static void ChangeWall()
        {
            string tag = Tags[random.Next(0, Tags.Length)];
            string uri = UriScraper.GetWallpaperUri(tag);
            string localPath = CreateLocalPath(tag);
            string localUri = UriScraper.DownloadWallpaper(uri, localPath);
            Wallpaper.SetDesktopWallpaper(localUri, WallpaperStyle.Fill);
        }

        public static string CreateLocalPath(string tag)
        {
            string localPath = BaseDirectory + (tag != null ? '\\' + tag + '\\' : "");
            Directory.CreateDirectory(localPath);
            return localPath;
        }
    }
}
