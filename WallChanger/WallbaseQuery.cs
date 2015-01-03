using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;

namespace WallChanger
{
    public class WallbaseQuery : IQuery
    {
        // public const string queryBase = "http://wallbase.cc/search?res_opt=gteq&res=1920x1080&order=random&thpp=20&aspect=1.01&board=2&q=";
        public const string queryBase = "http://alpha.wallhaven.cc/search?categories=101&purity=110&resolutions=1600x900,1600x1200,1680x1050,1920x1080,1920x1200,2560x1440,2560x1600&sorting=random&order=desc&q=";

        public readonly string QueryString;
        public readonly string Tag;
        public readonly List<string> Excludes;
        //public readonly string Color;

        public WallbaseQuery(string tag, List<string> excludes/*, string color = null*/)
        {
            Tag = tag;
            QueryString = MakeQueryString(tag);
            Excludes = excludes;
            //Color = color;
        }

        private static string MakeQueryString(string tag)
        {
            return queryBase + (tag != null ? tag.Replace(" ", "%20") : "") /*+ (Color != null ? "&color=" + Color : "")*/;
        }

        private WallData GetWallData(uint nSamples = 3)
        {
            var htmlWeb = new HtmlWeb();
            HtmlDocument thumbsPage = htmlWeb.Load(QueryString);
            IEnumerable<HtmlNode> thumbs = thumbsPage.GetElementbyId("thumbs").SelectNodes("section/ul/li/figure");
            //IEnumerable<HtmlNode> thumbs = thumbsPage.GetElementbyId("thumbs").ChildNodes.Where(x => x.GetAttributeValue("class", "").Split(' ').Contains("thumb"));
            IEnumerator<HtmlNode> it = thumbs.GetEnumerator();
            string wallhavenId = null;
            int maxFaves = -1;
            IEnumerable<string> thumbTags = new List<string>();
            // Take the most favorited of the first (nSamples) valid results, stopping early if fewer were found
            for (var i = 0; i < nSamples; i++)
            {
                // break if no more thumbs were found
                if (!it.MoveNext()) break;
                HtmlNode current = it.Current;
                IEnumerable<string> tags = current.SelectNodes("ul/li/a[1]").Select(x => x.InnerText);
                //IEnumerable<string> thumbTags = current.GetAttributeValue("data-tags", null).Split('|').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => x.ToLower());
                if (Excludes != null && tags.Select(x => x.ToLower()).Intersect(Excludes).Any()) continue;
                HtmlNode favNode = current.SelectSingleNode("div/*[2]");
                // HtmlNode favNode = current.QuerySelector(".wrapper>.faved-0>.num");
                // // Thumbs won't have a faves element if they have no faves
                int faves = Int32.Parse(favNode.InnerText);
                if (faves > maxFaves)
                {
                    maxFaves = faves;
                    wallhavenId = current.SelectSingleNode("img").GetAttributeValue("data-src", null);
                    wallhavenId = wallhavenId.Substring(wallhavenId.LastIndexOf('-') + 1);
                    thumbTags = tags;
                    i++;
                }
            }
            if (wallhavenId == null)
            {
                throw new Exception("No wallpapers found. Tags / excludes too specific.");
            }
            string uri = "http://wallpapers.wallhaven.cc/wallpapers/full/wallhaven-" + wallhavenId;
            return new WallData { tags = thumbTags.ToList(), uri = uri};
        }

        public WallData DownloadWallpaper(string localPath, uint nSamples = 3)
        {
            WallData wallData = GetWallData(nSamples);
            string localUri = localPath + wallData.uri.Substring(wallData.uri.LastIndexOf('/'));
            var webClient = new WebClient();
            webClient.DownloadFile(wallData.uri, localUri);
            WallData localWallData = new WallData { tags = wallData.tags, uri = localUri};
            return localWallData;
        }
    }

    public struct WallData
    {
        public List<string> tags;
        public string uri;
    }
}
