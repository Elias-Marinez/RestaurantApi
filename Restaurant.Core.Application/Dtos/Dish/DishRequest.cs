
using Restaurant.Core.Application.Enums;

namespace Restaurant.Core.Application.Dtos.Dish
{
    public class DishRequest
    {
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public DishCategory Category { get; set; }
        public ICollection<String>? Ingredients { get; set; }
    }
}
