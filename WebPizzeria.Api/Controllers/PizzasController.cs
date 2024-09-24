using Microsoft.AspNetCore.Mvc;
using WebPizzeria.Api.Services;
using WebPizzeria.Core.Entities;
using WebPizzeria.DataAccess.Configurations;

namespace WebPizzeria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PizzasController : ControllerBase
{
    private readonly PizzaService _service;
    public PizzasController(PizzaService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task AddPizzaAsync(Guid id, string name, decimal price, List<IngredientEntity> ingredients)
    {
        await _service.AddAsync(id, name, price, ingredients);
    }

}
