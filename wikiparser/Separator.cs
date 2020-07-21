using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace wikiparser
{
    class Separator
    {
        public void SeparateDumpIntoPages(string path)
        {
            string lines;
            XDocument doc = XDocument.Load(path);
            using (var reader = doc.CreateReader())
            {
                reader.Read();
                lines = reader.ReadOuterXml();
            }
            string pattern = @"<page>[\s\S]*?<\/page>";
            Regex rg = new Regex(pattern);
            var matches = rg.Matches(lines);
            var pageStrings = matches.Cast<Match>().Select(m => m.Value).ToArray<string>();

            var file = 0;
            foreach (var str in pageStrings)
            {
                File.WriteAllText(@"C:\Users\KW\source\repos\wikiparser\Pages\" + file.ToString() + ".xml", str);
                file += 1;
                
            }
        }
    }
}
