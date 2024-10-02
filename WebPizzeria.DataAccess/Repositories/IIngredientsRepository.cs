using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories
{
    public interface IIngredientsRepository
    {
        Task<List<IngredientEntity>> GetAllAsync();
        Task<IngredientEntity> AddAsync(IngredientEntity entity);
        Task DeleteAsync(Guid id);
    }
}