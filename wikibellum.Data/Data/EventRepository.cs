using Microsoft.AspNetCore.Authorization;
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

        public async override Task<IEnumerable<Event>> GetAll()
        {
            var entries = _entries.Include(e => e.Location)
                .Include(e => e.Results)
                .Include(e => e.Participants)
                    .ThenInclude(ep => ep.Assets)
                    .ThenInclude(a => a.Classification)
                .Include(e => e.Participants)
                    .ThenInclude(e => e.Assets)
                    .ThenInclude(a => a.Condition)
                .Include(e => e.Participants)
                    .ThenInclude(e => e.Nation)
                .ToList();
            return entries;
        }

        public async override Task<Event> Get(int id)
        {
            var entry = _entries.Include(e => e.Location)
                .Include(e => e.Results)
                .Include(e => e.Participants)
                    .ThenInclude(ep => ep.Assets)
                    .ThenInclude(a => a.Classification)
                .Include(e => e.Participants)
                    .ThenInclude(e => e.Assets)
                    .ThenInclude(a => a.Condition)
                .Include(e => e.Participants)
                    .ThenInclude(e => e.Nation)
                .FirstOrDefault(e => e.EventId == id);
            return entry;
        }
    }
}
