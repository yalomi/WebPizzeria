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

    public async Task AddAsync(
        PizzaEntity pizzaEntity)
    {
        var pizza = new PizzaEntity
        {
            Id = Guid.NewGuid(),
            Name = pizzaDto.Name,
            BasePrice = pizzaDto.BasePrice,
        };

        foreach (var ingredientId in pizzaDto.IngredientsIds)
        {
            pizza.Ingredients.Add(new IngredientEntity { Id = ingredientId });
        }

        await _context.Pizzas.AddAsync(pizza);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(
        Guid id, string name, decimal price, List<IngredientEntity> ingredients)
    {
        var pizza = await _context.Pizzas.Where(p => p.Id == id).ExecuteUpdateAsync(
            s => s.SetProperty(p => p.Name, name).SetProperty(p => p.BasePrice, price).SetProperty(p => p.Ingredients, ingredients)
        );
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Pizzas.Where(p => p.Id == id).ExecuteDeleteAsync();
    }
}
