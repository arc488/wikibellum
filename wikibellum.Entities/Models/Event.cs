using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Entities
{
    public class Event
    {
        public Event()
        {
            Location = new Location();
            Participants = new List<EventParticipant>();
        }

        [Key]
        public int EventId { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Location? Location { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public List<EventParticipant> Participants { get; set; }
        public string Description { get; set; }
        public BookRecommendation Reccomendation { get; set; }
        public string FileName { get; set; }
        public List<Result> Results { get; set; }


    }
}
