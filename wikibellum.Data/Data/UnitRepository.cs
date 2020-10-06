using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models;

namespace wikibellum.Data.Data
{
    public class UnitRepository : Repository<Unit>, IUnitRepository
    {
        public UnitRepository(WikiContext context) : base(context)
        {
        }
    }
}
