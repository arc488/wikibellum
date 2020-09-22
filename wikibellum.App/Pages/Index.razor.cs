using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.Components;
using wikibellum.App.Helpers;
using wikibellum.App.Services;
using wikibellum.Entities;

namespace wikibellum.App.Pages
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

