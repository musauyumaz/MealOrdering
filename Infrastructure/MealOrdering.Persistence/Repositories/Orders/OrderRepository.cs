using MealOrdering.Application.Repositories.Orders;
using MealOrdering.Domain.Entities;
using MealOrdering.Persistence.Contexts;

namespace MealOrdering.Persistence.Repositories.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(MealOrderingDbContext context) : base(context)
        {
        }
    }
}
