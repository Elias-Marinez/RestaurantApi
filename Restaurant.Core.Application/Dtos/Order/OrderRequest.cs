
namespace Restaurant.Core.Application.Dtos.Order
{
    public class OrderRequest
    {
        public int TableId { get; set; }
        public ICollection<int>? Dishes { get; set; }
    }
}
