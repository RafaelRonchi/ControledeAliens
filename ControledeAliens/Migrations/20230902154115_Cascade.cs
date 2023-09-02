using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControledeAliens.Migrations
{
    /// <inheritdoc />
    public partial class Cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Powers_Aliens_AlienId",
                table: "Powers");

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_Aliens_AlienId",
                table: "Powers",
                column: "AlienId",
                principalTable: "Aliens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Powers_Aliens_AlienId",
                table: "Powers");

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_Aliens_AlienId",
                table: "Powers",
                column: "AlienId",
                principalTable: "Aliens",
                principalColumn: "Id");
        }
    }
}
