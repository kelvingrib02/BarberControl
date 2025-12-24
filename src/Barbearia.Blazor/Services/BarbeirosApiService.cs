using System.Net.Http.Json;
using Barbearia.Blazor.Models;

namespace Barbearia.Blazor.Services
{
    public class BarbeirosApiService
    {
        private readonly HttpClient _httpClient;

        public BarbeirosApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Barbeiro>> GetBarbeirosAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Barbeiro>>("api/barbeiros");
            return result ?? new List<Barbeiro>();
        }

        public async Task<Barbeiro?> GetBarbeiroByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Barbeiro>($"api/barbeiros/{id}");
        }

        public async Task PostBarbeiroAsync(Barbeiro barbeiro)
        {
            await _httpClient.PostAsJsonAsync("api/barbeiros", barbeiro);
        }

        public async Task UpdateBarbeiroAsync(Barbeiro barbeiro)
        {
            await _httpClient.PutAsJsonAsync($"api/barbeiros/{barbeiro.Id}", barbeiro);
        }

        public async Task DeleteBarbeiroAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/barbeiros/{id}");
        }
    }
}