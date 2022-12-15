using MealOrdering.Domain.Entities.Common;

namespace MealOrdering.Domain.Entities
{
    public class OrderItem : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid OrderId { get; set; }
        public string Description { get; set; }

        public virtual User User { get; set; }
        public virtual Order Order { get; set; }
    }
}
