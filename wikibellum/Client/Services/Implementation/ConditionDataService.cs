using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Client.Services
{
    public class ConditionDataService : DataService<Condition>, IConditionDataService
    {
        public ConditionDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Conditions";
        }
    }
}
