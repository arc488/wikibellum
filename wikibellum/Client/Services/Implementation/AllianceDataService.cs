using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities.Models;

namespace wikibellum.Client.Services
{
    public class AllianceDataService : DataService<Alliance>, IAllianceDataService
    {
        public AllianceDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Alliances";
        }
    }
}
