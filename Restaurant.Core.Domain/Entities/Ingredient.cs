
using Restaurant.Core.Domain.Core;

namespace Restaurant.Core.Domain.Entities
{
    public class Ingredient : BaseEntity
    {
        public int IngredientId {  get; set; }
        public string? Name { get; set; }

        //Navegation Property
        public ICollection<Dish>? Dishes { get; set; }
    }
}
