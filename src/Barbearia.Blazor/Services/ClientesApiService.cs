using System.Net.Http.Json;
using Barbearia.Blazor.Models;

namespace Barbearia.Blazor.Services;

public class ClientesApiService
{
    private readonly HttpClient _httpClient;

    public ClientesApiService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("Api");
    }

    public async Task<List<Cliente>> GetClientesAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Cliente>>("api/clientes");
        return result ?? [];
    }
}