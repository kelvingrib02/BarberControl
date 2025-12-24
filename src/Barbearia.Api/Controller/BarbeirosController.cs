using Barbearia.Domain.Entities;
using Barbearia.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BarbeirosController : ControllerBase
{
    private readonly BarbeariaDbContext _context;
    public BarbeirosController(BarbeariaDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Barbeiro>>> GetBarbeiros()
    {
        return await _context.Barbeiros.ToListAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Barbeiro>> GetBarbeiro(int id)
    {
        var barbeiro = await _context.Barbeiros.FindAsync(id);

        if (barbeiro == null)
            return NotFound();

        return barbeiro;
    }

    [HttpPost]
    public async Task<ActionResult<Barbeiro>> PostBarbeiro(Barbeiro barbeiro)
    {
        _context.Barbeiros.Add(barbeiro);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetBarbeiro), new { id = barbeiro.Id }, barbeiro);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBarbeiro(int id, Barbeiro barbeiro)
    {
        if (id != barbeiro.Id)
            return BadRequest("ID do corpo diferente do ID da URL.");

        _context.Entry(barbeiro).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!BarbeiroExists(id))
                return NotFound();

            throw;
        }

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteBarbeiro(int id)
    {
        var barbeiro = await _context.Barbeiros.FindAsync(id);
        if (barbeiro == null)
            return NotFound();

        _context.Barbeiros.Remove(barbeiro);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool BarbeiroExists(int id)
    {
        return _context.Barbeiros.Any(e => e.Id == id);
    }
}
