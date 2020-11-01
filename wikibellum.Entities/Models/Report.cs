using System;
using System.Collections.Generic;
using System.Text;

namespace wikibellum.Entities.Models
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Message { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
