using System;
using System.Text.RegularExpressions;
using wikibellum.Models;

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
            var cityName = locationString.Split(",")[0];
            string pattern = @"(\[\[[a-zA-Z]*\s?[a-zA-z]*\b)";
            Regex rg = new Regex(pattern);
            cityName = rg.Match(cityName).Value.Trim(char.Parse("["));
            location.Name = cityName;
            return location;
        }
    }
}