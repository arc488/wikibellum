using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities.Models;

namespace wikibellum.App.Services.Implementation
{
    public class NationDataService : DataService<Nation>, INationDataService
    {
        public NationDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Nations";
        }
    }
}
