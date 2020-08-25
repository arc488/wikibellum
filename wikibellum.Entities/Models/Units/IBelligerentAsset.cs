using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Entities.Enums;

namespace wikibellum.Entities.Models.Units
{
    public interface IBelligerentAsset
    {
        public string Classification { get; set; }
        public Condition Condition { get; set; }
        public int Amount { get; set; }
    }
}
