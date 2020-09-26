using System;
using System.Collections.Generic;
using System.Text;

namespace wikibellum.Entities.ViewModels
{
    public class EventMarker
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
