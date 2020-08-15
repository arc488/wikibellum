using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Entities
{
    public class UnitStrength
    {
        [Key]
        public int Id { get; set; }
        public List<IBelligerentUnit> Assets { get; set; }
    }
}