using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Models
{
    public class EventParticipant
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public UnitStrength Strength { get; set; }
        public UnitLosses Losses { get; set; }

    }
}
