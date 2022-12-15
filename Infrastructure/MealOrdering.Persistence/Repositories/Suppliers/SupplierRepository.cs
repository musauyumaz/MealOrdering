using MealOrdering.Application.Repositories.Suppliers;
using MealOrdering.Domain.Entities;
using MealOrdering.Persistence.Contexts;

namespace MealOrdering.Persistence.Repositories.Suppliers
{
    public class SupplierRepository : Repository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(MealOrderingDbContext context) : base(context)
        {
        }
    }
}
