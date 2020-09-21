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

        public WikiMap WikiMap { get; set; }

        private void TimeIndicator_OnDateChanged(int totalMonths)
        {
            WikiMap.UpdateTotalMonths(totalMonths);
        }
    }
}

