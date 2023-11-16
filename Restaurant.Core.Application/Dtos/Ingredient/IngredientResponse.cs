

namespace Restaurant.Core.Application.Dtos.Ingredient
{
    public class IngredientResponse : BaseResponse
    {
        public int IngredientId { get; set; }
        public required string Name { get; set; }
    }
}
