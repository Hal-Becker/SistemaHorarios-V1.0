using Microsoft.AspNetCore.Mvc;
using SistemaHorarios.Web.Models;
using System.Text.Json;
using System.Net.Http.Json;

public class HomeController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public HomeController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("API");

        var horarios = await client.GetFromJsonAsync<List<HorarioDto>>("api/schedule");

        
        if (horarios == null)
        {
            Console.WriteLine("Horarios es NULL");
        }
        else
        {
            Console.WriteLine($"Cantidad de horarios: {horarios.Count}");
        }

        var model = horarios?.Select(h => new ScheduleViewModel
        {
            IdHorario = h.IdHorario,
            Asignatura = h.Asignatura?.Nombre,
            Docente = h.Docente?.Nombre,
            Aula = h.Aula?.Nombre,
            Grupo = h.Grupo?.Nombre,
            DiaSemana = h.DiaSemana,
            HoraInicio = h.HoraInicio.ToString(),
            HoraFin = h.HoraFin.ToString()
        }).ToList() ?? new List<ScheduleViewModel>();

        ViewBag.Docentes = await client.GetFromJsonAsync<List<DocenteViewModel>>("api/docentes");
        ViewBag.Asignaturas = await client.GetFromJsonAsync<List<AsignaturaViewModel>>("api/asignaturas");
        ViewBag.Aulas = await client.GetFromJsonAsync<List<AulaViewModel>>("api/aulas");
        ViewBag.Grupos = await client.GetFromJsonAsync<List<GrupoViewModel>>("api/grupos");

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateHorarioViewModel model)
    {
        var client = _httpClientFactory.CreateClient("API");

        var horario = new
        {
            IdDocente = model.IdDocente,
            IdAsignatura = model.IdAsignatura,
            IdAula = model.IdAula,
            IdGrupo = model.IdGrupo,
            DiaSemana = model.DiaSemana,
            HoraInicio = TimeSpan.Parse(model.HoraInicio),
            HoraFin = TimeSpan.Parse(model.HoraFin)
        };

        var response = await client.PostAsJsonAsync("api/schedule", horario);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            TempData["Error"] = error;
        }

        return RedirectToAction("Index");
    }
}