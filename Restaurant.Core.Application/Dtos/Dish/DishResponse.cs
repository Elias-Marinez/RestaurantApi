
using Restaurant.Core.Application.Dtos.Ingredient;

namespace Restaurant.Core.Application.Dtos.Dish
{
    public class DishResponse : BaseResponse
    {
        public int DishId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public string? Category { get; set; }
        public ICollection<IngredientResponse>? Ingredients { get; set; }
    }
}
