using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Components.UserFacing;
using wikibellum.Client.Helpers;
using wikibellum.Client.Services;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities;
using wikibellum.Entities.ViewModels;

namespace wikibellum.Client.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private IEventAnonymousDataService EventAnonymousDataService { get; set; }
        private Map WikiMap { get; set; }

        private EventDetail EventDetail { get; set; }

        private Event _currentEvent;
        private List<EventMarker> _eventMarkers;

        protected async override Task OnInitializedAsync()
        {
            _eventMarkers = await EventAnonymousDataService.GetAll();
        }
        private void TimeIndicator_OnDateChanged(int totalMonths)
        {
            WikiMap.UpdateTotalMonths(totalMonths);
        }
       
        private async void WikiMap_OnEventSelected(int id)
        {
            _currentEvent = await EventAnonymousDataService.GetById(id);
            
            EventDetail.DisplayEventDetail(_currentEvent);
        }
    }
}

