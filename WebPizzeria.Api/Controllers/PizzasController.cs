using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using WebPizzeria.Api.Services;
using WebPizzeria.Core.Dtos;
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
    [HttpGet]
    public async Task<IActionResult> GetAllPizzasAsync()
    {
        var pizzas = await _pizzaService.GetAllAsync();
        return Ok(pizzas);
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<PizzaEntity>> GetPizzaById(Guid id)
    {
        return await _pizzaService.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult> AddPizzaAsync(PostPizzaDto postPizzaDto)
    {
        var pizza = await _pizzaService.AddAsync(postPizzaDto);
        return Created(nameof(GetPizzaById), pizza);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePizzaAsync([FromRoute] Guid id, [FromBody] UpdatePizzaDto pizzaDto)
    {
        await _pizzaService.UpdateAsync(id, pizzaDto);

        return NoContent();
    }

}
