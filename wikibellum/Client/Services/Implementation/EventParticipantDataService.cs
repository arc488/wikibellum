using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities;

namespace wikibellum.Client.Services
{
    public class EventParticipantDataService : DataService<EventParticipant>, IEventParticipantDataService
    {
        public EventParticipantDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "EventParticipants";
        }
    }
}
