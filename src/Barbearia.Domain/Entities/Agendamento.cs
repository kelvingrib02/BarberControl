namespace Barbearia.Domain.Entities;

public class Agendamento
{
    public int Id { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    public int BarbeiroId { get; set; }
    public Barbeiro Barbeiro { get; set; } = null!;

    public int ServicoId { get; set; }
    public Servico Servico { get; set; } = null!;

    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
}