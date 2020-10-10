using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wikibellum.Client.Services;
using wikibellum.Entities;

namespace wikibellum.Client.Components.Internal
{
    public partial class ResultSearch : ComponentBase
    {
        [Inject]
        public IResultDataService ResultDataService { get; set; }

        private List<Result> _results;
        private Result _selectedResult;

        protected async override Task OnInitializedAsync()
        {
            _results = await ResultDataService.GetAll();
        }

        private async Task<IEnumerable<Result>> SearchResults(string searchText)
        {
            return await Task.FromResult(_results.Where(x => x.Description.ToLower().StartsWith(searchText.ToLower())).ToList());
        }
    }
}
