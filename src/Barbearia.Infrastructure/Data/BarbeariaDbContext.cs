using Microsoft.EntityFrameworkCore;
using Barbearia.Domain.Entities;

namespace Barbearia.Infrastructure.Data
{
    public class BarbeariaDbContext : DbContext
    {
        public BarbeariaDbContext(DbContextOptions<BarbeariaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Barbeiro> Barbeiros { get; set; }
        public DbSet<Servico> Servicos { get; set; }
        public DbSet<Agendamento> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}