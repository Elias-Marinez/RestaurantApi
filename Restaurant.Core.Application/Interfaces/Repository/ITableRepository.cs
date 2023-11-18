
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Repository
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        Task<Table> GetByIdWithOrder(int id);
        Task StatusUpdateAsync(Table entity, int id);
    }
}
