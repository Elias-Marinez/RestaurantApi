
using Restaurant.Core.Application.Dtos.Table;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface ITableService : IGenericService<TableResponse, TableRequest, TableUpdRequest, Table>
    {
    }
}
