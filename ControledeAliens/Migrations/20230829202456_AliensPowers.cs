using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControledeAliens.Migrations
{
    /// <inheritdoc />
    public partial class AliensPowers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alienes_Powers_PowerId",
                table: "Alienes");

            migrationBuilder.DropIndex(
                name: "IX_Alienes_PowerId",
                table: "Alienes");

            migrationBuilder.RenameColumn(
                name: "Specie",
                table: "Alienes",
                newName: "Species");

            migrationBuilder.AddColumn<int>(
                name: "AlienId",
                table: "Powers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Powers_AlienId",
                table: "Powers",
                column: "AlienId");

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_Alienes_AlienId",
                table: "Powers",
                column: "AlienId",
                principalTable: "Alienes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Powers_Alienes_AlienId",
                table: "Powers");

            migrationBuilder.DropIndex(
                name: "IX_Powers_AlienId",
                table: "Powers");

            migrationBuilder.DropColumn(
                name: "AlienId",
                table: "Powers");

            migrationBuilder.RenameColumn(
                name: "Species",
                table: "Alienes",
                newName: "Specie");

            migrationBuilder.CreateIndex(
                name: "IX_Alienes_PowerId",
                table: "Alienes",
                column: "PowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alienes_Powers_PowerId",
                table: "Alienes",
                column: "PowerId",
                principalTable: "Powers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
