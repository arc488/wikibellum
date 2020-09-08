using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Components;
using wikibellum.App.Services;
using wikibellum.Entities;
using wikibellum.Entities.Enums;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Pages
{
    public partial class AddEvent : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        public Event Event { get; set; }

        public int ParticipantIndex { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var newEvent = new Event()
            {
                Title = DateTime.Today.ToShortDateString(),
                End = DateTime.Now,
                Start = DateTime.Now,
                Location = new Location(),
                Participants = new List<EventParticipant>()

            };
            Event = await EventDataService.Add(newEvent);
            Debug.WriteLine("EventId on initialized: " + Event.EventId);

        }

        protected async void AddParticipant()
        {
            Event.Participants.Add(new EventParticipant());
            Debug.Write("EventId is: " + Event.EventId);
            await EventDataService.Update(Event.EventId, Event);
            StateHasChanged();
        }

        protected void HandleValidSubmit()
        {

        }

        protected void HandleInvalidSubmit()
        {

        }

        protected override void OnAfterRender(bool firstRender)
        {
            JSRuntime.InvokeVoidAsync("setBelligerentsHeight");
            
        }
    }
}
