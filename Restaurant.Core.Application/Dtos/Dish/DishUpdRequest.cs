
using Restaurant.Core.Application.Dtos.Ingredient;
using Restaurant.Core.Application.Enums;

namespace Restaurant.Core.Application.Dtos.Dish
{
    public class DishUpdRequest
    {
        public int DishId { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public DishCategory Category { get; set; }
        public ICollection<IngredientResponse>? Ingredients { get; set; }
    }
}
