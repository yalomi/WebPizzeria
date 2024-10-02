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

    public async Task<List<IngredientEntity>> GetAsync()
    {
        var ingredients = await _repository.GetAllAsync();
        return ingredients;
    }

    public async Task<IngredientEntity> AddAsync(string name)
    {
        var ingredient = new IngredientEntity { Id = Guid.NewGuid(), Name = name };
        var ingredientDto = await _repository.AddAsync(ingredient);
        return ingredientDto;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
