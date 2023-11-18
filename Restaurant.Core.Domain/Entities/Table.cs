
using Restaurant.Core.Domain.Core;

namespace Restaurant.Core.Domain.Entities
{
    public class Table : BaseEntity
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public int StatusId { get; set; }

        //Navegation Properties
        public ICollection<Order>? Orders { get; set; }
    }
}
