using Microsoft.AspNetCore.Mvc.TagHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using wikibellum.Web.Models;

namespace wikiparser
{
    class PageReader
    {
        public string _infoboxStart { get; set; }
        public string _infoboxEnd { get; set; }
        public string[] _targetStrings { get; set; }

        public PageReader()
        {
            _infoboxStart = "{{Infobox military conflict";
            _infoboxEnd = "==Background==";
            _targetStrings = new string[] { "conflict", "date", "place", "result", "combatant1", "combatant2", "strength1", "strength2" };

        }

        public Event ParseXml(string path)
        {
            var lines = ReadFile(path);
            Event parsedEvent = new Event() { Title = "none" };
            bool isViable = IsViable(lines, _infoboxStart, _infoboxEnd);

            if (isViable)
            {
                var infobox = ExtractInfobox(lines, _infoboxStart, _infoboxEnd);
                var extractedLines = ExtractTargetLines(infobox, _targetStrings);
                var rawDict = GeneratePropDict(extractedLines, _targetStrings);
                parsedEvent = ParseDictValuesToEvent(rawDict);
            }


            return parsedEvent;
                
        }

        private Event ParseDictValuesToEvent(Dictionary<string, string> rawDict)
        {
            Event parsedEvent = new Event() { Participants = new List<EventParticipant>() };
            foreach (var target in _targetStrings)
            {
                    if (target == "conflict")
                    {
                        var trimmed = rawDict[target].Trim();
                        parsedEvent.Title = trimmed;
                    }
                    else if (target == "date")
                    {
                        var dates = new DateParser().ParseDateLine(rawDict[target]);
                        parsedEvent = new DateParser().AddDatesToEvent(dates, parsedEvent);
                    }
                    else if (target == "place")
                    {
                        var location = new LocationParser().Parse(rawDict[target]);
                        parsedEvent.Location = location;
                    }
                    else if (target == "result")
                    {
                        var result = new ResultParser().ParseResultLine(rawDict[target]);
                        parsedEvent.Result = result;
                    }
                    else if (target == "combatant1")
                    {
                        parsedEvent.Participants.Add(new ParticipantParser().ParseName(rawDict[target]));
                    }
                    else if (target == "combatant2")
                    {
                        parsedEvent.Participants.Add(new ParticipantParser().ParseName(rawDict[target]));
                    }
                    else if (target == "strength1")
                    {
                        Console.WriteLine("Strength item value: " + rawDict[target]);
                        parsedEvent.Participants[0].Strength = new ParticipantParser().ParseStrength(rawDict[target]);
                    }
                    else if (target == "strength2")
                    {
                        parsedEvent.Participants[1].Strength = new ParticipantParser().ParseStrength(rawDict[target]);
                    }
                
            }


            //foreach (var item in rawDict)
            //{
            //    if (item.Key == "conflict")
            //    {
            //        var trimmed = item.Value.Trim();
            //        parsedEvent.Title = trimmed;
            //    }
            //    else if (item.Key == "date")
            //    {
            //        var dates = new DateParser().ParseDateLine(item.Value);
            //        parsedEvent = new DateParser().AddDatesToEvent(dates, parsedEvent);
            //    } else if (item.Key == "place")
            //    {
            //        var location = new LocationParser().Parse(item.Value);
            //        parsedEvent.Location = location;
            //    } else if (item.Key == "result")
            //    {
            //        var result = new ResultParser().ParseResultLine(item.Value);
            //        parsedEvent.Result = result;
            //    } else if (item.Key == "combatant1")
            //    {
            //        parsedEvent.Participants.Add(new ParticipantParser().ParseName(item.Value));                 
            //    } else if (item.Key == "combatant2")
            //    {
            //       parsedEvent.Participants.Add(new ParticipantParser().ParseName(item.Value));
            //    }
            //    else if (item.Key == "strength1")
            //    {
            //        Console.WriteLine("Strength item value: " + item.Value);
            //        parsedEvent.Participants[0].Strength = new ParticipantParser().ParseStrength(item.Value);
            //    }
            //    else if (item.Key == "strength2")
            //    {
            //        parsedEvent.Participants[1].Strength = new ParticipantParser().ParseStrength(item.Value);
            //    }
            //}

            return parsedEvent;
        }


        private Dictionary<string, string> GeneratePropDict(List<string> extractedLines, string[] targetStrings)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var line in extractedLines)
            {
                string[] splitStrings = new string[2];
                splitStrings = line.Split("=");

                try
                {
                    foreach (var targetString in targetStrings)
                    {
                        if (splitStrings[0].Contains(targetString))
                        {
                            dict.Add(targetString, splitStrings[1]);
                        }

                    }
                } catch (Exception e)
                {
                    if (e.Message != null) Console.WriteLine(e.Message);
                    Console.WriteLine("An error occured while generating a dictionary of infobox values");
                    Console.WriteLine("----- Extracted lines --------");
                    extractedLines.ForEach(str => Console.WriteLine(str));
                }

            }

            return dict;
        }


        public string ReadFile(string path)
        {
            string lines;
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.IgnoreWhitespace = true;

            //Start and end strings of the infobox
            try
            {
                using (var fileStream = File.OpenText(path))
                using (XmlReader reader = XmlReader.Create(fileStream, settings))
                {
                    reader.Read();
                    lines = reader.ReadOuterXml();

                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
            return lines;
        }

        public List<string> ExtractTargetLines(string infobox, string[] targets)
        {
            var infoboxLines = new List<string>();
            string pattern = @"(\|\s*\w*\s*=\s*.+)";
            Regex rg = new Regex(pattern);

            StringReader reader = new StringReader(infobox);

            string line = "";
            while (line != null)
            {
                try
                {
                    line = reader.ReadLine();
                    if (line != null && rg.IsMatch(line))
                    {
                        infoboxLines.Add(line);
                    }
                } catch (Exception e)
                {
                    if (e.Message != null) Console.WriteLine(e.Message);
                    Console.WriteLine("Unable to extract '{0}' from infobox", line);
                }

            }
            List<string> targetResults = new List<string>();
            List<string> foundResults = new List<string>();
            foreach (var infoboxLine in infoboxLines)
            {
                foreach (var target in targets)
                {
                    if (infoboxLine.Contains(target))
                    {
                        targetResults.Add(infoboxLine);
                        foundResults.Add(target);
                    }

                }
            }

            //add keys and values not found in infobox
            List<string> missingTargets = targets.ToList();
            foreach (var result in targetResults)
            {
                foreach (var target in targets)
                {
                    if (result.Contains(target)) missingTargets.Remove(target);
                }
            }

            foreach (var missingTarget in missingTargets)
            {
                targetResults.Add(missingTarget + "=" + "N/A");
            }

            return targetResults;
        }

        public bool IsViable(string rawXml, string startString, string endString)
        {
            return (rawXml.Contains(startString) && rawXml.Contains(endString));
        }


        public string ExtractInfobox(string rawXml, string startString, string finishString)
        {

            var startIndex = rawXml.IndexOf(startString);
            var endIndex = rawXml.IndexOf(finishString);
            string infoboxString = String.Empty;

            try
            {
                infoboxString = rawXml.Substring(startIndex, endIndex - startIndex - 4); //-4 to account for some trailing characters
            }
            catch (ArgumentOutOfRangeException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }

            return infoboxString;

        }

    }
}
