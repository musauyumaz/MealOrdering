using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Server.Data.Contexts.ModelMappings
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.ToTable("Suppliers", "public");
            builder.HasKey(s => s.Id).HasName("pk_suppliers_id");

            builder.Property(s => s.Id).HasColumnType<Guid>("uuid").HasDefaultValueSql<Guid>("uuid_generate_v4()").IsRequired();

            builder.Property(s => s.Name).HasColumnType("character varying").HasMaxLength(100);
            builder.Property(s => s.WebURL).HasColumnType("character varying").HasMaxLength(500);

            builder.Property(s => s.CreatedDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("now()").ValueGeneratedOnAdd();
            builder.Property(s => s.IsActive).HasColumnType("boolean").HasDefaultValueSql("true");

        }
    }
}
