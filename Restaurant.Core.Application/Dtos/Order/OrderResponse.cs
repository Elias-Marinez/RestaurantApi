
using Restaurant.Core.Application.Dtos.Dish;
using Restaurant.Core.Application.Dtos.Table;

namespace Restaurant.Core.Application.Dtos.Order
{
    public class OrderResponse : BaseResponse
    {
        public int OrderId { get; set; }
        public int TableId { get; set; }
        public decimal SubTotal { get; set; }
        public string Status { get; set; }

        //Navegation Properties 
        public ICollection<DishResponse>? Dishes { get; set; }
        public TableResponse? Table { get; set; }
    }
}
