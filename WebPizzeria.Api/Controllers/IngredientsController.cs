using Microsoft.AspNetCore.Mvc;
using WebPizzeria.Api.Services;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IngredientService _ingredientService;
    public IngredientsController(IngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    [HttpGet]
    public async Task<IActionResult> GetIngredients()
    {
        var ingredients = await _ingredientService.GetAsync();
        return Ok(ingredients);
    }

    [HttpPost]
    public async Task<IActionResult> AddIngredient(string name)
    {
        
        var ingredientWithId = await _ingredientService.AddAsync(name);
        
        string uri = $"/ingredients/{ingredientWithId.Item2}";
        return Created(uri, ingredientWithId.Item1);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(Guid id)
    {
        await _ingredientService.DeleteAsync(id);
        return NoContent();
    }
}