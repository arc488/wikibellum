using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.Client.Services;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Client.Services
{
    public class BranchDataService : DataService<Branch>, IBranchDataService
    {
        public BranchDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Branches";
        }
    }
}
