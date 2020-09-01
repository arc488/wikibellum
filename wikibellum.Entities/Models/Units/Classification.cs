using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace wikibellum.Entities.Models.Units
{
    public class Classification
    {
        [Key]
        public int ClassificationId { get; set; }
        public string FullName { get; set; }
        public string AbbrName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
