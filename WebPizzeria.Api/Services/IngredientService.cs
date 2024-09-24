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

    public async Task AddAsync(IngredientEntity entity)
    {
        await _repository.AddAsync(entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
