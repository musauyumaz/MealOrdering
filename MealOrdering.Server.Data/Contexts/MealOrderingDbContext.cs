using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace MealOrdering.Server.Data.Contexts
{
    public class MealOrderingDbContext : DbContext
    {
        public MealOrderingDbContext(DbContextOptions<MealOrderingDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("uuid-ossp");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<EntityEntry<BaseEntity>> datas = ChangeTracker.Entries<BaseEntity>();

            foreach (EntityEntry<BaseEntity> data in datas)
                if (data.State == EntityState.Added)
                    data.Entity.CreatedDate = DateTime.UtcNow;

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
