using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wikibellum.Models
{
    public class UnitLosses
    {
        [Key]
        public int Id { get; set; }
        public int Dead { get; set; }
        public int Wounded { get; set; }
        public int Captured { get; set; }
        public int Missing { get; set; }
    }
}