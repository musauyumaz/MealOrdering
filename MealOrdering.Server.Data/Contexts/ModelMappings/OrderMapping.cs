using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Server.Data.Contexts.ModelMappings
{
    public class OrderMapping : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders", "public");
            builder.HasKey(o => o.Id).HasName("pk_Orders_id");

            builder.Property(o => o.Id).HasColumnType<Guid>("uuid").HasDefaultValueSql<Guid>("UUID_GENERATE_V4()").IsRequired();

            builder.Property(o => o.Name).HasColumnType("character varying").HasMaxLength(100);
            builder.Property(o => o.Description).HasColumnType("character varying").HasMaxLength(1000);
            builder.Property(o => o.CreatedUserId).HasColumnType("uuid").ValueGeneratedNever();
            builder.Property(o => o.SupplierId).HasColumnType("uuid").ValueGeneratedNever();
            builder.Property(o => o.ExpireDate).HasColumnType("timestamp without time zone").IsRequired();

            builder.Property(o => o.CreatedDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
            builder.Property(o => o.IsActive).HasColumnType("boolean").HasDefaultValueSql("true");


            builder.HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.CreatedUserId)
                .HasConstraintName("fk_user_order_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.Supplier)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SupplierId)
                .HasConstraintName("fk_supplier_order_id")
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
