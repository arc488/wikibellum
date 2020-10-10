using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wikibellum.Client.Components
{
    public class Simple
    {
        public int SimpleId { get; set; }
        public int TestId { get; set; }
        public Test Test { get; set; }
    }
    public class Test
    {
        public int TestId { get; set; }
        public string Name { get; set; }

        public void AddNewSimple()
        {
            var simple = new Simple
            {
                SimpleId = 11,
                TestId = 1
            };
        }
    }
}
