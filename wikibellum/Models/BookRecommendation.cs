using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Models
{
    public class BookRecommendation
    {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
    }
}
