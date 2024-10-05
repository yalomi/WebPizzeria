using Microsoft.EntityFrameworkCore;
using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories;

public class IngredientsRepository : IIngredientsRepository
{
    private readonly PizzaDbContext _context;
    public IngredientsRepository(PizzaDbContext context)
    {
        _context = context;
    }

    public async Task<List<IngredientDto>> GetAllAsync()
    {
        var ingredientEntities = await 
            _context.Ingredients
            .AsNoTracking()
            .Include(i => i.Pizzas)
            .ToListAsync();
        
        var ingredientDtos = new List<IngredientDto>();

        foreach (var ingredientEntity in ingredientEntities)
        {
            ingredientDtos.Add(new IngredientDto
            {
                Name = ingredientEntity.Name,
                PizzaNames = ingredientEntity.Pizzas.Select(p => p.Name).ToList()
            });
        }
        
        return ingredientDtos;
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
