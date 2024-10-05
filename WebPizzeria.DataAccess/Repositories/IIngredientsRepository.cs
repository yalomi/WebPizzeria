using WebPizzeria.Core.Dtos;
using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories
{
    public interface IIngredientsRepository
    {
        Task<List<IngredientDto>> GetAllAsync();
        Task<IngredientEntity> AddAsync(IngredientEntity entity);
        Task DeleteAsync(Guid id);
    }
}