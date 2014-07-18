using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WallChanger
{
    public class WindowsOps
    {
        public static string PictureDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\BackgroundChanger\";
        public static string ExecutableDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        private static readonly Random Random = new Random();
        private static readonly UTF8Encoding Utf8 = new UTF8Encoding();
        private static readonly string[] DefaultTags =
        {
            "nature",
            "landscapes",
            "cityscapes",
            "steampunk",
            "night",
            "intel",
            "desktopography"
        };

        static void Main(string[] args)
        {
            List<String> tags = LoadTags();
            ChangeWall(tags);
        }

        public static List<String> LoadTags()
        {
            string tagsFilePath = ExecutableDirectory + @"\tags.txt";
            // Create tags file if it doesn't exist
            if (!File.Exists(tagsFilePath))
            {
                FileStream tagsFileStream = File.Create(tagsFilePath);
                foreach (string tag in DefaultTags)
                {
                    byte[] tagBytes = Utf8.GetBytes(tag + Environment.NewLine);
                    tagsFileStream.Write(tagBytes, 0, tagBytes.Length);
                }
                tagsFileStream.Flush();
                tagsFileStream.Close();
            }
            var tags = new List<string>();
            using (var sr = new StreamReader(tagsFilePath))
            {
                while (sr.Peek() != -1)
                {
                    string tag = sr.ReadLine();
                    if (tag == "") continue;
                    tags.Add(tag);
                }
                sr.Close();
            }
            return tags;
        }

        public static void ChangeWall(IList<String> tags)
        {
            string tag = tags[Random.Next(0, tags.Count)];
            string uri = UriScraper.GetWallpaperUri(tag);
            string localPath = CreateLocalPath(tag);
            string localUri = UriScraper.DownloadWallpaper(uri, localPath);
            Wallpaper.SetDesktopWallpaper(localUri, WallpaperStyle.Fill);
        }

        public static string CreateLocalPath(string tag)
        {
            string localPath = PictureDirectory + (tag != null ? '\\' + tag + '\\' : "");
            Directory.CreateDirectory(localPath);
            return localPath;
        }
    }
}
