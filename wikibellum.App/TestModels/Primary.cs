using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.App.TestModels
{
    public class Primary
    {
        public string Title { get; set; }
        public List<Secondary> Secondaries { get; set; }
    }
}
