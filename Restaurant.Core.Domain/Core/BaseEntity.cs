
namespace Restaurant.Core.Domain.Core
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
