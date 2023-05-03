using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterSpeciesv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SpeciesId",
                table: "Race",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Race_SpeciesId",
                table: "Race",
                column: "SpeciesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Race_Especies_SpeciesId",
                table: "Race",
                column: "SpeciesId",
                principalTable: "Especies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Race_Especies_SpeciesId",
                table: "Race");

            migrationBuilder.DropIndex(
                name: "IX_Race_SpeciesId",
                table: "Race");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "Race");
        }
    }
}
