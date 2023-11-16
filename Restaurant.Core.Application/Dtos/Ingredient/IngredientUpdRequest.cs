
namespace Restaurant.Core.Application.Dtos.Ingredient
{
    public class IngredientUpdRequest
    {
        public int IngredientId { get; set; }
        public required string Name { get; set; }

    }
}
