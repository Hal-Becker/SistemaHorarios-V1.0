using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHorarios.Infrastructure;
using SistemaHorarios.Domain;

[ApiController]
[Route("api/[controller]")]
public class GruposController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public GruposController(ApplicationDbContext context)
    {
        _context = context;
    }

    // LISTAR
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Grupos.ToListAsync());
    }

    // CREAR
    [HttpPost]
    public async Task<IActionResult> Create(Grupo grupo)
    {
        _context.Grupos.Add(grupo);
        await _context.SaveChangesAsync();
        return Ok(grupo);
    }

    // ELIMINAR
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var grupo = await _context.Grupos.FindAsync(id);

        if (grupo == null)
            return NotFound();

        _context.Grupos.Remove(grupo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}