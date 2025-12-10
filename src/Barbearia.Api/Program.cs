using Barbearia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Connection string vinda do appsettings.json
var connectionString = builder.Configuration.GetConnectionString("BarbeariaConnection");

builder.Services.AddDbContext<BarbeariaDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// resto da configuração...

app.Run();