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

    public async Task<List<PizzaDto>> GetAsync()
    {
        var pizzaDtos = new List<PizzaDto>();

        var pizzas = await _context.Pizzas
            .AsNoTracking()
            .Include(p => p.Ingredients)
            .ToListAsync();

        foreach (var pizza in pizzas)
        {
            pizzaDtos.Add(new PizzaDto
            {
                Name = pizza.Name,
                BasePrice = pizza.BasePrice,
                IngredientNames = pizza.Ingredients.Select(i => i.Name).ToList()
            });
        }
        
        return pizzaDtos;
    }

    public async Task<PizzaDto> GetByIdAsync(Guid id)
    {
        var pizza = await _context.Pizzas
            .AsNoTracking()
            .Include(p => p.Ingredients)
            .FirstOrDefaultAsync(p => p.Id == id);

        var pizzaDto = new PizzaDto
        {
            Name = pizza.Name,
            BasePrice = pizza.BasePrice,

            IngredientNames = pizza.Ingredients.Select(i => i.Name).ToList()
        };

        return pizzaDto;
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

    public async Task<PizzaEntity> AddAsync(PizzaEntity pizzaWithoutIngredients, List<string> necessaryIngredientNames)
    {
        await _context.Pizzas.AddAsync(pizzaWithoutIngredients);
        _context.SaveChanges();

        var foundIngredients = _context.Ingredients.Where(i => necessaryIngredientNames.Contains(i.Name)).ToList(); //_context.Ingredients.ToList??

        pizzaWithoutIngredients.Ingredients = foundIngredients;

        _context.SaveChanges();

        return pizzaWithoutIngredients;
    }

    public async Task DeleteAsync(Guid id)
    {
        await _context.Pizzas.Where(p => p.Id == id).ExecuteDeleteAsync();
    }

    public async Task UpdateAsync(Guid id, UpdatePizzaDto pizzaDto)
    {
        var ingredients = _context.Ingredients.Where(i => pizzaDto.IngredientNames.Contains(i.Name)).ToList();

        var pizza = await _context.Pizzas.Include(p => p.Ingredients).FirstOrDefaultAsync(p => p.Id == id); //with include works

        pizza.Name = pizzaDto.Name;
        pizza.BasePrice = pizzaDto.BasePrice;

        pizza.Ingredients.Clear();

        foreach (var ingredient in ingredients)
        {
            pizza.Ingredients.Add(ingredient); 
        }

        await _context.SaveChangesAsync();
    }
}
