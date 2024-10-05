using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;
using WebPizzeria.DataAccess.Repositories;

namespace WebPizzeria.Api.Services;

public class IngredientService
{
    private readonly IIngredientsRepository _repository;

    public IngredientService(IIngredientsRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<IngredientDto>> GetAsync()
    {
        var ingredients = await _repository.GetAllAsync();
        return ingredients;
    }

    public async Task<Tuple<IngredientDto, Guid>> AddAsync(string name)
    {
        var ingredient = new IngredientEntity { Id = Guid.NewGuid(), Name = name };
        ingredient = await _repository.AddAsync(ingredient);

        var ingredientDto = new IngredientDto
        {
            Name = ingredient.Name,
            PizzaNames = ingredient.Pizzas.Select(p => p.Name).ToList()
        };
        
        return new Tuple<IngredientDto, Guid>(ingredientDto, ingredient.Id);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
