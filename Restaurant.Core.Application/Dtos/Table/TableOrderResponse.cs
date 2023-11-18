
using Restaurant.Core.Application.Dtos.Order;

namespace Restaurant.Core.Application.Dtos.Table
{
    public class TableOrderResponse : BaseResponse
    {
        public ICollection<OrderResponse>? Orders { get; set; }
    }
}
