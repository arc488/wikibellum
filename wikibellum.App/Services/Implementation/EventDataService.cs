﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.App.Services.Implementation
{
    public class EventDataService : DataService<Event>, IEventDataService
    {
        public EventDataService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
