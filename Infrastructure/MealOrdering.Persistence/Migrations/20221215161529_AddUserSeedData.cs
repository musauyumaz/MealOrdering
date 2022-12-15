using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealOrdering.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EmailAddress", "FirstName", "IsActive", "LastName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("404661d6-b2ea-4aef-8b11-f5b91231aacb"), new DateTime(2022, 12, 15, 16, 15, 29, 501, DateTimeKind.Utc).AddTicks(9625), "serhat.uyumaz26@gmail.com", "Serhat", true, "UYUMAZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85559734-1695-4183-b113-99885cab8a53"), new DateTime(2022, 12, 15, 16, 15, 29, 501, DateTimeKind.Utc).AddTicks(9619), "musa.uyumaz73@gmail.com", "Musa", true, "UYUMAZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("404661d6-b2ea-4aef-8b11-f5b91231aacb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("85559734-1695-4183-b113-99885cab8a53"));
        }
    }
}
