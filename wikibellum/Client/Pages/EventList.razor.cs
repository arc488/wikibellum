using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Services;
using wikibellum.Entities;

namespace wikibellum.Client.Pages
{
    [Authorize]
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
