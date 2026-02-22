using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaHorarios.Infrastructure;
using SistemaHorarios.Domain;
using SistemaHorarios.API.DTOs;

[ApiController]
[Route("api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ScheduleController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetSchedule()
    {
        var horarios = await _context.Horarios
            .Include(h => h.Docente)
            .Include(h => h.Asignatura)
            .Include(h => h.Aula)
            .Include(h => h.Grupo)
            .Select(h => new HorarioDto
            {
                IdHorario = h.IdHorario,
                DiaSemana = h.DiaSemana,
                HoraInicio = h.HoraInicio,
                HoraFin = h.HoraFin,
                Docente = new DocenteDto
                {
                    IdDocente = h.Docente.IdDocente,
                    Nombre = h.Docente.Nombre
                },
                Asignatura = new AsignaturaDto
                {
                    IdAsignatura = h.Asignatura.IdAsignatura,
                    Nombre = h.Asignatura.Nombre
                },
                Aula = new AulaDto
                {
                    IdAula = h.Aula.IdAula,
                    Nombre = h.Aula.Nombre
                },
                Grupo = new GrupoDto
                {
                    IdGrupo = h.Grupo.IdGrupo,
                    Nombre = h.Grupo.Nombre
                }
            })
            .ToListAsync();

        return Ok(horarios);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Horario horario)
    {
        //VALIDACIÓN BÁSICA DE HORAS
        if (horario.HoraFin <= horario.HoraInicio)
            return BadRequest("La hora fin debe ser mayor que la hora inicio.");

        //Conflicto Docente
        var conflictoDocente = await _context.Horarios.AnyAsync(h =>
        h.DiaSemana == horario.DiaSemana &&
        h.HoraInicio < horario.HoraFin &&
        horario.HoraInicio < h.HoraFin &&
        (h.IdDocente == horario.IdDocente ||
         h.IdAula == horario.IdAula)
    );

        if (conflictoDocente)
            return BadRequest("El docente ya tiene una clase en ese horario.");

        //Conflicto Aula
        var conflictoAula = await _context.Horarios.AnyAsync(h =>
            h.DiaSemana == horario.DiaSemana &&
            h.HoraInicio < horario.HoraFin &&
            horario.HoraInicio < h.HoraFin &&
            h.IdAula == horario.IdAula);

        if (conflictoAula)
            return BadRequest("El aula ya está ocupada en ese horario.");

        //Conflicto Grupo
        var conflictoGrupo = await _context.Horarios.AnyAsync(h =>
            h.DiaSemana == horario.DiaSemana &&
            h.HoraInicio < horario.HoraFin &&
            horario.HoraInicio < h.HoraFin &&
            h.IdGrupo == horario.IdGrupo);

        if (conflictoGrupo)
            return BadRequest("El grupo ya tiene clase en ese horario.");

        _context.Horarios.Add(horario);
        await _context.SaveChangesAsync();

        return Ok(horario);
    }
}