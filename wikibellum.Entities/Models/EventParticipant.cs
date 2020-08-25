using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Entities
{
    public class EventParticipant
    {
        public EventParticipant()
        {
            Strength = new List<Asset>();
            Losses = new List<Asset>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Asset> Strength { get; set; }
        public List<Asset> Losses { get; set; }

    }
}
