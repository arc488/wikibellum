using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.App.TestModels;

namespace wikibellum.App.Pages
{
    partial class SimpleList : ComponentBase
    {

        public Primary Primary { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Primary = new Primary
            {
                Secondaries = new List<Secondary>()
            };
        }

        protected void AddSecondary()
        {
            Primary.Secondaries.Add(new Secondary());
            StateHasChanged();

        }

        protected void HandleValidSubmit()
        {

        }
    }
}
