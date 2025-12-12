namespace Barbearia.Domain.Entities;

public class Servico
{
    public int Id { get; set; }
    public string Nome { get; set; } = null!;
    public string? Descricao { get; set; }
    public int DuracaoMinutos { get; set; }
    public decimal Preco { get; set; }

    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
}