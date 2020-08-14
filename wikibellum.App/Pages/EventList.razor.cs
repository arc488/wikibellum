using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Services;
using wikibellum.Entities;

namespace wikibellum.App.Pages
{
    partial class EventList : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        public IEnumerable<Event> Events { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Events = (await EventDataService.GetAll()).ToList();

        }
    }
}
