
using System.Linq.Expressions;

namespace Restaurant.Core.Application.Interfaces.Repository
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task AddAsync(Entity entity);
        Task Add(Entity entity, params Expression<Func<Entity, object>>[] includeProperties);
        Task<Entity>? UpdateAsync(Entity entity, int id);
        Task UpdateAsync<TEntity>(Entity entity, int id, params Expression<Func<Entity, object>>[] includeProperties);  
        Task DeleteAsync(int id);
        Task<List<Entity>> GetAllAsync();
        Task<Entity> GetByIdAsync(int id);
        Task<List<Entity>> GetAllWithIncludeAsync();
    }
}
