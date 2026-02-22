using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHorarios.Infrastructure;
using SistemaHorarios.Domain;

[ApiController]
[Route("api/[controller]")]
public class AulasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AulasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // LISTAR
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Aulas.ToListAsync());
    }

    // CREAR
    [HttpPost]
    public async Task<IActionResult> Create(Aula aula)
    {
        _context.Aulas.Add(aula);
        await _context.SaveChangesAsync();

        return Ok(aula);
    }

    // ELIMINAR
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var aula = await _context.Aulas.FindAsync(id);

        if (aula == null)
            return NotFound();

        _context.Aulas.Remove(aula);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}