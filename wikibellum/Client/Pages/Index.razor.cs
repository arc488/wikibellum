using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Components;
using wikibellum.Client.Helpers;
using wikibellum.Client.Services;
using wikibellum.Entities;

namespace wikibellum.Client.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        private IEventDataService EventDataService { get; set; }
        private WikiMap WikiMap { get; set; }

        private EventDetail EventDetail { get; set; }

        private Event _currentEvent;
        private void TimeIndicator_OnDateChanged(int totalMonths)
        {
            WikiMap.UpdateTotalMonths(totalMonths);
        }
       
        private async void WikiMap_OnEventSelected(int id)
        {
            _currentEvent = await EventDataService.GetById(id);
            EventDetail.DisplayEventDetail(_currentEvent);
        }
    }
}

