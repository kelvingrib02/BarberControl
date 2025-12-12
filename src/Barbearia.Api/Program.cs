using Barbearia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BarbeariaDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapControllers();

app.Run();