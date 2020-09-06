using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models;

namespace wikibellum.Data.Data
{
    public class AllianceRepository : Repository<Alliance>, IAllianceRepository
    {
        public AllianceRepository(WikiContext context) : base(context)
        {
        }
    }
}
