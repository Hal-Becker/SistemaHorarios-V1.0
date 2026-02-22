using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHorarios.Infrastructure;
using SistemaHorarios.Domain;

[ApiController]
[Route("api/[controller]")]
public class AsignaturasController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public AsignaturasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // LISTAR
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Asignaturas.ToListAsync());
    }

    // CREAR
    [HttpPost]
    public async Task<IActionResult> Create(Asignatura asignatura)
    {
        _context.Asignaturas.Add(asignatura);
        await _context.SaveChangesAsync();

        return Ok(asignatura);
    }

    // ELIMINAR
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var asignatura = await _context.Asignaturas.FindAsync(id);

        if (asignatura == null)
            return NotFound();

        _context.Asignaturas.Remove(asignatura);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}