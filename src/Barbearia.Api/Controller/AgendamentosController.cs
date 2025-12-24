using Barbearia.Domain.Entities;
using Barbearia.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AgendamentosController : ControllerBase
{
    private readonly BarbeariaDbContext _context;
    public AgendamentosController(BarbeariaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Agendamento>>> GetAgendamentos()
    {
        return await _context.Agendamentos.Include(a => a.Cliente).Include(a => a.Barbeiro).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Agendamento>> PostAgendamento(Agendamento agendamento)
    {
        bool horarioOcupado = await _context.Agendamentos.AnyAsync(a => a.BarbeiroId == agendamento.BarbeiroId && a.DataHora == agendamento.DataHora);

        if (horarioOcupado)
        {
            return BadRequest("Este barbeiro já possui um agendamento neste horário.");
        }

        _context.Agendamentos.Add(agendamento);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAgendamentos", new { id = agendamento.Id }, agendamento);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAgendamento(int id)
    {
        var agendamento = await _context.Agendamentos.FindAsync(id);
        if (agendamento == null)
        {
            return NotFound();
        }

        _context.Agendamentos.Remove(agendamento);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}