using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using wikibellum.Entities;

namespace wikiparser
{
    class DateParser
    {
        public List<DateTime> ParseDateLine(string dateLine)
        {
            var dates = new List<DateTime>();

            try
            {
                dates = this.DateParserA(dateLine);
                return dates;
            }
            catch (Exception e)
            {
                Debug.WriteLine("DateParserA failed");
                if (e.Message != null) Debug.WriteLine(e.Message);
            };

            try
            {
                dates = this.DateParserB(dateLine);
                return dates;
            } catch (Exception e)
            {
                Debug.WriteLine("DateParserB failed");
                if (e.Message != null) Debug.WriteLine(e.Message);
            }
            finally
            {
                dates.AddRange(new DateTime[] { new DateTime(), new DateTime() });
            }



            return dates;

        }
        //DD-DD Month YYYY // hyphen in pattern and dateLine is actually another character \u2013
        public List<DateTime> DateParserB(string dateLine)
        {
            var datePattern = @"(\d+\d*\s{1}[a-zA-Z]*\s\d{4})";

            var dateString = String.Empty;


            var matches = Regex.Matches(dateLine, datePattern);

            if (matches.Count < 1) throw new Exception("DD-DD Month YYYY parsed unable to parse: " + dateLine);

            char deliminator = Convert.ToChar("\u2013");
            var separatedStrings = matches.Select(m => m.Value).First().Split(deliminator).ToList();

            //Choose the longer part
            var fullDateStr = separatedStrings.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);
            //Choose shorter part with just the day
            var dayOnlyStr = separatedStrings.Aggregate(separatedStrings.First(), (min, item) => item.Length < min.Length ? item : min);

            var fullDate = DateTime.Parse(fullDateStr);
            var completedDate = new DateTime(fullDate.Year, fullDate.Month, int.Parse(dayOnlyStr));

            List<DateTime> dates = new List<DateTime>();

            dates.AddRange(new DateTime[2] { fullDate, completedDate });
            dates.Sort((a, b) => a.CompareTo(b));

            return dates;

        }
        //DD Month YYYY
        public List<DateTime> DateParserA(string dateLine)
        {
            var datePattern = @"(\d*\s{1}[a-zA-Z]*\s\d*)";

            var dateStrings = new List<string>();
            var dates = new List<DateTime>();

            Regex rg = new Regex(datePattern);
            var matches = rg.Matches(dateLine);

            dateStrings = matches.Select(m => m.Value).ToList();
            dates = dateStrings.Select(str => Convert.ToDateTime(str)).ToList();
            //make sure that the year isnt current due to DD mmmm - DD mmmm yyyy format
            if (dates.Any(d => d.Year == DateTime.Today.Year))
            {
                var index = dates.IndexOf(dates.First(d => d.Year == DateTime.Today.Year));
                var properDate = dates.First(d => d.Year != DateTime.Today.Year);
                dates[index] = new DateTime(properDate.Year, dates[index].Month, dates[index].Day);
               
            }

            dates.Sort((a, b) => a.CompareTo(b));

            if (dates[0].Year == 2020) 
            {
                dates[0] = new DateTime(dates[1].Year, dates[0].Month, dates[0].Day);
            }

            if (dates.Count < 1) throw new Exception("DD Month YYYY parsed unable to parse: " + dateLine);
            else return dates;
        }

        public Event AddDatesToEvent(List<DateTime> dates, Event parsedEvent)
        {
            try
            {
                parsedEvent.Start = dates[0];
                parsedEvent.End = dates[1];
            }
            catch (ArgumentOutOfRangeException e)
            {
                Debug.WriteLine(e.Message, "Dates Length: " + dates.Count);
                parsedEvent.Start = dates[0];
            }
            finally
            {
                
            }

            return parsedEvent;
        }
    }
}
