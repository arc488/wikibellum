using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Http;

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

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var response = await JsonSerializer.DeserializeAsync<IEnumerable<TEntity>>
                (await _httpClient.GetStreamAsync($"api/" + ControllerName), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }

        public async Task<TEntity> GetById(int id)
        {
            var response = await JsonSerializer.DeserializeAsync<TEntity>
                (await _httpClient.GetStreamAsync($"api/" + ControllerName + $"/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }
        
        public async Task Update(int id, TEntity entity)
        {
            var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/" + ControllerName, entityJson);
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var entityJson =
                new StringContent(JsonSerializer.Serialize(entity), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/" + ControllerName, entityJson);
            Debug.WriteLine("Response success: " + response.IsSuccessStatusCode.ToString());
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<TEntity>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task Delete(int entityId)
        {
            await _httpClient.DeleteAsync($"api/" + ControllerName + "/{entityId}");
        }

    }
}
