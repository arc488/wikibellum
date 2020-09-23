using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.Client.Components
{
    public partial class EventDetail : ComponentBase
    {
        [Parameter]
        public string DateFormat { get; set; }
        private Event _currentEvent;

        public void DisplayEventDetail(Event currentEvent)
        {
            _currentEvent = currentEvent;
            StateHasChanged();
        }
    }
}
