using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //[Inject]
        //public JSRuntime JSRuntime { get; set; }
        //public int TotalMonths
        //{
        //    get
        //    {
        //        return _totalMonths;
        //    }
        //    set
        //    {
        //        _totalMonths = value;
                
        //        //OnDateChanged(value);
        //    }
        //}
        private int _totalMonths = 13;
        private IEnumerable<Event> _events;
        private bool _shouldRender;

        public void UpdateTotalMonths(int totalMonths)
        {
            _totalMonths = totalMonths;
            OnDateChanged();
        }
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
                //JSRuntime.InvokeVoidAsync("addMarkers", _events);
                _shouldRender = false;
            }
        }

        protected void OnDateChanged()
        {
            SetMarkerVisibility();
        }

        protected void SetMarkerVisibility()
        {
            var currentEvents = new List<Event>();
            foreach (var item in _events)
            {
                if (DateHelpers.DateIsWithinBounds(_totalMonths, item.Start, item.End))
                {
                    currentEvents.Add(item);
                }
            }

            //JSRuntime.InvokeVoidAsync("setHidden");
            //JSRuntime.InvokeVoidAsync("setVisible", currentEvents);
            JSRuntime.InvokeVoidAsync("removeAllMarkers");
            JSRuntime.InvokeVoidAsync("addCurrentEvents", currentEvents);

        }
    }
}
