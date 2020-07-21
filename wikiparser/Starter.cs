using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using wikibellum.Entities;

namespace wikiparser
{
    public class Starter
    {


        public List<Event> StartParse(int startFile, int endFile)
        {
            int _startFile = startFile;
            int _endFile = endFile;
            var _path = @"C:\Users\KW\source\repos\wikiparser\BattlesRaw.txt";
            var _savePath = @"C:\Users\KW\source\repos\wikiparser\final.txt";
            var _xmlPath = @"C:\Users\KW\source\repos\wikibellum\wikiparser\Pages\";

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
                Debug.WriteLine("VV File: " + i);
                var path = _xmlPath + i + ".xml";
                var parsedEvent = new PageReader().ParseXml(path);
                parsedEvent.FileName = i + ".xml";
                if (parsedEvent.Title != "none")
                {
                    parsedEvents.Add(parsedEvent);
                    Debug.WriteLine("##########################");
                    //Debug.WriteLine("Title     " + parsedEvent.Title);
                    //Debug.WriteLine("Date Start" + parsedEvent.Start.ToString("dd/MMMM/yyyy"));
                    //Debug.WriteLine("Date End  " + parsedEvent.End.ToString("dd/MMMM/yyyy"));
                    Debug.WriteLine("Location  " + parsedEvent.Location.Name);
                    //Debug.WriteLine("Result    " + parsedEvent.Result);
                    //Debug.WriteLine("Combatant1    " + parsedEvent.Participants[0].Name);
                    //Debug.WriteLine("Strength1    " + parsedEvent.Participants[0].Strength.Personnel);
                    //Debug.WriteLine("Combatant2    " + parsedEvent.Participants[1].Name);
                    //Debug.WriteLine("Strength2    " + parsedEvent.Participants[1].Strength.Personnel);

                    Debug.WriteLine("______________________");

                }
                else
                {
                    nonViables.Add(i + ".xml");
                }
            }

            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(@"C:\Users\KW\source\repos\wikibellum\wikiparser\nonViables.txt", true))
            {
                foreach (var item in nonViables)
                {
                    file.WriteLine(item);
                }
            }

            return parsedEvents;
        }
    }
}
