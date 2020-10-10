using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Components;
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
        private ConfirmDelete ConfirmDelete { get; set; }
        protected async override Task OnInitializedAsync()
        {
            _events = await EventDataService.GetAll();
         
        }
        protected void Delete(int eventId)
        {
            ConfirmDelete.Show(eventId);
        }

        protected void ConfirmDelete_OnEventDeleted(int deletedId)
        {
            _events.Remove(_events.FirstOrDefault(e => e.EventId == deletedId));
            StateHasChanged();
        }
        protected void ShowDetails(int eventId)
        {
            NavigationManager.NavigateTo(string.Format("/modifyevent/{0}", eventId), false);
        }
    }
}
