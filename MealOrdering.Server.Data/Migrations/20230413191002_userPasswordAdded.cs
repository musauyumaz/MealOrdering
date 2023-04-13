using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealOrdering.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class userPasswordAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                schema: "public",
                table: "Users",
                type: "character varying",
                maxLength: 250,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                schema: "public",
                table: "Users");
        }
    }
}
