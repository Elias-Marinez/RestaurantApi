
using Restaurant.Core.Application.Dtos.Order;

namespace Restaurant.Core.Application.Dtos.Table
{
    public class TableResponse : BaseResponse
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; }

    }
}
