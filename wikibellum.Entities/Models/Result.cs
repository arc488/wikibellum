using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace wikibellum.Entities
{
    public class Result
    {
        public int ResultId { get; set; }
        public string Description { get; set; }
        public int EventId { get; set; }
        [NotMapped]
        public Guid Guid { get; set; } = new Guid();

    }
}
