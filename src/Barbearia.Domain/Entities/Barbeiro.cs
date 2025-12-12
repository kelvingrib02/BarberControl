namespace Barbearia.Domain.Entities;

public class Barbeiro
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Especialidades { get; set; }
    public bool Ativo { get; set; } = true;

    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}