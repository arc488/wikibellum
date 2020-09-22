using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.App.Services.Interfaces;
using wikibellum.Entities;

namespace wikibellum.App.Services.Implementation
{
    public class ResultDataService : DataService<Result>, IResultDataService
    {
        public ResultDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Results";
        }
    }
}
