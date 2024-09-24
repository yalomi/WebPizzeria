using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories
{
    public interface IPizzasRepository
    {
        Task<List<PizzaEntity>> GetAsync();
        Task<PizzaEntity> GetByIdAsync(Guid id);
        Task<List<PizzaEntity>> GetByFilter(decimal price);
        Task<List<PizzaEntity>> GetByPage(int page, int pageSize);
        Task AddAsync(PizzaDto pizzaDto);
        Task UpdateAsync(Guid id, string name, decimal price, List<IngredientEntity> ingredients);
        Task DeleteAsync(Guid id);
    }
}