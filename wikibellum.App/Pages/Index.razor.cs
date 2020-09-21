using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Helpers;
using wikibellum.App.Services;
using wikibellum.Entities;

namespace wikibellum.App.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }

        public int TotalMonths { get; set; }

        private IEnumerable<Event> _events;

        private IEnumerable<Event> _currentEvents;

        protected async override Task OnInitializedAsync()
        {
            TotalMonths = 13;
            _events = await EventDataService.GetAll();
        }

        protected override void OnAfterRender(bool firstRender)
        {
            if (_events != null)
            {
                JSRuntime.InvokeVoidAsync("map");
                JSRuntime.InvokeVoidAsync("addMarkers", _events);
            }
        }

        public void TimeIndicator_OnDateChanged(int totalMonths)
        {
            TotalMonths = totalMonths;
            DrawMarkers();
        }

        public void DrawMarkers()
        {
            _currentEvents = _events.Where(e => new DateHelpers().DateIsWithinBounds(TotalMonths, e.Start, e.End));
            JSRuntime.InvokeVoidAsync("addMarkers", _currentEvents);
        }
    }
}
