using System;
using System.IO;

namespace WallChanger
{
    public class WindowsOps
    {
        public static string BaseDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\BackgroundChanger\";
        public static readonly string[] Tags =
        {
            "nature",
            "landscapes",
            "cityscapes"
        };

        static void Main(string[] args)
        {
            ChangeWall();
        }

        public static void ChangeWall()
        {
            var random = new Random();
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
