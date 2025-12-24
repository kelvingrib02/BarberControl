using Barbearia.Domain.Entities;
using Barbearia.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Barbearia.Api.Controllers

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
}
