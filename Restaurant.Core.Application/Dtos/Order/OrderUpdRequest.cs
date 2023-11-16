
using Restaurant.Core.Application.Dtos.Dish;

namespace Restaurant.Core.Application.Dtos.Order
{
    public class OrderUpdRequest
    {
        public int OrderId { get; set; }
        public ICollection<DishResponse>? Dishes { get; set; }
    }
}
