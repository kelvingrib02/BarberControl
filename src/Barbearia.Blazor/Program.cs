using Barbearia.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddHttpClient<ClientesApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7284");
});

builder.Services.AddHttpClient<BarbeirosApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7284");
});

builder.Services.AddHttpClient<AgendamentosApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7284");
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();