using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Number = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    State = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkShift",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monday = table.Column<bool>(type: "bit", nullable: false),
                    MondayFrom = table.Column<byte>(type: "tinyint", nullable: true),
                    MondayTo = table.Column<byte>(type: "tinyint", nullable: true),
                    Tuesday = table.Column<bool>(type: "bit", nullable: false),
                    TuesdayFrom = table.Column<byte>(type: "tinyint", nullable: true),
                    TuesdayTo = table.Column<byte>(type: "tinyint", nullable: true),
                    Wednesday = table.Column<bool>(type: "bit", nullable: false),
                    WednesdayFrom = table.Column<byte>(type: "tinyint", nullable: true),
                    WednesdayTo = table.Column<byte>(type: "tinyint", nullable: true),
                    Thursday = table.Column<bool>(type: "bit", nullable: false),
                    ThursdayFrom = table.Column<byte>(type: "tinyint", nullable: true),
                    ThursdayTo = table.Column<byte>(type: "tinyint", nullable: true),
                    Friday = table.Column<bool>(type: "bit", nullable: false),
                    FridayFrom = table.Column<byte>(type: "tinyint", nullable: true),
                    FridayTo = table.Column<byte>(type: "tinyint", nullable: true),
                    Saturday = table.Column<bool>(type: "bit", nullable: false),
                    SaturdayFrom = table.Column<byte>(type: "tinyint", nullable: true),
                    SaturdayTo = table.Column<byte>(type: "tinyint", nullable: true),
                    Sunday = table.Column<bool>(type: "bit", nullable: false),
                    SundayFrom = table.Column<byte>(type: "tinyint", nullable: true),
                    SundayTo = table.Column<byte>(type: "tinyint", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkShift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Trade = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Contact = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cnpj = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CostValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    ProfitMargin = table.Column<int>(type: "int", nullable: false),
                    SaleValue = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brand",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    CellPhone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsVeterinarian = table.Column<bool>(type: "bit", nullable: false),
                    AddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkShiftId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValueSql: "1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_WorkShift_WorkShiftId",
                        column: x => x.WorkShiftId,
                        principalTable: "WorkShift",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_ZipCode",
                table: "Address",
                column: "ZipCode");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AddressId",
                table: "Employee",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Name",
                table: "Employee",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WorkShiftId",
                table: "Employee",
                column: "WorkShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandId",
                table: "Product",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_AddressId",
                table: "Supplier",
                column: "AddressId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "WorkShift");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
