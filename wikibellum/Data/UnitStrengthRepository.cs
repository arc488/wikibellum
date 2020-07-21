using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Models;

namespace wikibellum.Data
{
    public class UnitStrengthRepository : Repository<UnitStrength>, IUnitStrengthRepository
    {
        public UnitStrengthRepository(WikiContext context) : base(context)
        {
        }
    }
}
