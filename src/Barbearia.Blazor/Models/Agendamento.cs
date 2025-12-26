namespace Barbearia.Blazor.Models;

public class Agendamento
{
    public int Id { get; set; }
    public int BarbeiroId { get; set; }
    public virtual Barbeiro? Barbeiro { get; set; }
    public int ClienteId { get; set; }
    public virtual Cliente? Cliente { get; set; }
    public DateTime DataHora { get; set; }
    public int Status { get; set; } = 0;
}