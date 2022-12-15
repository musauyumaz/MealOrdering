using MealOrdering.Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Data.Contexts
{
    public class MealOrderingDbContext : DbContext
    {
        public MealOrderingDbContext(DbContextOptions<MealOrderingDbContext> options) : base(options){}

        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user", "public");

                entity.HasKey(u => u.Id).HasName("pk_user_id");

                entity.Property(u => u.Id).HasColumnName("id").HasColumnType("uuid").ValueGeneratedOnAdd().IsRequired();
                entity.Property(u => u.FirstName).HasColumnName("first_name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(u => u.LastName).HasColumnName("last_name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(u => u.EmailAddress).HasColumnName("email_address").HasColumnType("character varying").HasMaxLength(100);
                //entity.Property(u => u.Password).HasColumnName("password").HasColumnType("character varying").HasMaxLength(250);

                entity.Property(u => u.CreatedDate).HasColumnName("create_date").HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("NOW()");

                entity.Property(u => u.IsActive).HasColumnName("isactive").HasColumnType("boolean");
            });


            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(s => s.Id)
                    .HasName("pk_supplier_id");

                entity.ToTable("suppliers", "public");

                entity.Property(s => s.Id).HasColumnName("id").HasColumnType("uuid").ValueGeneratedOnAdd().IsRequired();

                entity.Property(s => s.IsActive).HasColumnName("isactive").HasColumnType("boolean");
                entity.Property(s => s.Name).HasColumnName("name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(s => s.CreatedDate).HasColumnName("createdate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();

                entity.Property(s => s.WebURL).HasColumnName("web_url").HasColumnType("character varying").HasMaxLength(500);
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id)
                    .HasName("pk_order_id");

                entity.ToTable("orders", "public");

                entity.Property(o => o.Id).HasColumnName("id").HasColumnType("uuid").ValueGeneratedOnAdd().IsRequired();
                entity.Property(o => o.Name).HasColumnName("name").HasColumnType("character varying").HasMaxLength(100);
                entity.Property(o => o.Description).HasColumnName("description").HasColumnType("character varying").HasMaxLength(1000);

                entity.Property(o => o.CreatedDate).HasColumnName("createdate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()").ValueGeneratedOnAdd();
                entity.Property(o => o.UserId).HasColumnName("user_id").HasColumnType("uuid");
                entity.Property(o => o.SupplierId).HasColumnName("supplier_id").HasColumnType("uuid").IsRequired().ValueGeneratedNever();
                entity.Property(o => o.ExpireDate).HasColumnName("expire_date").HasColumnType("timestamp without time zone").IsRequired();


                entity.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(d => d.UserId)
                   .HasConstraintName("fk_user_order_id")
                   .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(o => o.Supplier)
                   .WithMany(s => s.Orders)
                   .HasForeignKey(o => o.SupplierId)
                   .HasConstraintName("fk_supplier_order_id")
                   .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(oi => oi.Id)
                    .HasName("pk_orderItem_id");

                entity.ToTable("order_items", "public");

                entity.Property(oi => oi.Id).HasColumnName("id").HasColumnType("uuid").ValueGeneratedOnAdd().IsRequired();
                entity.Property(oi => oi.Description).HasColumnName("description").HasColumnType("character varying").HasMaxLength(1000);
                entity.Property(oi => oi.CreatedDate).HasColumnName("createdate").HasColumnType("timestamp without time zone").HasDefaultValueSql("NOW()");
                entity.Property(oi => oi.UserId).HasColumnName("user_id").HasColumnType("uuid");
                entity.Property(oi => oi.OrderId).HasColumnName("order_id").HasColumnType("uuid");


                entity.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId)
                   .HasConstraintName("fk_orderitems_order_id")
                   .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(oi => oi.User)
                   .WithMany(u => u.OrderItems)
                   .HasForeignKey(oi => oi.UserId)
                   .HasConstraintName("fk_orderitems_user_id")
                   .OnDelete(DeleteBehavior.Cascade);

            });

        }
    }
}
