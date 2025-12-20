using System.Net.Http.Json;
using Barbearia.Blazor.Models;

namespace Barbearia.Blazor.Services;

public class ClientesApiService
{
    private readonly HttpClient _httpClient;

    public ClientesApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<List<Cliente>> GetClientesAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Cliente>>("api/clientes");
        return result ?? new List<Cliente>();
    }
    public async Task<Cliente?> GetClienteByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Cliente>($"api/clientes/{id}");
    }
    public async Task PostClienteAsync(Cliente cliente)
    {
        await _httpClient.PostAsJsonAsync("api/clientes", cliente);
    }
    public async Task UpdateClienteAsync(Cliente cliente)
    {
        await _httpClient.PutAsJsonAsync($"api/clientes/{cliente.Id}", cliente);
    }
    public async Task DeleteClienteAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/clientes/{id}");
    }
}