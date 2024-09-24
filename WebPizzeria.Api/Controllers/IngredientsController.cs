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

    [HttpPost]
    public async Task<IActionResult> AddIngredient(string name)
    {
        var ingredient = new IngredientEntity { Id = Guid.NewGuid(), Name = name };
        await _ingredientService.AddAsync(ingredient);
        string uri = $"/ingredients/{ingredient.Id}";
        return Created(uri, ingredient);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteIngredient(Guid id)
    {
        await _ingredientService.DeleteAsync(id);
        return NoContent();
    }
}