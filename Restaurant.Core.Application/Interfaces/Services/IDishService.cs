
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Domain.Entities;

namespace Restaurant.Core.Application.Interfaces.Services
{
    public interface IDishService : IGenericService<DishResponse, DishRequest, DishUpdRequest, Dish>
    {
    }
}
