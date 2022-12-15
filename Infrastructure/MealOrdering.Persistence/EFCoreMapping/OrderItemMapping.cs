using MealOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Persistence.EFCoreMapping
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(oi => oi.UserId);
            builder.Property(oi => oi.OrderId);
            builder.Property(o => o.Description).HasMaxLength(1000);

            builder.HasOne(oi => oi.User)
                .WithMany(u => u.OrderItems)
                .HasForeignKey(oi => oi.UserId);

            builder.HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

        }
    }
}
