using MealOrdering.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Persistence.EFCoreMapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FirstName).HasMaxLength(50);
            builder.Property(u => u.LastName).HasMaxLength(50);
            builder.Property(u => u.EmailAddress).HasMaxLength(100);

            builder.HasData(
                new User() { Id = Guid.NewGuid(), FirstName = "Musa", LastName = "UYUMAZ", EmailAddress = "musa.uyumaz73@gmail.com", IsActive = true, CreatedDate = DateTime.UtcNow },
                new User() { Id = Guid.NewGuid(), FirstName = "Serhat", LastName = "UYUMAZ", EmailAddress = "serhat.uyumaz26@gmail.com", IsActive = true, CreatedDate = DateTime.UtcNow }
                );
        }
    }
}


