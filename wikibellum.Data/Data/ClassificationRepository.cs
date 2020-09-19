using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Data.Data
{
    public class ClassificationRepository : Repository<Classification>, IClassificationRepository
    {
        public ClassificationRepository(WikiContext context) : base(context)
        {
        }

        public async override Task<Classification> Get(int id)
        {
            var entry = await _entries.Include(c => c.Branch)
                .FirstOrDefaultAsync(c => c.ClassificationId == id);
            return entry;
        }

        public async override Task<IEnumerable<Classification>> GetAll()
        {
            var entries = await _entries.Include(c => c.Branch)
                .ToListAsync();
            return entries;
        }
    }
}
