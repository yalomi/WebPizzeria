using Microsoft.AspNetCore.Mvc;
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
        var pizza = await _pizzaService.GetByIdAsync(id);
        return Ok(pizza);
    }

    [HttpPost]
    public async Task<ActionResult> AddPizzaAsync(PostPizzaDto postPizzaDto)
    {
        var pizza = await _pizzaService.AddAsync(postPizzaDto);
        
        return CreatedAtAction(nameof(GetPizzaById), new { id = pizza.Id }, postPizzaDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdatePizzaAsync([FromRoute] Guid id, [FromBody] UpdatePizzaDto updatePizzaDto)
    {
        await _pizzaService.UpdateAsync(id, updatePizzaDto);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePizzaAsync([FromRoute] Guid id)
    {
        await _pizzaService.DeleteAsync(id);
        return NoContent();
    }
}