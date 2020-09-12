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
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities;
using wikibellum.Entities.Enums;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Pages
{
    public partial class AddEvent : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        [Inject]
        public IEventParticipantDataService EventParticipantDataService { get; set; }

        public Event Event { get; set; }

        public int ParticipantIndex { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Event = await EventDataService.Add(new Event());

        }

        protected async void AddParticipant()
        {
            var newParticipant = await EventParticipantDataService.Add(new EventParticipant() { EventId = Event.EventId }  );
            Event.Participants.Add(newParticipant);

            await EventDataService.Update(Event.EventId, Event);
            StateHasChanged();
        }

        protected void HandleValidSubmit()
        {

        }

        protected void HandleInvalidSubmit()
        {

        }
        protected void UpdateChanges()
        {
            EventDataService.Update(Event.EventId, Event);
        }
        protected override void OnAfterRender(bool firstRender)
        {
            JSRuntime.InvokeVoidAsync("setBelligerentsHeight");
            
        }
    }
}
