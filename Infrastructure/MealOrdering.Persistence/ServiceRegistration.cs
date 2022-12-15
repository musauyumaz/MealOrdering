using MealOrdering.Application.Repositories.OrderItems;
using MealOrdering.Application.Repositories.Orders;
using MealOrdering.Application.Repositories.Suppliers;
using MealOrdering.Application.Repositories.Users;
using MealOrdering.Application.Services.PersistenceServices;
using MealOrdering.Persistence.Configurations;
using MealOrdering.Persistence.Contexts;
using MealOrdering.Persistence.Repositories.OrderItems;
using MealOrdering.Persistence.Repositories.Orders;
using MealOrdering.Persistence.Repositories.Suppliers;
using MealOrdering.Persistence.Repositories.Users;
using MealOrdering.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MealOrdering.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MealOrderingDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();

            services.AddScoped<IUserService, UserManager>();
        }
    }
}
