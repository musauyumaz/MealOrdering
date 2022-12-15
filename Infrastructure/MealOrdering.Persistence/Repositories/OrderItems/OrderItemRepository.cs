using MealOrdering.Application.Repositories.OrderItems;
using MealOrdering.Domain.Entities;
using MealOrdering.Persistence.Contexts;

namespace MealOrdering.Persistence.Repositories.OrderItems
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(MealOrderingDbContext context) : base(context)
        {
        }
    }
}
