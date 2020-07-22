using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Data
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(WikiContext context) : base(context)
        {
        }

        public override IEnumerable<Event> GetAll()
        {
            var entries = _entries.Include(e => e.Location).ToList();
            return entries;
        }
    }
}
