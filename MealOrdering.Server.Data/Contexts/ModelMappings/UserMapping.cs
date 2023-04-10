using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MealOrdering.Server.Data.Contexts.ModelMappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users","public");
            builder.HasKey(u => u.Id).HasName("pk_users_id");

            builder.Property(u=>u.Id).HasColumnType<Guid>("uuid").HasDefaultValueSql<Guid>("uuid_generate_v4()").IsRequired() ;

            builder.Property(u => u.FirstName).HasColumnType("character varying").HasMaxLength(100);
            builder.Property(u => u.LastName).HasColumnType("character varying").HasMaxLength(100);
            builder.Property(u => u.EmailAddress).HasColumnType("character varying").HasMaxLength(100);

            builder.Property(u => u.CreatedDate).HasColumnType("timestamp without time zone").HasDefaultValueSql("now()").ValueGeneratedOnAdd();
            builder.Property(u => u.IsActive).HasColumnType("boolean").HasDefaultValueSql("true");
        }
    }
}
