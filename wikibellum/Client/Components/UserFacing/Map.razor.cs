using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Helpers;
using wikibellum.Entities.ViewModels;

namespace wikibellum.Client.Components.UserFacing
{
    public partial class Map : ComponentBase
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
        private int _totalMonths = 13;
        private bool _shouldRender;

        protected async override Task OnInitializedAsync()
        {
            _totalMonths = 13;
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
                Runtime.InvokeVoidAsync("map");
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
            var currentEvents = new List<EventMarker>();
            foreach (var item in EventMarkers)
            {
                if (DateHelpers.DateIsWithinBounds(_totalMonths, item.Start, item.End))
                {
                    currentEvents.Add(item);
                }
            }
            Runtime.InvokeVoidAsync("removeAllMarkers");
            Runtime.InvokeVoidAsync("addCurrentEvents", currentEvents);

        }
    }
}