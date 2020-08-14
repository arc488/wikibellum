using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Entities
{

    public class UnitLosses
    {
        [Key]
        public int Id { get; set; }
        public List<Loss> Losses { get; set; }
    }
}