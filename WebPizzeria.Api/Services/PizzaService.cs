using System.ComponentModel;
using WebPizzeria.Core.Entities;
using WebPizzeria.DataAccess.Repositories;

namespace WebPizzeria.Api.Services;

public class PizzaService
{
    private readonly IPizzasRepository _repository;
    public PizzaService(IPizzasRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<PizzaEntity>> GetAllPizzasAsync()
    {
        return await _repository.GetAsync();
    }

    public async Task<PizzaEntity> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task AddAsync(PizzaEntity pizzaEntity, List<IngredientEntity> ingredients)
    {
        await _repository.AddAsync(pizzaEntity, ingredients);
    }
}
