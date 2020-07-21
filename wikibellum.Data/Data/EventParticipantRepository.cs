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
    }
}
