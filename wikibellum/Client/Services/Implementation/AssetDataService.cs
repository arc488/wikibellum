using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using wikibellum.Client.Services;
using wikibellum.Entities.Models.Units;

namespace wikibellum.Client.Services
{
    public class AssetDataService : DataService<Asset>, IAssetDataService
    {
        public AssetDataService(HttpClient httpClient) : base(httpClient)
        {
            ControllerName = "Assets";
        }
    }
}
