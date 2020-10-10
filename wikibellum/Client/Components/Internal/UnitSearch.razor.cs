using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Services;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities.Models;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Client.Components
{
    public partial class UnitSearch : ComponentBase
    {
        [Inject]
        public IUnitDataService UnitDataService { get; set; }

        private List<Unit> _units;
        private Unit _selectedUnit;

        protected async override Task OnInitializedAsync()
        {
            _units = await UnitDataService.GetAll();
        }

        private async Task<IEnumerable<Unit>> SearchClassifications(string searchText)
        {
            return await Task.FromResult(_units.Where(x => x.Name.ToLower().StartsWith(searchText.ToLower())).ToList());
        }
    }
}
