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
                .Include(e => e.Participants)
                    .ThenInclude(ep => ep.Assets)
                        .ThenInclude(a => a.Unit)
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
                        .ThenInclude(a => a.Unit)
                .Include(e => e.Participants)
                    .ThenInclude(e => e.Assets)
                        .ThenInclude(a => a.Condition)
                .Include(e => e.Participants)
                    .ThenInclude(e => e.Nation)
                .FirstOrDefault(e => e.EventId == id);
            return entry;
        }
        public override EntityState Delete(Event entity)
        {
            var entry = _context.Events
                .Include(e => e.Participants)
                    .ThenInclude(p => p.Assets)
                .FirstOrDefault(e => e.EventId == entity.EventId);
            var state = _context.Events.Remove(entry).State;
            _context.SaveChanges();
            return state;
        }
    }
}
