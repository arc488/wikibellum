using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace wikibellum.Entities.Models.Units
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string Name { get; set; }

    }
}
