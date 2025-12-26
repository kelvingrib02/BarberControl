using System.Net.Http.Json;
using Barbearia.Blazor.Models;

namespace Barbearia.Blazor.Services
{
    public class AgendamentosApiService
    {
        private readonly HttpClient _httpClient;

        public AgendamentosApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Agendamento>> GetAgendamentosAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Agendamento>>("api/agendamentos");
            return result ?? new List<Agendamento>();
        }

        public async Task<Agendamento?> GetAgendamentoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Agendamento>($"api/agendamentos/{id}");
        }

        public async Task PostAgendamentoAsync(Agendamento agendamento)
        {
            await _httpClient.PostAsJsonAsync("api/agendamentos", agendamento);
        }

        public async Task UpdateAgendamentoAsync(Agendamento agendamento)
        {
            await _httpClient.PutAsJsonAsync($"api/agendamentos/{agendamento.Id}", agendamento);
        }

        public async Task DeleteAgendamentoAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/agendamentos/{id}");
        }
    }
}