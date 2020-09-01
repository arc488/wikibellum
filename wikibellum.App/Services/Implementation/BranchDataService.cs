using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities.Models.Units;

namespace wikibellum.App.Services.Implementation
{
    public class BranchDataService : DataService<Branch>, IBranchDataService
    {
        public BranchDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Branches";
        }
    }
}
