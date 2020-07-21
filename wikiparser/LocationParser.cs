using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using wikibellum.Entities;

namespace wikiparser
{
    public class LocationParser
    {
        public LocationParser()
        {
        }

        public Location Parse(string locationString)
        {
            var location = new Location();
            var cityName = locationString;
            var offMatch = Regex.Match(cityName, "(Off)");
            if (offMatch.Success)
            {
                cityName = cityName.Remove(offMatch.Index, 3);
            }

            cityName = cityName.Split(",")[0];

            if (cityName.Contains("|"))
            {
                cityName = cityName.Split("|")[0];
            }

            string pattern = @"(\w+\s?\w+\s?\w+)";
            Regex rg = new Regex(pattern);
            cityName = rg.Match(cityName).Value.Trim(char.Parse("["));
            location.Name = cityName;

            return location;
        }
    }
}