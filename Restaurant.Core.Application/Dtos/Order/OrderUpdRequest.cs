
namespace Restaurant.Core.Application.Dtos.Order
{
    public class OrderUpdRequest
    {
        public ICollection<int>? Dishes { get; set; }
    }
}
