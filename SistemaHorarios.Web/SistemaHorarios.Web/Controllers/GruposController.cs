using Microsoft.AspNetCore.Mvc;
using SistemaHorarios.Web.Models;
using System.Net.Http.Json;

public class GruposController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public GruposController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    // LISTAR
    public async Task<IActionResult> Index()
    {
        var client = _httpClientFactory.CreateClient("API");
        var grupos = await client.GetFromJsonAsync<List<GrupoViewModel>>("api/grupos");
        return View(grupos);
    }

    // FORM CREAR
    public IActionResult Create()
    {
        return View();
    }

    // GUARDAR
    [HttpPost]
    public async Task<IActionResult> Create(GrupoViewModel model)
    {
        var client = _httpClientFactory.CreateClient("API");
        var response = await client.PostAsJsonAsync("api/grupos", model);

        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError("", "No se pudo crear el grupo.");
            return View(model);
        }

        return RedirectToAction("Index");
    }

    // ELIMINAR
    public async Task<IActionResult> Delete(int id)
    {
        var client = _httpClientFactory.CreateClient("API");
        await client.DeleteAsync($"api/grupos/{id}");
        return RedirectToAction("Index");
    }
}