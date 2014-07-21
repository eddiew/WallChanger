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
            "desktopography",
            "abstract"
        };

        private static readonly string[] DefaultExcludes =
        {
            "women",
        };

        static void Main(string[] args)
        {
            List<WallbaseQuery> queryList = LoadTags();
            ChangeWall(queryList[Random.Next(0, queryList.Count)]);
        }

        public static List<WallbaseQuery> LoadTags()
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
                byte[] excludeBytes = Utf8.GetBytes("!" + String.Join(" ", DefaultExcludes) + Environment.NewLine);
                tagsFileStream.Write(excludeBytes, 0, excludeBytes.Length);
                tagsFileStream.Flush();
                tagsFileStream.Close();
            }
            // Read tags from tags.txt
            var queryList = new List<WallbaseQuery>();
            var globalExcludes = new List<string>();
            using (var sr = new StreamReader(tagsFilePath))
            {
                while (sr.Peek() != -1)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    else if (line.StartsWith("!"))
                    {
                        globalExcludes.AddRange(line.Substring(1).Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)));
                    }
                    else
                    {
                        string[] data = line.Split('!');
                        if (data.Length == 1)
                        {
                            Array.Resize(ref data, 2);
                            data[1] = "";
                        }
                        queryList.Add(new WallbaseQuery(data[0].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList(), data[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToList()));
                    }
                }
                sr.Close();
                foreach (WallbaseQuery query in queryList)
                {
                    query.Excludes.AddRange(globalExcludes);
                }
            }
            return queryList;
        }

        public static void ChangeWall(WallbaseQuery query)
        {
            string localPath = CreateLocalPath(string.Join(" ", query.Tags));
            string localUri = query.DownloadWallpaper(localPath);
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
