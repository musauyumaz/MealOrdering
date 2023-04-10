using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Server.Data.Contexts.ModelMappings
{
    public class OrderItemMapping : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems", "public");
            builder.HasKey(oi => oi.Id).HasName("pk_OrderItems_id");

            builder.Property(oi => oi.Id).HasColumnType<Guid>("uuid").HasDefaultValueSql<Guid>("UUID_GENERATE_V4()").IsRequired();

            builder.Property(oi => oi.Description).HasColumnType("character varying").HasMaxLength(1000);
            builder.Property(oi => oi.CreatedUserId).HasColumnType("uuid").ValueGeneratedNever();
            builder.Property(oi => oi.OrderId).HasColumnType("uuid").ValueGeneratedNever();

            builder.Property(oi => oi.CreatedDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(oi => oi.IsActive).HasColumnType("boolean").HasDefaultValueSql("true");

            builder.HasOne(oi => oi.Order)
               .WithMany(o => o.OrderItems)
               .HasForeignKey(o => o.OrderId)
               .HasConstraintName("fk_orderItem_order_id")
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.User)
               .WithMany(u => u.OrderItems)
               .HasForeignKey(o => o.CreatedUserId)
               .HasConstraintName("fk_orderItem_user_id")
               .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
