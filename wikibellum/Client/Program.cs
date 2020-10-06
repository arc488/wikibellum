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
using wikibellum.Client.Services.Interfaces;
using wikibellum.Client.Services.Implementation;

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

            builder.Services.AddHttpClient("wikibellum.ServerAPI.NoAuthenticationClient",
                client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("wikibellum.ServerAPI"));

            builder.Services.AddApiAuthorization();


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
            builder.Services.AddTransient<IEventAnonymousDataService, EventAnonymousDataService>();
            builder.Services.AddTransient<IOrganizationDataService, OrganizationDataService>();
            builder.Services.AddTransient<IUnitDataService, UnitDataService>();

            builder.Services.AddSingleton<DateHelpers>();

            await builder.Build().RunAsync();
        }
    }
}
