using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace wikibellum.Entities.Models
{
    public class Nation
    {
        public int NationId { get; set; }
        public string Name { get; set; }
        [ForeignKey("AllianceId")]
        public Alliance Alliance { get; set; }
        public int AllianceId { get; set; }
    }
}
