using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MealOrdering.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class initMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "suppliers",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying", maxLength: 100, nullable: false),
                    weburl = table.Column<string>(name: "web_url", type: "character varying", maxLength: 500, nullable: false),
                    createdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_supplier_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    firstname = table.Column<string>(name: "first_name", type: "character varying", maxLength: 100, nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "character varying", maxLength: 100, nullable: false),
                    emailaddress = table.Column<string>(name: "email_address", type: "character varying", maxLength: 100, nullable: false),
                    createdate = table.Column<DateTime>(name: "create_date", type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    isactive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user_id", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    supplierid = table.Column<Guid>(name: "supplier_id", type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying", maxLength: 1000, nullable: false),
                    expiredate = table.Column<DateTime>(name: "expire_date", type: "timestamp without time zone", nullable: false),
                    createdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_supplier_order_id",
                        column: x => x.supplierid,
                        principalSchema: "public",
                        principalTable: "suppliers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_user_order_id",
                        column: x => x.userid,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "public",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userid = table.Column<Guid>(name: "user_id", type: "uuid", nullable: false),
                    orderid = table.Column<Guid>(name: "order_id", type: "uuid", nullable: false),
                    description = table.Column<string>(type: "character varying", maxLength: 1000, nullable: false),
                    createdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_orderItem_id", x => x.id);
                    table.ForeignKey(
                        name: "fk_orderitems_order_id",
                        column: x => x.orderid,
                        principalSchema: "public",
                        principalTable: "orders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_orderitems_user_id",
                        column: x => x.userid,
                        principalSchema: "public",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_items_order_id",
                schema: "public",
                table: "order_items",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_user_id",
                schema: "public",
                table: "order_items",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_supplier_id",
                schema: "public",
                table: "orders",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_user_id",
                schema: "public",
                table: "orders",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_items",
                schema: "public");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "suppliers",
                schema: "public");

            migrationBuilder.DropTable(
                name: "user",
                schema: "public");
        }
    }
}
