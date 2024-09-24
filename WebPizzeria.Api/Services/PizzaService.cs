using System.Collections.Generic;
using System.Xml.Linq;
using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;
using WebPizzeria.DataAccess.Repositories;

namespace WebPizzeria.Api.Services;

public class PizzaService
{
    private readonly IPizzasRepository _pizzaRepository;
    public PizzaService(IPizzasRepository repository)
    {
        _pizzaRepository = repository;
    }

    public async Task<List<PizzaEntity>> GetAllPizzasAsync()
    {
        return await _pizzaRepository.GetAsync();
    }

    public async Task<PizzaEntity> GetByIdAsync(Guid id)
    {
        return await _pizzaRepository.GetByIdAsync(id);
    }

    public async Task AddAsync(string name, decimal basePrice, List<Guid> ingredientIds)
    {
        await _pizzaRepository.AddAsync(name, basePrice, ingredientIds);
    }
}
