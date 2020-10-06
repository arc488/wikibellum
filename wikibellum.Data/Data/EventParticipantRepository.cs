using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Data
{
    public class EventParticipantRepository : Repository<EventParticipant>, IEventParticipantRepository
    {
        public EventParticipantRepository(WikiContext context) : base(context)
        {

        }

        public async override Task<EventParticipant> Get(int id)
        {
            var entry = _entries
                .Include(e => e.Assets)
                    .ThenInclude(a => a.Unit)
                .Include(e => e.Assets)
                    .ThenInclude(a => a.Condition)
                .Include(e => e.Assets)
                    .ThenInclude(a => a.Organization)
                .Include(e => e.Nation)
                .FirstOrDefault(e => e.EventParticipantId == id);
            return entry;
        }

        public async override Task<IEnumerable<EventParticipant>> GetAll()
        {
            var entries = _entries
                .Include(e => e.Assets)
                    .ThenInclude(a => a.Unit)
                .Include(e => e.Assets)
                    .ThenInclude(a => a.Condition)
                .Include(e => e.Assets)
                    .ThenInclude(a => a.Organization)
                .Include(e => e.Nation)
                .ToList();
            return entries;
        }
    }
}
