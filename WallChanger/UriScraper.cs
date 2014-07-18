using System;
using System.IO;
using System.Net;
using HtmlAgilityPack;

namespace WallChanger
{
    public static class UriScraper
    {
        public const string queryBase = "http://wallbase.cc/search?res_opt=gteq&res=1920x1080&order=random&thpp=20&aspect=1.01&board=2&q=";

        public static string GetWallpaperUri(string tag, string color = null)
        {
            string uri = queryBase + tag + (color!=null ? "&color="+color : "");
            var htmlWeb = new HtmlWeb();

            HtmlDocument doc = htmlWeb.Load(uri);
            HtmlNode thumb = doc.DocumentNode.SelectSingleNode(@"//*[contains(@class, 'wrapper')]/a[2]");
            string uri2 = thumb.GetAttributeValue("href", null);

            HtmlDocument doc2 = htmlWeb.Load(uri2);
            HtmlNode img = doc2.DocumentNode.SelectSingleNode(@"//img[contains(@class, 'wall')]");
            string uri3 = img.GetAttributeValue("src", null);

            return uri3;
        }

        public static string DownloadWallpaper(string uri, string localPath)
        {
            string localUri = localPath + uri.Substring(uri.LastIndexOf('/'));
            var webClient = new WebClient();
            webClient.DownloadFile(uri, localUri);
            return localUri;
        }
    }
}
