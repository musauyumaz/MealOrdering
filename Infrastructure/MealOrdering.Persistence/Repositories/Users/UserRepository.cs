using MealOrdering.Application.Repositories.Users;
using MealOrdering.Domain.Entities;
using MealOrdering.Persistence.Contexts;

namespace MealOrdering.Persistence.Repositories.Users
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MealOrderingDbContext context) : base(context)
        {
        }
    }
}
