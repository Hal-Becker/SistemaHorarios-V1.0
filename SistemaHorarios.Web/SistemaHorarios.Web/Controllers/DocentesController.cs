using Microsoft.AspNetCore.Mvc;
using SistemaHorarios.Web.Models;
using System.Net.Http.Json;

public class DocentesController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DocentesController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // LISTAR
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("API");

        var docentes = await client.GetFromJsonAsync<List<DocenteViewModel>>("api/docentes");

        return View(docentes);
    }

    // FORM CREAR
    public IActionResult Create()
    {
        return View();
    }

    // GUARDAR
    [HttpPost]
    public async Task<IActionResult> Create(DocenteViewModel model)
    {
        var client = _httpClientFactory.CreateClient("API");

        var response = await client.PostAsJsonAsync("api/docentes", model);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "No se pudo crear el docente.");
            return View(model);
        }

        return RedirectToAction("Index");
    }

    // ELIMINAR
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("API");

        await client.DeleteAsync($"api/docentes/{id}");

        return RedirectToAction("Index");
    }
}