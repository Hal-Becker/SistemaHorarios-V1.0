using Microsoft.AspNetCore.Mvc;
using SistemaHorarios.Web.Models;
using System.Net.Http.Json;

public class AsignaturasController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AsignaturasController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // LISTAR
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("API");

        var asignaturas = await client
            .GetFromJsonAsync<List<AsignaturaViewModel>>("api/asignaturas");

        return View(asignaturas);
    }

    // FORM CREAR
    public IActionResult Create()
    {
        return View();
    }

    // GUARDAR
    [HttpPost]
    public async Task<IActionResult> Create(AsignaturaViewModel model)
    {
        var client = _httpClientFactory.CreateClient("API");

        var response = await client
            .PostAsJsonAsync("api/asignaturas", model);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "No se pudo crear la asignatura.");
            return View(model);
        }

        return RedirectToAction("Index");
    }

    // ELIMINAR
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("API");

        await client.DeleteAsync($"api/asignaturas/{id}");

        return RedirectToAction("Index");
    }
}