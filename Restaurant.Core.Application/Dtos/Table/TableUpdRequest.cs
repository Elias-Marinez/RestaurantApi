
namespace Restaurant.Core.Application.Dtos.Table
{
    public class TableUpdRequest
    {
        public int TableId { get; set; }
        public int Capacity { get; set; }
        public string? Description { get; set; }
    }
}
