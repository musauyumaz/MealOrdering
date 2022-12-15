using MealOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Persistence.EFCoreMapping
{
    public class SupplierMapping : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.Property(s => s.Name).HasMaxLength(100);
            builder.Property(s => s.WebURL).HasMaxLength(200);
        }
    }
}


