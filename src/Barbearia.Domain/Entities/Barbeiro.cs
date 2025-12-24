namespace Barbearia.Domain.Entities;

public class Barbeiro
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Especialidade { get; set; } = string.Empty;
    public bool Ativo { get; set; } = true;
    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}