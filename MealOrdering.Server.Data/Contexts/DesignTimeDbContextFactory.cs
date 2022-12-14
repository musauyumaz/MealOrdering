using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MealOrdering.Server.Data.Contexts
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MealOrderingDbContext>
    {
        public MealOrderingDbContext CreateDbContext(string[] args)
        {
            string connectionString = "User Id=postgres;password=123456;Host=localhost;Port=5432;Database=mealordering;";

            var builder = new DbContextOptionsBuilder<MealOrderingDbContext>();

            builder.UseNpgsql(connectionString);

            return new MealOrderingDbContext(builder.Options);
        }
    }
}
