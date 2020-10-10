using Microsoft.AspNetCore.Authorization;
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
        private List<Result> _results;
        private Result _selectedResult;

        protected async override Task OnInitializedAsync()
        {
            _results = await ResultDataService.GetAll();

            if (EventId == 0)
            {
                Event = await EventDataService.Add(new Event());
            }
            else
            {
                _events = await EventDataService.GetAll();
                Event = _events.FirstOrDefault(e => e.EventId == EventId);
            }

        }

        protected async void AddParticipant()
        {
            var newParticipant = await EventParticipantDataService.Add(new EventParticipant() { EventId = Event.EventId }  );
            Event.Participants.Add(newParticipant);
            UpdateEventChanges();
            StateHasChanged();
        }

        protected async void AddResult()
        {
            //var result = await ResultDataService.Add(new Result() { EventId = Event.EventId });
            Event.Results.Add(new Result());
            StateHasChanged();
        }

        protected async Task CreateResult(Guid guid)
        {
            var index = Event.Results.IndexOf(Event.Results.Find(r => r.Guid == guid));
            var currentValue = Event.Results[index].Description;
            var result = await ResultDataService.Add(new Result() { Description = currentValue, EventId = Event.EventId });
            Event.Results[index] = result;
            UpdateEventChanges();
            StateHasChanged();

        }

        protected async Task DeleteResult(int id)
        {
            await ResultDataService.Delete(id);
            Event.Results.Remove(Event.Results.Find(r => r.ResultId == id));
            UpdateEventChanges();
            StateHasChanged();
        }

        protected void UpdateLocationChanges()
        {
            LocationDataService.Update(Event.LocationId, Event.Location);
        }

        protected void UpdateSource()
        {
            EventDataService.Update(Event.LocationId, Event);
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
        private async Task<IEnumerable<Result>> SearchResults(string searchText)
        {
            return await Task.FromResult(_results.Where(x => x.Description.ToLower().StartsWith(searchText.ToLower())).ToList());
        }
    }
}
