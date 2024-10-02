using Microsoft.EntityFrameworkCore;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories;

public class IngredientsRepository : IIngredientsRepository
{
    private readonly PizzaDbContext _context;
    public IngredientsRepository(PizzaDbContext context)
    {
        _context = context;
    }

    public Task<List<IngredientEntity>> GetAllAsync()
    {
        var ingredients = _context.Ingredients
            .Include(i => i.Pizzas)
            .ToListAsync();
        
        return ingredients;
    }

    public async Task<IngredientEntity> AddAsync(IngredientEntity entity)
    {
        await _context.Ingredients.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Ingredients
            .Where(i => i.Id == id).ExecuteDeleteAsync();
    }
}
