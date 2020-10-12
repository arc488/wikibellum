using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace wikibellum.Client.Helpers
{
    static class Coordinates
    {

        private static string[] _degreeChars = { "°", "′", "″" };

        public static Dictionary<string, double> ConvertCoordinates(string coordinateString)
        {
            if (coordinateString.Contains(".")) {
                return ParseDouble(coordinateString);
            }
            else
            {
                return ConvertToDouble(coordinateString);
            }
        }

        private static Dictionary<string, double> ParseDouble(string coordinateString)
        {
            Regex rx = new Regex(@"\d+\.\d+");
            var matches = rx.Matches(coordinateString);

            Dictionary<string, double> dict = new Dictionary<string, double>()
            {
                { "lat",  double.Parse(matches[0].Value) },
                { "lng", double.Parse(matches[1].Value) }
            };

            return dict;

        }
        private static Dictionary<string, double> ConvertToDouble(string coordinateString)
        {

            var strings = new Regex(@"\s").Split(coordinateString.Trim(' '));

            Regex rx = new Regex(@"\d{2}");

            double[] latArr = rx.Matches(strings[0]).Select(item => double.Parse(item.Value)).ToArray();
            double[] lngArr = rx.Matches(strings[1]).Select(item => double.Parse(item.Value)).ToArray();
      

            Dictionary<string, double> dict = new Dictionary<string, double>() 
            {
                { "lat",  Calculatedouble(latArr) },
                { "lng", Calculatedouble(lngArr) }
            };

            return dict;

        }

        private static double Calculatedouble(double[] arr)
        {
            //DD = d + (min / 60) + (sec / 3600)

            double dec = arr[0] + (arr[1] / 60) + (arr[2] / 3600);
            return dec;
        }
    }
}
