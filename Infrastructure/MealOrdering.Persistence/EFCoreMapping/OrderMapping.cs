using MealOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Persistence.EFCoreMapping
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o=>o.UserId);
            builder.Property(o=>o.SupplierId);
            builder.Property(o=>o.Name).HasMaxLength(100);
            builder.Property(o=>o.Description).HasMaxLength(1000);
            builder.Property(o=>o.ExpireDate);

            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o=>o.UserId);

            builder.HasOne(o => o.Supplier)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SupplierId);

        }
    }
}


