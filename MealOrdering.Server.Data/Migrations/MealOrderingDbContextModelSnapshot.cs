﻿// <auto-generated />
using System;
using MealOrdering.Server.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MealOrdering.Server.Data.Migrations
{
    [DbContext(typeof(MealOrderingDbContext))]
    partial class MealOrderingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "uuid-ossp");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MealOrdering.Server.Data.Models.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.Property<Guid>("SupplierId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_Orders_id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("SupplierId");

                    b.ToTable("Orders", "public");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<Guid>("CreatedUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id")
                        .HasName("pk_OrderItems_id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems", "public");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.Supplier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.Property<string>("WebURL")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying");

                    b.HasKey("Id")
                        .HasName("pk_suppliers_id");

                    b.ToTable("Suppliers", "public");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValueSql("true");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying");

                    b.HasKey("Id")
                        .HasName("pk_users_id");

                    b.ToTable("Users", "public");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.Order", b =>
                {
                    b.HasOne("MealOrdering.Server.Data.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_order_id");

                    b.HasOne("MealOrdering.Server.Data.Models.Supplier", "Supplier")
                        .WithMany("Orders")
                        .HasForeignKey("SupplierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_supplier_order_id");

                    b.Navigation("Supplier");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.OrderItem", b =>
                {
                    b.HasOne("MealOrdering.Server.Data.Models.User", "User")
                        .WithMany("OrderItems")
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orderItem_user_id");

                    b.HasOne("MealOrdering.Server.Data.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orderItem_order_id");

                    b.Navigation("Order");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.Supplier", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("MealOrdering.Server.Data.Models.User", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
