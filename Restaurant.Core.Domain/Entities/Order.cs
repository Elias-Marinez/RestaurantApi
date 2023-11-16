
using Restaurant.Core.Domain.Core;

namespace Restaurant.Core.Domain.Entities
{
    public class Order : BaseEntity
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public decimal SubTotal { get; set; }
        public int StatusId { get; set; }

        //Navegation Properties 
        public ICollection<Dish>? Dishes { get; set; }
        public Table? Table { get; set; }
    }
}
