namespace Barbearia.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string Telefone { get; set; } = null!;
    public string? Email { get; set; }
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}