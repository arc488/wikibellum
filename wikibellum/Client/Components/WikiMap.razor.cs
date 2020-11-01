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
using wikibellum.Client.Helpers;
using wikibellum.Client.Services;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities;
using wikibellum.Entities.ViewModels;

namespace wikibellum.Client.Components
{
    public partial class WikiMap : ComponentBase
    {
        [CascadingParameter]
        protected List<EventMarker> EventMarkers { get; set; }
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
        private bool _shouldRender;
        public DateTime CurrentDate { get; set; } = new DateTime(1939, 1, 1);

        protected async override Task OnInitializedAsync()
        {
            _shouldRender = true;
        }

        protected override bool ShouldRender()
        {
            return _shouldRender;
        }

        protected override void OnAfterRender(bool firstRender)
        {

            if (EventMarkers != null)
            {
                JSRuntime.InvokeVoidAsync("map");
                _shouldRender = false;
            }
        }

        public void OnDateChanged(DateChangeData data)
        {
            CurrentDate = data.Date;
            AddNewMarkers(data);
        }

        protected void AddNewMarkers(DateChangeData data)
        {
            var currentEvents = new List<EventMarker>();
            foreach (var item in EventMarkers)
            {
                if (IsWithinBounds(data, item))
                {
                    currentEvents.Add(item);
                }
            }

            JSRuntime.InvokeVoidAsync("removeAllMarkers");
            JSRuntime.InvokeVoidAsync("addCurrentEvents", currentEvents);

        }

        protected bool IsWithinBounds(DateChangeData data, EventMarker marker)
        {
           
            Dictionary<string, int> bounds = new Dictionary<string, int>();
            DateTime date = data.Date;
            int asDays = (int)TimeSpan.FromTicks(date.Ticks).TotalDays;

            if (data.Mode == IndicatorMode.Months)
            {
                DateTime monthStart = new DateTime(marker.Start.Year, marker.Start.Month, 1);
                DateTime monthEnd = new DateTime(marker.End.Year, marker.End.Month, DateTime.DaysInMonth(marker.End.Year, marker.End.Month));
                int lower = (int)TimeSpan.FromTicks(monthStart.Ticks).TotalDays;
                int upper = (int)TimeSpan.FromTicks(monthEnd.Ticks).TotalDays;
                bounds.Add("lower", lower);
                bounds.Add("upper", upper); 
            }
            else if (data.Mode == IndicatorMode.Days)
            {
                int lower = (int)TimeSpan.FromTicks(marker.Start.Ticks).TotalDays;
                int upper = (int)TimeSpan.FromTicks(marker.End.Ticks).TotalDays;
                bounds.Add("lower", lower);
                bounds.Add("upper", upper); 
            }

            if (bounds["lower"] <= asDays && asDays <= bounds["upper"])
            {
                return true;
            }

            return false;
        }
    }
}
