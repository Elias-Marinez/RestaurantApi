
using Restaurant.Core.Application.Dtos.Order;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IOrderService : IGenericService<OrderResponse, OrderRequest, OrderUpdRequest, Order>
    {
    }
}
