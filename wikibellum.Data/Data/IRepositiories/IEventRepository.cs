using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Data
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<EntityState> Update(Event entity);

    }
}
