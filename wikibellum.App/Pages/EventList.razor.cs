using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Services;
using wikibellum.Entities;

namespace wikibellum.App.Pages
{
    public partial class EventList : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private List<Event> _events;

        protected async override Task OnInitializedAsync()
        {
            _events = await EventDataService.GetAll();
        }

        protected void ShowDetails(int eventId)
        {
            NavigationManager.NavigateTo(string.Format("/modifyevent/{0}", eventId), false);
        }
    }
}
