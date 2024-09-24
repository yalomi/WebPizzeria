using Microsoft.AspNetCore.Mvc;
using WebPizzeria.Api.Services;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly PizzaService _pizzaService;
    public PizzasController(PizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpPost]
    public async Task AddPizzaAsync(string name, decimal basePrice, List<Guid> ingredientIds)
    {
        await _pizzaService.AddAsync(name, basePrice, ingredientIds);
    }

}
