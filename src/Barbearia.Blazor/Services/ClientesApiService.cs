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
}