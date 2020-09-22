using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using wikibellum.App.Helpers;
using wikibellum.App.Services;
using wikibellum.Entities;

namespace wikibellum.App.Components
{
    public partial class WikiMap : ComponentBase
    {
        [Inject]
        private IEventDataService EventDataService { get; set; }
        [Inject]
        private DateHelpers DateHelpers { get; set; }
        [Parameter]
        public EventCallback<int> EventSelectedEventCallback { get; set; }
        public int CurrentEventId 
        {
            get
            {
                return _currentEventId;
            }
            set
            {
                _currentEventId = value;
                EventSelectedEventCallback.InvokeAsync(_currentEventId);
            } 
        }
        private int _currentEventId = 0;
        private int _totalMonths = 13;
        private IEnumerable<Event> _events;
        private bool _shouldRender;

        protected async override Task OnInitializedAsync()
        {
            _totalMonths = 13;
            _events = await EventDataService.GetAll();
            _shouldRender = true;
        }

        protected override bool ShouldRender()
        {
            return _shouldRender;
        }

        protected override void OnAfterRender(bool firstRender)
        {

            if (_events != null)
            {
                JSRuntime.InvokeVoidAsync("map");
                _shouldRender = false;
            }
        }

        public void UpdateTotalMonths(int totalMonths)
        {
            _totalMonths = totalMonths;
            OnDateChanged();
        }
        protected void OnDateChanged()
        {
            AddNewMarkers();
        }

        protected void AddNewMarkers()
        {
            var currentEvents = new List<Event>();
            foreach (var item in _events)
            {
                if (DateHelpers.DateIsWithinBounds(_totalMonths, item.Start, item.End))
                {
                    currentEvents.Add(item);
                }
            }

            JSRuntime.InvokeVoidAsync("removeAllMarkers");
            JSRuntime.InvokeVoidAsync("addCurrentEvents", currentEvents);

        }
    }
}
