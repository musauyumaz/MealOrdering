using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MealOrdering.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPasswordColumnForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("404661d6-b2ea-4aef-8b11-f5b91231aacb"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("85559734-1695-4183-b113-99885cab8a53"));

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EmailAddress", "FirstName", "IsActive", "LastName", "Password", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("64dec03b-3425-443f-9f5a-359410797bce"), new DateTime(2022, 12, 16, 17, 38, 14, 727, DateTimeKind.Utc).AddTicks(8386), "musa.uyumaz73@gmail.com", "Musa", true, "UYUMAZ", "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b37f0c57-7ab3-411e-9db7-82117f4e0b92"), new DateTime(2022, 12, 16, 17, 38, 14, 727, DateTimeKind.Utc).AddTicks(8391), "serhat.uyumaz26@gmail.com", "Serhat", true, "UYUMAZ", "123", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("64dec03b-3425-443f-9f5a-359410797bce"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("b37f0c57-7ab3-411e-9db7-82117f4e0b92"));

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "EmailAddress", "FirstName", "IsActive", "LastName", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("404661d6-b2ea-4aef-8b11-f5b91231aacb"), new DateTime(2022, 12, 15, 16, 15, 29, 501, DateTimeKind.Utc).AddTicks(9625), "serhat.uyumaz26@gmail.com", "Serhat", true, "UYUMAZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("85559734-1695-4183-b113-99885cab8a53"), new DateTime(2022, 12, 15, 16, 15, 29, 501, DateTimeKind.Utc).AddTicks(9619), "musa.uyumaz73@gmail.com", "Musa", true, "UYUMAZ", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
