using System.ComponentModel.DataAnnotations;

namespace wikibellum.Entities
{
    public class UnitStrength
    {
        [Key]
        public int Id { get; set; }
        public int Personnel { get; set; }
    }
}