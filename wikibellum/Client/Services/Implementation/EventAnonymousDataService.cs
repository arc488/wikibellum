using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using wikibellum.Client.Services.Interfaces;
using wikibellum.Entities;
using wikibellum.Entities.Models;
using wikibellum.Entities.ViewModels;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace wikibellum.Client.Services.Implementation
{
    public class EventAnonymousDataService : DataService<Event>, IEventAnonymousDataService
    {
        public EventAnonymousDataService(HttpClient httpClient, IHttpClientFactory clientFactory) : base(httpClient)
        {
            ControllerName = "EventsAnonymous";
            _httpClient = clientFactory.CreateClient("wikibellum.ServerAPI.NoAuthenticationClient");

        }

        public async Task<EntityState> Add(Report report)
        {
            var entityJson =
                new StringContent(JsonSerializer.Serialize(report), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/" + ControllerName, entityJson);
            var content = await response.Content.ReadAsStringAsync();
            var state = JsonConvert.DeserializeObject<EntityState>(content);
            return state;
        }

        new public async Task<List<EventMarker>> GetAll()
        {
            var response = await JsonSerializer.DeserializeAsync<IEnumerable<EventMarker>>
                (await _httpClient.GetStreamAsync($"api/" + ControllerName), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response.ToList();
        }
    }
}
