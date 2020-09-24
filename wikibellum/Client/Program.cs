using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using wikibellum.Client.Services;
using wikibellum.Client.Helpers;

namespace wikibellum.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddHttpClient("wikibellum.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("wikibellum.ServerAPI"));

            builder.Services.AddApiAuthorization();

            string serverAddress = "https://localhost:44331/";
            //builder.Services.AddHttpClient<IEventDataService, EventDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<IClassificationDataService, ClassificationDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<IBranchDataService, BranchDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<IEventParticipantDataService, EventParticipantDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<IConditionDataService, ConditionDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<INationDataService, NationDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<IAllianceDataService, AllianceDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<IAssetDataService, AssetDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<ILocationDataService, LocationDataService>(client => client.BaseAddress = new Uri(serverAddress));
            //builder.Services.AddHttpClient<IResultDataService, ResultDataService>(client => client.BaseAddress = new Uri(serverAddress));
            builder.Services.AddTransient<IEventDataService, EventDataService>();
            builder.Services.AddTransient<IClassificationDataService, ClassificationDataService>();
            builder.Services.AddTransient<IBranchDataService, BranchDataService>();
            builder.Services.AddTransient<IEventParticipantDataService, EventParticipantDataService>();
            builder.Services.AddTransient<IConditionDataService, ConditionDataService>();
            builder.Services.AddTransient<INationDataService, NationDataService>();
            builder.Services.AddTransient<IAllianceDataService, AllianceDataService>();
            builder.Services.AddTransient<IAssetDataService, AssetDataService>();
            builder.Services.AddTransient<ILocationDataService, LocationDataService>();
            builder.Services.AddTransient<IResultDataService, ResultDataService>();

            builder.Services.AddSingleton<DateHelpers>();

            await builder.Build().RunAsync();
        }
    }
}