using Microsoft.EntityFrameworkCore;
using Barbearia.Domain.Entities;

namespace Barbearia.Infrastructure.Data;

public class BarbeariaDbContext : DbContext
{
    public BarbeariaDbContext(DbContextOptions<BarbeariaDbContext> options)
        : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Barbeiro> Barbeiros => Set<Barbeiro>();
    public DbSet<Servico> Servicos => Set<Servico>();
    public DbSet<Agendamento> Agendamentos => Set<Agendamento>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.Property(c => c.Nome)
                  .IsRequired()
                  .HasMaxLength(150);

            entity.Property(c => c.Telefone)
                  .IsRequired()
                  .HasMaxLength(20);
        });
    }
}