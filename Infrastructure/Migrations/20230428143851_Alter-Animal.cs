using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterAnimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_AnimalSize_SizeId",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "SizeId",
                table: "Animal",
                newName: "AnimalSizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_SizeId",
                table: "Animal",
                newName: "IX_Animal_AnimalSizeId");

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Animal",
                type: "nvarchar(1)",
                maxLength: 1,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_AnimalSize_AnimalSizeId",
                table: "Animal",
                column: "AnimalSizeId",
                principalTable: "AnimalSize",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animal_AnimalSize_AnimalSizeId",
                table: "Animal");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "AnimalSizeId",
                table: "Animal",
                newName: "SizeId");

            migrationBuilder.RenameIndex(
                name: "IX_Animal_AnimalSizeId",
                table: "Animal",
                newName: "IX_Animal_SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animal_AnimalSize_SizeId",
                table: "Animal",
                column: "SizeId",
                principalTable: "AnimalSize",
                principalColumn: "Id");
        }
    }
}
