﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Components;
using wikibellum.Client.Services;
using wikibellum.Entities;
using wikibellum.Entities.Enums;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Client.Pages
{
    [Authorize]
    public partial class ModifyEvent : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        [Inject]
        public IEventParticipantDataService EventParticipantDataService { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }
        [Inject]
        public IResultDataService ResultDataService { get; set; }

        [Parameter]
        public int EventId { get; set; }

        public Event Event { get; set; }

        public int ParticipantIndex { get; set; }

        private List<Event> _events;

        protected async override Task OnInitializedAsync()
        {
            _events = await EventDataService.GetAll();
            if (EventId == 0)
            {
                Event = await EventDataService.Add(new Event());
            }
            else
            {
                Event = _events.FirstOrDefault(e => e.EventId == EventId);
            }

        }

        protected async void AddParticipant()
        {
            var newParticipant = await EventParticipantDataService.Add(new EventParticipant() { EventId = Event.EventId }  );
            Event.Participants.Add(newParticipant);

            await EventDataService.Update(Event.EventId, Event);
            StateHasChanged();
        }

        protected async void AddResult()
        {
            var result = await ResultDataService.Add(new Result() { EventId = Event.EventId });
            Event.Results.Add(result);
            await EventDataService.Update(Event.EventId, Event);
            StateHasChanged();
        }

        protected void UpdateLocationChanges()
        {
            LocationDataService.Update(Event.LocationId, Event.Location);
        }
        protected void UpdateEventChanges()
        {
            EventDataService.Update(Event.EventId, Event);
        }

        protected void UpdateResultChanges(Result result)
        {
            ResultDataService.Update(result.ResultId, result);
        }
        protected override void OnAfterRender(bool firstRender)
        {
            JSRuntime.InvokeVoidAsync("setBelligerentsHeight");
            
        }
    }
}
