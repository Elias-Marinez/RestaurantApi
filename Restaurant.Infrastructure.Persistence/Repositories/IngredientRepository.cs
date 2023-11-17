
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class IngredientRepository : GenericRepository<Ingredient>, IIngredientRepository
    {
        private readonly ApplicationContext _dbContext;

        public IngredientRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Ingredient>? UpdateAsync(Ingredient entity, int id)
        {
            Ingredient entry = await _dbContext.Ingredients.FindAsync(id);

            if (entry != null)
            {
                entry.Name = entity.Name;
                await _dbContext.SaveChangesAsync();
            }
                
            return entry;
        }
    }
}
