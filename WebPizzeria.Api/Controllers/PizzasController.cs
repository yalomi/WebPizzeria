using Microsoft.AspNetCore.Mvc;
using WebPizzeria.Api.Services;
using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;
using static System.Net.WebRequestMethods;

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
    public async Task AddPizzaAsync(PostPizzaDto postPizzaDto)
    {
        var pizza = await _pizzaService.AddAsync(postPizzaDto);
        //http response
    }

}
