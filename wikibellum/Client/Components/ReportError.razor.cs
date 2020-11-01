using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Services;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities.Models;

namespace wikibellum.Client.Components
{
    public partial class ReportError : ComponentBase
    {
        [Inject]
        public IEventAnonymousDataService IEventAnonymousDataService { get; set; }
        public Report Report { get; set; }
        private bool _show = false;

        public void Show(int eventId)
        {
            Report = new Report() { EventId = eventId };
            _show = true;
            StateHasChanged();
        }
        private void Cancel()
        {
            Report = null;
            _show = false;
        }
        private void Submit()
        {
            IEventAnonymousDataService.Add(Report);
            _show = false;
        }
    }
}
