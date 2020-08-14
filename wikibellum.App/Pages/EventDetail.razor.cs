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
    partial class EventDetail : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        public Event Event { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Event = await EventDataService.GetById(1120);

        }
    }
}
