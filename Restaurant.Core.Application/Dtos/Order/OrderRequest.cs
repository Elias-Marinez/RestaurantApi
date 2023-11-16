
namespace Restaurant.Core.Application.Dtos.Order
{
    public class OrderRequest
    {
        public int TableId { get; set; }
        public ICollection<String>? Dishes { get; set; }
    }
}
