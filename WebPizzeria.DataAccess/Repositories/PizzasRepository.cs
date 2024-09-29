using Microsoft.EntityFrameworkCore;
using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories;

public class PizzasRepository : IPizzasRepository
{
    private readonly PizzaDbContext _context;
    public PizzasRepository(PizzaDbContext context)
    {
        _context = context;
    }

    public async Task<List<PizzaEntity>> GetAsync()
    {
        return await _context.Pizzas.AsNoTracking().
            OrderBy(p => p.Name).ToListAsync();
    }

    public async Task<PizzaEntity> GetByIdAsync(Guid id)
    {
        return await _context.Pizzas.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<PizzaEntity>> GetByFilter(decimal price)
    {
        var query = _context.Pizzas.AsNoTracking();

        if (price > 0)
        {
            query = query.Where(p => p.BasePrice < price);
        }

        return await query.ToListAsync();
    }

    public async Task<List<PizzaEntity>> GetByPage(int page, int pageSize)
    {
        return await _context.Pizzas.AsNoTracking().
            Skip((page - 1) * pageSize).
            Take(pageSize).ToListAsync();
    }

    public async Task<PizzaEntity> AddAsync(PizzaEntity pizza, List<string> ingredientNames)
    {
        //at the beginning adding the pizza to the database without any ingredients
        await _context.Pizzas.AddAsync(pizza);
        _context.SaveChanges();

        var ingredients = _context.Ingredients.ToList();
        var foundIngredients = ingredients.Where(i => ingredientNames.Contains(i.Name)).ToList();

        pizza.Ingredients = foundIngredients;

        _context.SaveChanges();

        return pizza;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Pizzas.Where(p => p.Id == id).ExecuteDeleteAsync();
    }

    public async Task UpdatePizza(Guid id, UpdatePizzaDto pizzaDto)
    {
        var ingredients = _context.Ingredients.Where(i => pizzaDto.IngredientNames.Contains(i.Name)).ToList();

        var pizza = await _context.Pizzas.Where(p => p.Id == id).ExecuteUpdateAsync(
            s => s.SetProperty(p => p.Name, pizzaDto.Name)
            .SetProperty(p => p.BasePrice, pizzaDto.BasePrice)
            .SetProperty(p => p.Ingredients, ingredients));

        await _context.SaveChangesAsync();
    }
}
