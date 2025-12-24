namespace Barbearia.Blazor.Models;

public class Barbeiro
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
}