using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using WikimediaProcessing;

namespace wikiparser
{
    class ParseBattles
    {

        public List<string> ParseToList(string path)
        {
            List<string> allLinesText = File.ReadAllLines(path).ToList<string>();
            return allLinesText;

        }

        public List<string> ParseBattleNames(List<string> battlesRaw)
        {
            int first;
            int second;
            List<string> parsedList = new List<string>();
            foreach (var name in battlesRaw)
            {
                if (String.IsNullOrEmpty(name)) continue;
                var cleaned = name.Replace("*", " ").Replace("[", " ").Replace("]", " ");
                var trimmed = cleaned.Trim();

                var splitIndex = trimmed.IndexOf(":");
                string battleName;
                if (splitIndex != -1)
                {
                    battleName = trimmed.Substring(0, trimmed.Length - (trimmed.Length - splitIndex));

                }
                else
                {
                    battleName = trimmed;
                }
                parsedList.Add(battleName);
            }

            return parsedList;
        }

        public void GetBattles(string path)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(path);
            var titles = xmlDoc.GetElementsByTagName("Title");
            foreach (var item in titles)
            {
                Debug.WriteLine(item);
            }

        }



    }
}
