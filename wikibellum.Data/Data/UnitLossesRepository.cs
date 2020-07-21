using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Data
{
    public class UnitLossesRepository : Repository<UnitLosses>, IUnitLossesRepository
    {
        public UnitLossesRepository(WikiContext context) : base(context)
        {
        }
    }
}
