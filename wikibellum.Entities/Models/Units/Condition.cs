using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace wikibellum.Entities.Models.Units
{
    public class Condition
    {
        public int ConditionId { get; set; }
        [NotMapped]
        public string ConditionIdString { get; set; }
        public string Name { get; set; }
    }
}
