using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;

namespace WallChanger
{
    public static class WindowsOps
    {
        public static readonly string PictureDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) + @"\Wall Changer\";
        public static readonly string ExecutableDirectory = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string DocumentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Wall Changer\";
        private static readonly Random Random = new Random();
        private static readonly UTF8Encoding Utf8 = new UTF8Encoding();
        private static List<string> Tags = new List<string>
        {
            "nature",
            "landscapes",
            "cityscapes",
            "steampunk",
            "cyberpunk",
            "abstract"
        };

        private static List<string> Excludes = new List<string>
        {
            "women",
            "mlp",
            "my little pony",
        };

        private static ILog logger = LogManager.GetLogger("WindowsOps");

        static void Main(string[] args)
        {
            if (args != null)
            {
                foreach (string arg in args) {
                    string key = arg.Substring(0, arg.IndexOf('='));
                    switch (key)
                    {
                        case "BatteryOnly":
                            Boolean isRunningOnBattery = (SystemInformation.PowerStatus.PowerLineStatus == PowerLineStatus.Offline);
                            // Don't change wallpaper if BatteryOnly = 1 and isRunningOnBattery = true
                            if (arg[key.Length+1] == '1' && isRunningOnBattery) return;
                            break;
                    }
                }
            }
            BasicConfigurator.Configure();
            LoadTags();
            ChangeWall();
        }

        public static void LoadTags()
        {
            if (!Directory.Exists(DocumentsDirectory))
            {
                logger.Debug("Creating configuration directory at: " + DocumentsDirectory);
                Directory.CreateDirectory(DocumentsDirectory);
            }
            if (!Directory.Exists(DocumentsDirectory))
            {
                logger.Fatal("Unable to create configuration directory at: " + DocumentsDirectory);
            }
            else
            {
                logger.Debug("Configuration directory at: " + DocumentsDirectory + " was found or created correctly");
            }
            string tagsFilePath = DocumentsDirectory + "tags.txt";
            // Create tags file if it doesn't exist
            if (!File.Exists(tagsFilePath))
            {
                logger.Debug("Configuration file not found. Creating from defaults");
                FileStream tagsFileStream = File.Create(tagsFilePath);
                if (tagsFileStream == null)
                {
                    logger.Error("Unable to create configuration file at: " + tagsFilePath);
                    logger.Info("Using default tags");
                    return;
                }
                foreach (string tag in Tags)
                {
                    byte[] tagBytes = Utf8.GetBytes(tag + Environment.NewLine);
                    tagsFileStream.Write(tagBytes, 0, tagBytes.Length);
                }
                foreach (string exclude in Excludes)
                {
                    byte[] excludeBytes = Utf8.GetBytes('!' + exclude + Environment.NewLine);
                    tagsFileStream.Write(excludeBytes, 0, excludeBytes.Length);
                }
                tagsFileStream.Flush();
                tagsFileStream.Close();
                logger.Debug("Success");
                return;
            }
            else
            {
                logger.Debug("Configuration file found");
                // Don't use defaults
                Excludes.Clear();
                Tags.Clear();
            }
            // Read tags from tags.txt
            using (var sr = new StreamReader(tagsFilePath))
            {
                logger.Debug("Loading configuration at: " + tagsFilePath);
                while (sr.Peek() != -1)
                {
                    string line = sr.ReadLine();
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    else if (line.StartsWith("!"))
                    {
                        Excludes.Add(line.Substring(1));
                    }
                    else
                    {
                        Tags.Add(line);
                    }
                }
                sr.Close();
            }
            logger.Debug("Tags loaded");
        }

        private static WallbaseQuery GetRandomQuery()
        {
            return new WallbaseQuery(Tags[Random.Next(0, Tags.Count)], Excludes);
        }

        public static void ChangeWall()
        {
            WallbaseQuery query = GetRandomQuery();
            string localUri = "";
            try
            {
                logger.Debug("Attempting to set wallpaper to: " + localUri);
                string localPath = CreateLocalPath(string.Join(" ", query.Tag));
                WallData wallData = query.DownloadWallpaper(localPath);
                localUri = wallData.uri;
                // Set file tags
                //Image wall = Image.FromFile(localUri);
                //wall.Tag = 
                Wallpaper.SetDesktopWallpaper(localUri, WallpaperStyle.Fill);
                logger.Debug("Success");
            }
            catch (Exception e)
            {
                logger.Fatal("Unable to set wallpaper to: " + localUri, e);
            }
        }

        public static string CreateLocalPath(string tag)
        {
            string localPath = PictureDirectory + (tag != null ? tag + '\\' : "");
            Directory.CreateDirectory(localPath);
            return localPath;
        }
    }
}
