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

    public async Task<List<PizzaDto>> GetAllAsync()
    {
        return await _pizzaRepository.GetAsync();
    }

    public async Task<PizzaDto> GetByIdAsync(Guid id)
    {
        return await _pizzaRepository.GetByIdAsync(id);
    }

    public async Task<PostPizzaDto> AddAsync(PizzaDto postPizzaDto)
    {
        var pizzaWithoutIngredients = new PizzaEntity
        {
            Id = Guid.NewGuid(),
            Name = postPizzaDto.Name,
            BasePrice = postPizzaDto.BasePrice,
        };

        var necessaryIngredientNames = postPizzaDto.IngredientNames;

        var pizzaWithIngredients = await _pizzaRepository.AddAsync(pizzaWithoutIngredients, necessaryIngredientNames);

        var pizzaDto = new PostPizzaDto
        {
            Id = pizzaWithIngredients.Id,
            Name = pizzaWithIngredients.Name,
            BasePrice = pizzaWithIngredients.BasePrice,
            IngredientNames = pizzaWithIngredients.Ingredients.Select(p => p.Name).ToList()
        };

        return pizzaDto;
    }

    public async Task UpdateAsync(Guid id, UpdatePizzaDto updatePizzaDto)
    {
        await _pizzaRepository.UpdateAsync(id, updatePizzaDto);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _pizzaRepository.DeleteAsync(id);
    }
}
