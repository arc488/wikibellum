using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wikibellum.Data.Data.IRepositiories;
using wikibellum.Entities;

namespace wikibellum.Data.Data
{
    public class EventAnonymousRepository : EventRepository, IEventAnonymousRepository
    {
        public EventAnonymousRepository(WikiContext context) : base(context)
        {
            
        }

        public async override Task<IEnumerable<Event>> GetAll()
        {
            var entries = _entries
                .Include(e => e.Location)
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
            var entries = _entries
                .Include(e => e.Location)
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

            return entries.FirstOrDefault(e => e.EventId == id);
        }

    }
}
