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
    }
}
