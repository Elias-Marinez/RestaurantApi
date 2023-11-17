
using Restaurant.Core.Domain.Core;

namespace Restaurant.Core.Domain.Entities
{
    public class Dish : BaseEntity
    {
        public int DishId { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }
        public int CategoryId { get; set; }

        //Navegation Properties
        public ICollection<Ingredient>? Ingredients { get; set; } = new List<Ingredient>();
        public ICollection<Order>? Orders { get; set; }

    }
}
