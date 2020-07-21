using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Models;

namespace wikiparser
{
    class Starter
    {


        public List<Event> StartParse(int startFile, int endFile)
        {
            int _startFile = startFile;
            int _endFile = endFile;
            var _path = @"C:\Users\KW\source\repos\wikiparser\BattlesRaw.txt";
            var _savePath = @"C:\Users\KW\source\repos\wikiparser\final.txt";
            var _xmlPath = @"C:\Users\KW\source\repos\wikiparser\Pages\";

            List<string> nonViables = new List<string>();
            List<string> failedViables = new List<string>();
            List<Event> parsedEvents = new List<Event>();
            bool parse = false;

            if (parse)
            {
                var sep = new Separator();
                sep.SeparateDumpIntoPages(_xmlPath);
            }

            for (int i = _startFile; i < _endFile; i++)
            {
                Console.WriteLine("File: " + i);
                var path = _xmlPath + i + ".xml";
                var parsedEvent = new PageReader().ParseXml(path);
                if (parsedEvent.Title != "none")
                {
                    parsedEvents.Add(parsedEvent);
                    Console.WriteLine("##########################");
                    Console.WriteLine("Title     " + parsedEvent.Title);
                    Console.WriteLine("Date Start" + parsedEvent.Start.ToString("dd/MMMM/yyyy"));
                    Console.WriteLine("Date End  " + parsedEvent.End.ToString("dd/MMMM/yyyy"));
                    Console.WriteLine("Location  " + parsedEvent.Location.Name);
                    Console.WriteLine("Result    " + parsedEvent.Result);
                    Console.WriteLine("Combatant1    " + parsedEvent.Participants[0].Name);
                    Console.WriteLine("Strength1    " + parsedEvent.Participants[0].Strength.Personnel);
                    Console.WriteLine("Combatant2    " + parsedEvent.Participants[1].Name);
                    Console.WriteLine("Strength2    " + parsedEvent.Participants[1].Strength.Personnel);

                    Console.WriteLine("______________________");

                }
                else
                {
                    nonViables.Add(path);
                }
            }
            return parsedEvents;
        }
    }
}
