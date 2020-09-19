using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using wikibellum.App.Services;
using wikibellum.App.Services.Implementation;
using wikibellum.App.Services.Interfaces;

namespace wikibellum.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            //builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<IEventDataService, EventDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<IClassificationDataService, ClassificationDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<IBranchDataService, BranchDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<IEventParticipantDataService, EventParticipantDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<IConditionDataService, ConditionDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<INationDataService, NationDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<IAllianceDataService, AllianceDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<IAssetDataService, AssetDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));
            builder.Services.AddHttpClient<ILocationDataService, LocationDataService>(client => client.BaseAddress = new Uri("https://localhost:44308/"));

            await builder.Build().RunAsync();
        }
    }
}
