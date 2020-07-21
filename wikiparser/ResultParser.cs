using IQToolkit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace wikiparser
{
    internal class ResultParser
    {
        private string[] _sides;

        public ResultParser()
        {
            _sides = new string[] { "allied", "soviet", "german", 
                "axis", "italian", "british", "french", "american", 
                "japanese", "chinese", "polish", "hungarian", 
                "czech", "slovak", "belgian", "danish", "greek",
                "yugoslavian", "dutch", "indian", "canadian", "mexican",
                "norwegian", "australian", "brazilian", "romanian",
                "slovakian", "croatian", "bulgarian", "finnish", "finish",
                "thai", "iraqi" };
        }

        public string ParseResultLine(string resultLine)
        {
            var result = String.Empty;
            bool sideMatched = false;
            bool outcomeMatched = false;

            List<string> matches = new List<string>();

            foreach (var side in _sides)
            {
                if (resultLine.ToLower().Contains(side))
                {
                    matches.Add(side);
                    sideMatched = true;
                }
            }

            string finalSide ="";
            if (matches.Count > 1)
            {
                Dictionary<int, string> matchIndex = new Dictionary<int, string>();
                foreach (var match in matches)
                {
                    var index = resultLine.ToLower().IndexOf(match);
                    matchIndex.Add(index, match);
                }
                var firstMatch = matchIndex.Keys.Aggregate(0, (min, cur) => min < cur ? min : cur);
                if (firstMatch != 0)
                {
                    finalSide = char.ToUpper(matchIndex[firstMatch][0]) + matchIndex[firstMatch].Substring(1);
                }
            } 
            else if (matches.Count == 1)
            {
                finalSide = char.ToUpper(matches.First()[0]) + matches.First().Substring(1);
            }

            result += finalSide;
            

            if (resultLine.ToLower().Contains("victory"))
            {
                result += " victory";
                outcomeMatched = true;
            }
            else if (resultLine.ToLower().Contains("loss"))
            {
                result += " loss";
                outcomeMatched = true;

            }

            if (!sideMatched)
            {
                result += "Unknown Side";
            }
            if (!outcomeMatched)
            {
                result += " Unknown Outcome";
            }

            return result;



        }
    }
}