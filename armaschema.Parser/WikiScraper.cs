using Geocoding;
using IronWebScraper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace armaschema.Parser
{
    public class WikiScraper : WebScraper
    {
        public List<string> Urls { get; set; } = new List<string>()
        {
            "https://en.wikipedia.org/wiki/Battle_of_Tuchola_Forest",
            "https://en.wikipedia.org/wiki/Battle_of_Jordan%C3%B3w",
            "https://en.wikipedia.org/wiki/Siege_of_Warsaw_(1939)",
            "https://en.wikipedia.org/wiki/Battle_of_Lw%C3%B3w_(1939)"
        };

        public Dictionary<string, string> selectors = new Dictionary<string, string>()
            {
                { "name", "#mw-content-text > div.mw-parser-output > div.mw-stack.desktop-float-right > div:nth-child(1) > table > tbody > tr:nth-child(1) > th" },
                { "tbody", "#mw-content-text > div.mw-parser-output > div.mw-stack.desktop-float-right > div:nth-child(1) > table > tbody" },
                { "dlr", "#mw-content-text > div.mw-parser-output > div.mw-stack.desktop-float-right > div:nth-child(1) > table > tbody > tr:nth-child(4) > td > table > tbody > tr" }
            };
        /// <summary>
        /// Switch to using xpath!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        /// </summary>
        public override void Init()
        {
            License.LicenseKey = "LicenseKey"; // Write License Key
            this.LoggingLevel = WebScraper.LogLevel.All; // All Events Are Logged
            this.Request(Urls[3], Parse);

            foreach (var item in Urls)
            {
            }
        }

        public override void Parse(Response response)
        {
            this.WorkingDirectory = @".\Output\";
            var path = "//table[1]";
            var xpath = response.XPath(path);

            Cnsl.WriteTd(xpath.ToJSON());

            if (response.Css(".infobox") is var results && results.Length > 0)
            {
                var infoboxTbody = results[0].GetElementsByTagName("TBODY")[0];


                var dataTRs = GetDataTRs(infoboxTbody);
                var belligerents = GetBelligerentTds(dataTRs);
                foreach (var belligerent in belligerents)
                {
                    foreach (var item in belligerent)
                    {
                        Cnsl.Brk();
                        Console.WriteLine(item.Key + " : " + item.Value);
                    }
                }
            }
            
            if (2 < 1)
            {   
                Cnsl.Brk('/', 20, ConsoleColor.Yellow);

                var dlr = GetDlr(response);
                var coordinates = GetCoordinates(response);
                var name = GetName(response);

                Console.WriteLine(name);
                foreach (var item in dlr)
                {
                    Console.WriteLine(item.Key + " " + item.Value);
                }
                Console.WriteLine("Latitude: " + coordinates["latitude"]);
                Console.WriteLine("Longitude: " + coordinates["longitude"]);
                Cnsl.Brk('/', 20, ConsoleColor.Yellow);
            }
            //for (int i = 1; i <= 2; i++)
            //{
            //    var selectorString = String.Format(selectors["tbody"] + "> tr > td:nth-child({0})", i);

            //    Cnsl.Brk();

            //    foreach (var item in response.Css(selectorString))
            //    {
            //        Cnsl.WriteTd(item.InnerTextClean);
            //    }
            //}
        }

        private List<Dictionary<string, string>> ProcessInnerHtmlTds(List<Dictionary<string, string>> belligerentInnerHtmls)
        {
            var belligerents = new List<Dictionary<string, string>>();
            foreach (var belligerent in belligerentInnerHtmls)
            {
                var dict = new Dictionary<string, string>();
                foreach (var prop in belligerent)
                {
                    dict.Add(prop.Key, Regex.Replace(prop.Value, "(?!<br>)<.+?>", String.Empty));
                }
                belligerents.Add(dict);
            }
            return belligerents;
        }

        public List<Dictionary<string, string>> GetBelligerentTds(Dictionary<string, HtmlNode> trs)
        {
            var belligerents = new List<Dictionary<string, string>>();
            for (int i = 0; i < 2; i++)
            {
                var belligerent = new Dictionary<string, string>();
                foreach (var tr in trs)
                {
                    //belligerent.Add(tr.Key, tr.Value.ChildNodes[i].InnerHtml);
                }
                belligerents.Add(belligerent);
            }

            belligerents = ProcessInnerHtmlTds(belligerents);

            return belligerents;
        }

        public Dictionary<string, HtmlNode> GetDataTRs(HtmlNode tbody)
        {
            var dict = new Dictionary<string, HtmlNode>();
            HtmlNode[] nodes = tbody.ChildNodes;
            for (int i = 0; i < nodes.Length; i++)
            {
                var content = nodes[i].InnerTextClean;
                switch (content)
                {
                    case "Belligerents":
                        dict.Add("Belligerents", nodes[i + 1]);
                        break;
                    case "Strength":
                        dict.Add("Strength", nodes[i + 1]);
                        break;
                    case "Casualties and losses":
                        dict.Add("Losses", nodes[i + 1]);
                        break;
                }
            }
            return dict;
        }
        public Dictionary<string, string> GetCoordinates(Response response)
        {
            var dict = new Dictionary<string, string>() { { "latitude", "" }, { "longitude", "" } };
            var coords = response.GetElementById("coordinates");
            try
            {
                var lat = coords.Css(".latitude")[0].TextContentClean;
                var lng = coords.Css(".longitude")[0].TextContentClean;
                dict["lat"] = lat;
                dict["lng"] = lng;
                return dict;
            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not find coordinates");
                Debug.WriteLine(e.Message);
                return dict;
                
            }

        }

        public string GetName(Response response)
        {
            return response.Css(selectors["name"])[0].TextContentClean;
        }

        public Dictionary<string, string> GetDlr(Response response) 
        {
            var results = new Dictionary<string, string>();
            var nodes = response.Css(selectors["dlr"]);
            //each node is a line of wiki DLR details containing Name in TH (ex. "Result") and Content in TD (ex. "German vitory")
            foreach (var item in nodes)
            {
                var name = item.GetElementsByTagName("TH")[0].InnerTextClean;
                var content = item.GetElementsByTagName("TD")[0].InnerTextClean;

                switch (name)
                {
                    case "Date":
                        results.Add("Date", content);
                        break;
                    case "Location":
                        results.Add("Location", content);
                        break;
                    case "Result":
                        results.Add("Result", content);
                        break;
                }
            }
            return results;
        }
    }
}
//// Loop On All Links
//if (response.CssExists("div.prev-post > a[href]"))
//{
//    // Get Link URL
//    var next_page = response.Css("div.prev-post > a[href]")[0].Attributes["href"];
//    // Scrape Next URL
//    this.Request(next_page, Parse);
//}