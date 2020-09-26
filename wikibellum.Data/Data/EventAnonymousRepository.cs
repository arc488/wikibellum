using IdentityServer4.Events;
using System;
using System.Collections.Generic;
using System.Text;
using wikibellum.Data.Data.IRepositiories;

namespace wikibellum.Data.Data
{
    public class EventAnonymousRepository : EventRepository, IEventAnonymousRepository
    {
        public EventAnonymousRepository(WikiContext context) : base(context)
        {
            
        }
        
    }
}
