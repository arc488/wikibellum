using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using wikibellum.Data;
using wikibellum.Entities;

namespace armaschema.Parser
{
    public class Adder
    {
        private readonly IEventRepository _eventRepository;

        public Adder(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void AddEvents(List<Event> events)
        {
            foreach (var item in events)
            {
                _eventRepository.Create(item);
            }
        }

        public List<Event> DtoToEvent(List<Dto> dtos)
        {
            List<Event> events = new List<Event>();
            foreach (var dto in dtos)
            {
                var battle = new Event()
                {
                    Title = dto.name,
                    Linkline = dto.linkline,              
                    Location = new Location()
                    {
                        Lat = dto.coordinates[0],
                        Long = dto.coordinates[1],
                        Name = dto.basics.location
                    },
                    Start = DateTime.Parse(dto.basics.start),
                    End = DateTime.Parse(dto.basics.end),
                    DateFlagged = dto.basics.flagged,
                    Source = dto.source
                };
                foreach (var item in dto.basics.results)
                {
                    var result = new Result()
                    {
                        Description = item
                    };
                    battle.Results.Add(result);
                }
                events.Add(battle);
            }
            return events;
        }

        public List<Dto> ParseJson()
        {
            var jsonText = File.ReadAllText(@"F:\Projects\pythonscraper\exported.json");
            //var dtos = new List<Dto>();
            //var json = JObject.Parse(jsonText);
            //foreach (var item in json)
            //{
            //    var dto = JsonConvert.DeserializeObject<Dto>(item.ToString());
            //    dtos.Add(dto);
            //}
            var dtos = JsonConvert.DeserializeObject<List<Dto>>(jsonText);
            //var dtos = System.Text.Json.JsonSerializer.Deserialize<List<Dto>>(jsonText);

            foreach (var dto in dtos)
            {
                if (dto.basics.results != null)
                {
                    foreach (var item in dto.basics.results)
                    {
                        Console.WriteLine(item);
                    }
                }
                Console.WriteLine(dto.source);
            }

            return dtos;
        }

    }

    public class Dto
    {
        public int linkline { get; set; }
        public string name { get; set; }
        public double[] coordinates { get; set; }
        public Basics basics { get; set; }
        public string source { get; set; }

    }

    public class Basics
    {
        public string date { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public bool flagged { get; set; }
        public string location { get; set; }
        public string[] results { get; set; }
    }
}
