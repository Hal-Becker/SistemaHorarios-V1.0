using Microsoft.AspNetCore.Mvc;
using SistemaHorarios.Web.Models;
using System.Net.Http.Json;

public class AulasController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AulasController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // LISTAR
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("API");

        var aulas = await client
            .GetFromJsonAsync<List<AulaViewModel>>("api/aulas");

        return View(aulas);
    }

    // FORM CREAR
    public IActionResult Create()
    {
        return View();
    }

    // GUARDAR
    [HttpPost]
    public async Task<IActionResult> Create(AulaViewModel model)
    {
        var client = _httpClientFactory.CreateClient("API");

        var response = await client
            .PostAsJsonAsync("api/aulas", model);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "No se pudo crear el aula.");
            return View(model);
        }

        return RedirectToAction("Index");
    }

    // ELIMINAR
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("API");

        await client.DeleteAsync($"api/aulas/{id}");

        return RedirectToAction("Index");
    }
}