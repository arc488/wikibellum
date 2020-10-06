using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities.Models;

namespace wikibellum.Client.Services.Implementation
{
    public class UnitDataService : DataService<Unit>, IUnitDataService
    {
        public UnitDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Units";
        }
    }
}
