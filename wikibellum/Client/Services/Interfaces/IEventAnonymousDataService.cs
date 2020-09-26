using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;
using wikibellum.Entities.ViewModels;

namespace wikibellum.Client.Services.Interfaces
{
    public interface IEventAnonymousDataService : IDataService<Event>
    {
        Task<List<EventMarker>> GetAll();

    }
}
