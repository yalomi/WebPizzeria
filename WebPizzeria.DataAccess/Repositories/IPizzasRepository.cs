using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories
{
    public interface IPizzasRepository
    {
        Task<List<PizzaDto>> GetAsync();
        Task<PizzaDto> GetByIdAsync(Guid id);
        Task<List<PizzaEntity>> GetByFilter(decimal price);
        Task<List<PizzaEntity>> GetByPage(int page, int pageSize);
        Task<PizzaEntity> AddAsync(PizzaEntity pizza, List<string> ingredientNames);
        Task UpdateAsync(Guid id, UpdatePizzaDto pizzaDto);
        Task DeleteAsync(Guid id);
    }
}