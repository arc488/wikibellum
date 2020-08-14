using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace wikibellum.App.Services
{
    public class DataService<TEntity> : IDataService<TEntity> where TEntity : class
    {

        private readonly HttpClient _httpClient;
        private readonly string _controllerName;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _controllerName = typeof(TEntity).Name + "s";
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            var response = await JsonSerializer.DeserializeAsync<IEnumerable<TEntity>>
                (await _httpClient.GetStreamAsync($"api/" + _controllerName), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }

        public async Task<TEntity> GetById(int id)
        {
            var response = await JsonSerializer.DeserializeAsync<TEntity>
                (await _httpClient.GetStreamAsync($"api/" + _controllerName + $"/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            return response;
        }
    }
}
