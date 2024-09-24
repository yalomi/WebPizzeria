using WebPizzeria.Core.Entities;

namespace WebPizzeria.DataAccess.Repositories
{
    public interface IIngredientsRepository
    {
        Task AddAsync(IngredientEntity entity);
        Task DeleteAsync(Guid id);
    }
}