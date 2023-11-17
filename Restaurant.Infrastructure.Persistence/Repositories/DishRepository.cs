
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class DishRepository : GenericRepository<Dish>, IDishRepository
    {
        private readonly ApplicationContext _dbContext;

        public DishRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public override async Task<Dish> GetByIdAsync(int id)
        {
            var dish = await _dbContext.Set<Dish>()
                                                .Include(d => d.Ingredients)
                                                .FirstOrDefaultAsync(d => d.DishId == id);
            return dish;
        }

        public override async Task<Dish>? UpdateAsync(Dish entity, int id)
        {
            Dish entry = await GetByIdAsync(id);

            if (entry != null)
            {
                entry.Ingredients.Clear();
                await _dbContext.SaveChangesAsync();

                entry.Ingredients = entity.Ingredients;
                await _dbContext.SaveChangesAsync();
            }

            return entry;
        }
    }
}
