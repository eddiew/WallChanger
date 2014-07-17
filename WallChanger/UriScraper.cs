using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WallChanger
{
    public static class UriScraper
    {
        public const string queryBase = "http://wallbase.cc/search?res_opt=gteq&res=1920x1080&order=random&thpp=20&board=2&q=";
        public const string destBase = @"C:\Users\wangeddx\Pictures\BackgroundChanger\";

        public static string GetWallpaperUri(String tag)
        {
            string uri = queryBase + tag;
            var htmlWeb = new HtmlWeb();

            HtmlDocument doc = htmlWeb.Load(uri);
            HtmlNode thumb = doc.DocumentNode.SelectSingleNode(@"//*[contains(@class, 'wrapper')]/a[2]");
            string uri2 = thumb.GetAttributeValue("href", null);

            HtmlDocument doc2 = htmlWeb.Load(uri2);
            HtmlNode img = doc2.DocumentNode.SelectSingleNode(@"//img[contains(@class, 'wall')]");
            string uri3 = img.GetAttributeValue("src", null);

            return uri3;
        }

        public static string DownloadWallpaper(string uri)
        {
            string name = uri.Substring(uri.LastIndexOf('/'));
            var webClient = new WebClient();
            string localPath = destBase + name;
            webClient.DownloadFile(uri, localPath);
            return localPath;
        }
    }
}
