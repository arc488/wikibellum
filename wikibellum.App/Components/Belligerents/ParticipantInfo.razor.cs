using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Entities;

namespace wikibellum.App.Components.Belligerents
{
    public partial class ParticipantInfo : ComponentBase
    {
        [Parameter]
        public EventParticipant Participant { get; set; }
    }
}
