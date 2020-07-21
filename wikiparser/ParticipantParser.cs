using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using wikibellum.Entities;
using wikiparser.Enums;

namespace wikiparser
{
    public class ParticipantParser
    {
        public ParticipantParser()
        {
        }

        public EventParticipant ParseName(string line)
        {
            EventParticipant participant = new EventParticipant(); 
            string str = String.Empty;
            foreach (var item in Enum.GetValues(typeof(Allies)))
            {
                string countryName = item.ToString();
                if (countryName.Contains("_")) countryName = countryName.ToString().Replace("_", " ");
                if (line.Contains(countryName))
                {
                    str = countryName;
                    participant.Name = str;
                }
            }
            if (!String.IsNullOrEmpty(str)) return participant;

            foreach (var item in Enum.GetValues(typeof(Axis)))
            {
                string countryName = item.ToString();
                if (countryName.Contains("_")) countryName = countryName.ToString().Replace("_", " ");
                if (line.Contains(countryName))
                {
                    str = countryName;
                    participant.Name = str;
                }
            }

            if (String.IsNullOrEmpty(str)) participant.Name = "Unknown";

            return participant;
        }

        public UnitStrength ParseStrength(string line)
        {
            int largestNumber = 0;
            UnitStrength unitStrength = new UnitStrength();
            try
            {
                var pattern = @"(\d+,?\d*)";
                var matches = Regex.Matches(line, pattern);
                var numberStrings = matches.Select(m => m.Value).ToList().Select(str => str.Replace(",", ""));
                var parsedStrings = numberStrings.Select(str => Int32.Parse(str)).ToList();
                largestNumber = parsedStrings.Aggregate(0, (max, cur) => max > cur ? max : cur);
            }
            catch (Exception e)
            {
                Debug.WriteLine("Unable to parse strength");
                if (e.Message != null) Debug.WriteLine(e.Message);
                largestNumber = 0;
            }

            unitStrength.Personnel = largestNumber;

            return unitStrength;
        }
    }
}