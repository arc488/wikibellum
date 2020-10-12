using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Components;
using wikibellum.Client.Helpers;
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
        private string _resultString;
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
            var newParticipant = await EventParticipantDataService.Add(new EventParticipant() { EventId = Event.EventId });
            Event.Participants.Add(newParticipant);
            UpdateEventChanges();
            StateHasChanged();
        }

        protected async Task AddResultToEvent(int id)
        {
            var result = _results.FirstOrDefault(r => r.ResultId == id);
            Event.Results.Add(result);
            UpdateEventChanges();
            StateHasChanged();
        }

        protected async Task CreateResult()
        {
            var result = await ResultDataService.Add(new Result { Description = _resultString });
            Event.Results.Add(result);
            UpdateEventChanges();
            _results = await ResultDataService.GetAll();
            StateHasChanged();

        }
        protected async Task DeleteResult(Result result)
        {
            Event.Results.Remove(result);
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

        protected override void OnAfterRender(bool firstRender)
        {
            JSRuntime.InvokeVoidAsync("setBelligerentsHeight");

        }

        private async void ConvertToCoordinates(string rawString)
        {
            Dictionary<string, double> coords = new Dictionary<string, double>();
            try
            {
                coords = Coordinates.ConvertCoordinates(rawString);
                Event.Location.Lat = coords["lat"];
                Event.Location.Long = coords["lng"];
            }
            catch (Exception e)
            {
                Debug.WriteLine("Could not parse these coordinates");
                Debug.WriteLine(e.Message);
            }
        }
        private async Task<IEnumerable<Result>> SearchResults(string searchText)
        {
            _resultString = searchText;
            return await Task.FromResult(_results.Where(x => x.Description.ToLower().StartsWith(searchText.ToLower())).ToList());
        }
    }
}