using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace armaschema.Parser
{
    public class Adder
    {
        public void ParseJson()
        {
            var jsonText = File.ReadAllText(@"F:\Projects\pythonscraper\db.json");
            JObject json = JObject.Parse(jsonText);
            List<Dto> dtos = new List<Dto>();
            Console.WriteLine("Hello World");
            foreach (var item in json)
            {
                var dto = JsonConvert.DeserializeObject<Dto>(item.Value.First.First.ToString());
                dtos.Add(dto);
                Console.WriteLine(dto);
            }

            foreach (var dto in dtos)
            {
                Console.WriteLine("---------");
                Console.WriteLine(dto.linkline);
                Console.WriteLine(dto.name);
                Console.WriteLine(dto.coordinates[0] + " " + dto.coordinates[1]);
                Console.WriteLine(dto.basics.start);
                Console.WriteLine(dto.basics.end);
                Console.WriteLine(dto.basics.flagged);
                Console.WriteLine(dto.basics.location);
                if (dto.basics.results != null)
                {
                    foreach (var item in dto.basics.results)
                    {
                        Console.WriteLine(item);
                    }
                }
                Console.WriteLine(dto.source);
            }
        }

    }

    public class Dto
    {
        public int linkline { get; set; }
        public string name { get; set; }
        public string[] coordinates { get; set; }
        public Basics basics { get; set; }
        public string source { get; set; }

    }

    public class Basics
    {
        public string date { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        public bool flagged { get; set; }
        public string location { get; set; }
        public string[] results { get; set; }
    }
}
