using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Result { get; set; }
        public Location Location { get; set; }
        public List<EventParticipant> Participants { get; set; }
        public string Description { get; set; }
        public BookRecommendation Reccomendation { get; set; }
    }
}
