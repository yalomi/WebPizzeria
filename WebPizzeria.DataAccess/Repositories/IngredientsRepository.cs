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
    public async Task AddAsync(IngredientEntity entity)
    {
        await _context.Ingredients.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Ingredients
            .Where(i => i.Id == id).ExecuteDeleteAsync();
    }
}
