using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models;

namespace wikibellum.Data.Data
{
    public class NationRepository : Repository<Nation>, INationRepository
    {
        public NationRepository(WikiContext context) : base(context)
        {
        }

        public async override Task<Nation> Get(int id)
        {

            var entry = _entries
                        .Include(n => n.Alliance)                           
                        .FirstOrDefault(n => n.NationId == id);
            return entry;
        }

        public async override Task<IEnumerable<Nation>> GetAll()
        {
            var entries = _entries
                            .Include(n => n.Alliance);
            return entries;
        }

    }
}
