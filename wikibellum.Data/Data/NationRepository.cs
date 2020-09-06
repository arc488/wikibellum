using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models;

namespace wikibellum.Data.Data
{
    public class NationRepository : Repository<Nation>, INationRepository
    {
        public NationRepository(WikiContext context) : base(context)
        {
        }
    }
}
