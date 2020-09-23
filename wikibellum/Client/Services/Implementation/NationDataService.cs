using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities.Models;

namespace wikibellum.Client.Services
{
    public class NationDataService : DataService<Nation>, INationDataService
    {
        public NationDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Nations";
        }
    }
}
