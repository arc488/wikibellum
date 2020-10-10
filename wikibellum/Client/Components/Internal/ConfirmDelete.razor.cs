using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Services;

namespace wikibellum.Client.Components
{
    public partial class ConfirmDelete : ComponentBase
    {
        [Inject]
        public IEventDataService EventDataService { get; set; }
        [Parameter]
        public EventCallback<int> DeleteConfirmationEventCallback { get; set; }
        private int _eventId;
        private bool _show = false;

        public void Show(int eventId)
        {
            _eventId = eventId;
            _show = true;
        }
        private void Cancel()
        {
            _eventId = 0;
            _show = false;
        }
        private void Delete()
        {
            EventDataService.Delete(_eventId);
            _show = false;
            DeleteConfirmationEventCallback.InvokeAsync(_eventId);
        }
    }
}
