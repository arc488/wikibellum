using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Models.ViewModels
{
    public class EventCreateViewModel
    {
        public EventCreateViewModel()
        {
            Location = new Location();
            Participants = new List<EventParticipant>();
        }

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
