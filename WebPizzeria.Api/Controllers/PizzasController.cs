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

}
