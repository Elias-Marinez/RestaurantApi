
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Infrastructure.Persistence.Context;
using System.Linq.Expressions;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class GenericRepository<Entity> : IGenericRepository<Entity> where Entity : class
    {
        private readonly ApplicationContext _dbContext;

        public GenericRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task AddAsync(Entity entity)
        {
            await _dbContext.Set<Entity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Add(Entity entity, params Expression<Func<Entity, object>>[] includeProperties)
        {
            _dbContext.Set<Entity>().Add(entity);

            foreach (var includeProperty in includeProperties)
            {
                _dbContext.Entry(entity).Reference(includeProperty).Load();
            }

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<Entity>? UpdateAsync(Entity entity, int id)
        {
            var entry = await _dbContext.Set<Entity>().FindAsync(id);

            if (entry != null)
            {
                _dbContext.Entry(entry).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }

            return entry;
        }

        public virtual async Task UpdateAsync<TEntity>(Entity entity, int id, params Expression<Func<Entity, object>>[] includeProperties)
        {
            var entry = await _dbContext.Set<Entity>().FindAsync(id);

            if (entry != null)
            {
                _dbContext.Entry(entry).CurrentValues.SetValues(entity);

                foreach (var includeProperty in includeProperties)
                {
                    _dbContext.Entry(entry).Reference(includeProperty).Load();
                }

                await _dbContext.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entry = await _dbContext.Set<Entity>().FindAsync(id);
            _dbContext.Set<Entity>().Remove(entry);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<List<Entity>> GetAllAsync()
        {
            return await _dbContext.Set<Entity>().ToListAsync();
        }

        public virtual async Task<List<Entity>> GetAllWithIncludeAsync()
        {
            var entityProperties = _dbContext.Model.FindEntityType(typeof(Entity)).GetNavigations();

            var query = _dbContext.Set<Entity>().AsQueryable();

            foreach (var property in entityProperties)
            {
                query = query.Include(property.Name);
            }

            return await query.ToListAsync();
        }

        public virtual async Task<Entity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<Entity>().FindAsync(id);
        }
    }
}
