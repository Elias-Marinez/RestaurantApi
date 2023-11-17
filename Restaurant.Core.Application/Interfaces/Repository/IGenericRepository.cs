
using System.Linq.Expressions;

namespace Restaurant.Core.Application.Interfaces.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task AddAsync(Entity entity);
        Task<Entity>? UpdateAsync(Entity entity, int id);
        Task DeleteAsync(int id);
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task<List<Entity>> GetAllWithIncludeAsync(params Expression<Func<Entity, object>>[] includes);
    }
}
