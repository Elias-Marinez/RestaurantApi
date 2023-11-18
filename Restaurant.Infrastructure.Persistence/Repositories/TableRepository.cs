
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Application.Enums;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private readonly ApplicationContext _dbContext;

        public TableRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Table>? UpdateAsync(Table entity, int id)
        {
            Table entry = await _dbContext.Tables.FindAsync(id);

            if (entry != null)
            {
                entry.Capacity = entity.Capacity;
                entry.Description = entry.Description;
                await _dbContext.SaveChangesAsync();
            }

            return entry;
        }

        public async Task<Table> GetByIdWithOrder(int id)
        {
            var table = await _dbContext.Set<Table>()
                                                .Include(d => d.Orders)
                                                    .ThenInclude(d => d.Dishes)
                                                        .ThenInclude(d => d.Ingredients)
                                                .FirstOrDefaultAsync(t => t.TableId == id &&
                                                    t.Orders.Any(o => o.StatusId == 0));
            return table;
        }

        public async Task StatusUpdateAsync(Table entity, int id)
        {
            Table entry = await _dbContext.Tables.FindAsync(id);

            if (entry != null)
            {
                entry.StatusId = entity.StatusId;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
