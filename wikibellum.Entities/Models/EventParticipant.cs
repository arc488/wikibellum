using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities.Models;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Entities
{
    public class EventParticipant
    {
        public EventParticipant()
        {
            Assets = new List<Asset>();
        }

        [Key]
        public int EventParticipantId { get; set; }
        public Nation Nation { get; set; }
        public int NationId { get; set; }
        [NotMapped]
        public string NationIdString { get; set; }
        public List<Asset> Assets { get; set; }
        public int EventId { get; set; }

    }
}
