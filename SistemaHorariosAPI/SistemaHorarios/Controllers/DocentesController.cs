using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHorarios.Infrastructure;
using SistemaHorarios.Domain;

[ApiController]
[Route("api/[controller]")]
public class DocentesController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public DocentesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // LISTAR
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _context.Docentes.ToListAsync());
    }
    // CREAR
    [HttpPost]
    public async Task<IActionResult> Create(Docente docente)
    {
        _context.Docentes.Add(docente);
        await _context.SaveChangesAsync();
        return Ok(docente);
    }
    // ELIMINAR
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var docente = await _context.Docentes.FindAsync(id);
        if (docente == null)
            return NotFound();

        _context.Docentes.Remove(docente);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}