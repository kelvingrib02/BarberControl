namespace Barbearia.Blazor.Models;

public class Barbeiro
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Especialidades { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}