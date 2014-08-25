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
            int maxFaves = 0;
            IEnumerator<HtmlNode> it = thumbs.GetEnumerator();
            // Take the most favorited of the first 3 results
            for (var i = 0; i < 3; i++)
            {
                // break if no more thumbs were found
                if (!it.MoveNext()) break;
                HtmlNode current = it.Current;
                IEnumerable<string> thumbTags = current.GetAttributeValue("data-tags", null).Split('|').Where(x => !string.IsNullOrWhiteSpace(x));
                if (Excludes != null && Enumerable.Intersect(thumbTags, Excludes).Any()) continue;
                int faves = Int32.Parse(current.QuerySelector(".wrapper>.faved-0>.num").InnerText);
                if (faves > maxFaves)
                {
                    maxFaves = faves;
                    uri2 = current.QuerySelector(".wrapper>a:last-child").GetAttributeValue("href", null);
                }
            }
            // If none of the first 3 results satisfied our excludes, take the first result that does
            while (uri2 == null)
            {
                // break if no more thumbs were found
                if (!it.MoveNext()) break;
                HtmlNode current = it.Current;
                IEnumerable<string> thumbTags = current.GetAttributeValue("data-tags", null).Split('|').Where(x => !string.IsNullOrWhiteSpace(x));
                if (Excludes != null && Enumerable.Intersect(thumbTags, Excludes).Any()) continue;
                uri2 = current.QuerySelector(".wrapper>a:last-child").GetAttributeValue("href", null);
            }
            if (uri2 == null)
            {
                throw new Exception("No wallpapers found. Tags / excludes too specific.");
            }
            HtmlDocument imgPage = htmlWeb.Load(uri2);
            HtmlNode img = imgPage.DocumentNode.SelectSingleNode(@"//img[contains(@class, 'wall')]");
            string uri3 = img.GetAttributeValue("src", null);
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
