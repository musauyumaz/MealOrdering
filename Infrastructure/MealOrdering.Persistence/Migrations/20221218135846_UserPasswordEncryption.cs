using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealOrdering.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserPasswordEncryption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("64dec03b-3425-443f-9f5a-359410797bce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b37f0c57-7ab3-411e-9db7-82117f4e0b92"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EmailAddress", "FirstName", "IsActive", "LastName", "Password", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("aa63c583-de49-437b-8056-b1628ee2fed4"), new DateTime(2022, 12, 18, 13, 58, 46, 486, DateTimeKind.Utc).AddTicks(8923), "serhat.uyumaz26@gmail.com", "Serhat", true, "UYUMAZ", "MTIz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e733e25d-1853-4537-8d84-40eaa64c6053"), new DateTime(2022, 12, 18, 13, 58, 46, 486, DateTimeKind.Utc).AddTicks(8884), "musa.uyumaz73@gmail.com", "Musa", true, "UYUMAZ", "MTIz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("aa63c583-de49-437b-8056-b1628ee2fed4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e733e25d-1853-4537-8d84-40eaa64c6053"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EmailAddress", "FirstName", "IsActive", "LastName", "Password", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("64dec03b-3425-443f-9f5a-359410797bce"), new DateTime(2022, 12, 16, 17, 38, 14, 727, DateTimeKind.Utc).AddTicks(8386), "musa.uyumaz73@gmail.com", "Musa", true, "UYUMAZ", "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b37f0c57-7ab3-411e-9db7-82117f4e0b92"), new DateTime(2022, 12, 16, 17, 38, 14, 727, DateTimeKind.Utc).AddTicks(8391), "serhat.uyumaz26@gmail.com", "Serhat", true, "UYUMAZ", "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
