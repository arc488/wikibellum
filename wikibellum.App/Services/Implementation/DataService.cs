using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace wikibellum.App.Services
{
    public class DataService<TEntity> : IDataService<TEntity> where TEntity : class
    {

        public string ControllerName { get; set; }

        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TEntity>> GetAll()
        {
            var stream = await _httpClient.GetStreamAsync($"api/" + ControllerName);

            var response = await JsonSerializer.DeserializeAsync<IEnumerable<TEntity>>
                (await _httpClient.GetStreamAsync($"api/" + ControllerName), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response.ToList();
        }

        public async Task<TEntity> GetById(int id)
        {
            var response = await JsonSerializer.DeserializeAsync<TEntity>
                (await _httpClient.GetStreamAsync($"api/" + ControllerName + $"/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            var stream = await _httpClient.GetStreamAsync($"api/" + ControllerName + $"/{id}");
            return response;
        }
        
        public async Task<HttpResponseMessage> Update(int id, TEntity entity)
        {
            var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/" + ControllerName + $"/{id}", entityJson);
            return response;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("api/" + ControllerName, entityJson);
            var content = await response.Content.ReadAsStringAsync();
            var entityObject = JsonConvert.DeserializeObject<TEntity>(content);
            return entityObject;
        }

        public async Task Delete(int entityId)
        {
            await _httpClient.DeleteAsync($"api/" + ControllerName + "/{entityId}");
        }

    }
}
