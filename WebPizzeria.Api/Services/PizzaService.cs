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

    public async Task<List<PizzaEntity>> GetAllAsync()
    {
        return await _pizzaRepository.GetAsync();
    }

    public async Task<PizzaEntity> GetByIdAsync(Guid id)
    {
        return await _pizzaRepository.GetByIdAsync(id);
    }

    public async Task<PizzaEntity> AddAsync(PostPizzaDto postPizzaDto)
    {
        var pizza = new PizzaEntity
        {
            Id = Guid.NewGuid(),
            Name = postPizzaDto.Name,
            BasePrice = postPizzaDto.BasePrice,
        };

        var pizzaWithIngredients = await _pizzaRepository.AddAsync(pizza, postPizzaDto.IngredientNames);

        return pizzaWithIngredients;
    }
}
