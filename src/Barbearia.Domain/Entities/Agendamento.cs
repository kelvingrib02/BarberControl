using Barbearia.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Agendamento
{
    public int Id { get; set; }
    public int BarbeiroId { get; set; }
    public virtual Barbeiro? Barbeiro { get; set; }
    public int ClienteId { get; set; }
    public virtual Cliente? Cliente { get; set; }
    public DateTime DataHoraInicio { get; set; }
    public DateTime DataHoraFim { get; set; }
    public int Status { get; set; } = 0;
}