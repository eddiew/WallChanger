using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace WallChanger
{
    public class WallbaseQuery
    {
        public const string queryBase = "http://wallbase.cc/search?res_opt=gteq&res=1920x1080&order=random&thpp=20&aspect=1.01&board=2&q=";
        
        public readonly List<String> Tags;
        public readonly List<String> Excludes;
        public readonly string Color;

        public WallbaseQuery(List<String> tags, List<String> excludes, string color = null)
        {
            this.Tags = tags;
            this.Excludes = excludes;
            this.Color = color;
        }

        public string GetQueryString()
        {
            return queryBase + (Tags != null ? string.Join("%20", Tags) : "") + (Color != null ? "&color=" + Color : "");
        }

        public string GetWallpaperUri()
        {
            var htmlWeb = new HtmlWeb();

            HtmlDocument thumbsPage = htmlWeb.Load(GetQueryString());
            IEnumerable<HtmlNode> thumbs = thumbsPage.GetElementbyId("thumbs").ChildNodes.Where(x => x.GetAttributeValue("class", "").Contains("thumbnail"));
            string uri2 = null;
            foreach (HtmlNode thumb in thumbs)
            {
                IEnumerable<string> thumbTags = thumb.GetAttributeValue("data-tags", null).Split('|').Where(x => !string.IsNullOrWhiteSpace(x));
                if (Excludes != null && Enumerable.Intersect(thumbTags, Excludes).Any()) continue;
                uri2 = thumb.QuerySelector(".wrapper>a:last-child").GetAttributeValue("href", null);
                if (uri2 == null) continue;
                break;
            }
            if (uri2 == null)
            {
                throw new Exception("No wallpapers found. Tags / excludes too specific.");
            }
            HtmlDocument imgPage = htmlWeb.Load(uri2);
            HtmlNode img = imgPage.DocumentNode.SelectSingleNode(@"//img[contains(@class, 'wall')]");
            string uri3 = img.GetAttributeValue("src", null);
            //uri3 = uri3.SkipWhile(x => (x == '\\') || (x == '/'));
            return uri3;
        }

        public string DownloadWallpaper(string localPath)
        {
            string uri = GetWallpaperUri();
            string localUri = localPath + uri.Substring(uri.LastIndexOf('/'));
            var webClient = new WebClient();
            webClient.DownloadFile(uri, localUri);
            return localUri;
        }
    }
}
