
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Application.Interfaces.Repository;
using Restaurant.Core.Domain.Entities;
using Restaurant.Infrastructure.Persistence.Context;

namespace Restaurant.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _dbContext;

        public OrderRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<Order> GetByIdAsync(int id)
        {
            var order = await _dbContext.Set<Order>()
                                                .Include(d => d.Dishes)
                                                        .ThenInclude(d => d.Ingredients)
                                                .FirstOrDefaultAsync(o => o.OrderId == id);
            return order;
        }
        public override async Task<List<Order>> GetAllAsync()
        {
            var orders = await _dbContext.Set<Order>()
                                                .Include(d => d.Dishes)
                                                        .ThenInclude(d => d.Ingredients)
                                                .ToListAsync();
            return orders;
        }
        public override async Task<Order>? UpdateAsync(Order entity, int id)
        {
            Order entry = await GetByIdAsync(id);

            if (entry != null)
            {
                entry.Dishes.Clear();
                await _dbContext.SaveChangesAsync();

                entry.Dishes = entity.Dishes;
                entry.SubTotal = entity.SubTotal;
                await _dbContext.SaveChangesAsync();
            }

            return entry;
        }
    }
}
