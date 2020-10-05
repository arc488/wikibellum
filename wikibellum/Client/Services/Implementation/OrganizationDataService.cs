using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Client.Services.Implementation
{
    public class OrganizationDataService : DataService<Organization>, IOrganizationDataService
    {
        public OrganizationDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Organizations";
        }
    }
}
