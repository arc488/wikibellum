using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace wikibellum.Entities.Models.Units
{
    public class Organization
    {
        [Key]
        public int OrganizationId { get; set; }
        [NotMapped]
        public string OrganizationIdString { get; set; }
        public string Singular { get; set; }
        public string Plural { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }
    }

}
