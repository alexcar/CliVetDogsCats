using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class insertentryproducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductEntryHeader",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SupplierId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntryHeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntryHeader_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEntryHeader_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductEntry",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CostValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductEntryHeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntry_ProductEntryHeader_ProductEntryHeaderId",
                        column: x => x.ProductEntryHeaderId,
                        principalTable: "ProductEntryHeader",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProductEntry_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntry_ProductEntryHeaderId",
                table: "ProductEntry",
                column: "ProductEntryHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntry_ProductId",
                table: "ProductEntry",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntryHeader_EmployeeId",
                table: "ProductEntryHeader",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntryHeader_SupplierId",
                table: "ProductEntryHeader",
                column: "SupplierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductEntry");

            migrationBuilder.DropTable(
                name: "ProductEntryHeader");
        }
    }
}
