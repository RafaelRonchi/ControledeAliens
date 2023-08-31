using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControledeAliens.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alienes_Planets_PlanetId",
                table: "Alienes");

            migrationBuilder.DropForeignKey(
                name: "FK_Earth_Alienes_AlienId",
                table: "Earth");

            migrationBuilder.DropForeignKey(
                name: "FK_Powers_Alienes_AlienId",
                table: "Powers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Earth",
                table: "Earth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alienes",
                table: "Alienes");

            migrationBuilder.RenameTable(
                name: "Earth",
                newName: "AlienEntriesExits");

            migrationBuilder.RenameTable(
                name: "Alienes",
                newName: "Aliens");

            migrationBuilder.RenameIndex(
                name: "IX_Earth_AlienId",
                table: "AlienEntriesExits",
                newName: "IX_AlienEntriesExits_AlienId");

            migrationBuilder.RenameIndex(
                name: "IX_Alienes_PlanetId",
                table: "Aliens",
                newName: "IX_Aliens_PlanetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AlienEntriesExits",
                table: "AlienEntriesExits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aliens",
                table: "Aliens",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AlienEntriesExits_Aliens_AlienId",
                table: "AlienEntriesExits",
                column: "AlienId",
                principalTable: "Aliens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aliens_Planets_PlanetId",
                table: "Aliens",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_Aliens_AlienId",
                table: "Powers",
                column: "AlienId",
                principalTable: "Aliens",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AlienEntriesExits_Aliens_AlienId",
                table: "AlienEntriesExits");

            migrationBuilder.DropForeignKey(
                name: "FK_Aliens_Planets_PlanetId",
                table: "Aliens");

            migrationBuilder.DropForeignKey(
                name: "FK_Powers_Aliens_AlienId",
                table: "Powers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aliens",
                table: "Aliens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AlienEntriesExits",
                table: "AlienEntriesExits");

            migrationBuilder.RenameTable(
                name: "Aliens",
                newName: "Alienes");

            migrationBuilder.RenameTable(
                name: "AlienEntriesExits",
                newName: "Earth");

            migrationBuilder.RenameIndex(
                name: "IX_Aliens_PlanetId",
                table: "Alienes",
                newName: "IX_Alienes_PlanetId");

            migrationBuilder.RenameIndex(
                name: "IX_AlienEntriesExits_AlienId",
                table: "Earth",
                newName: "IX_Earth_AlienId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alienes",
                table: "Alienes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Earth",
                table: "Earth",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Alienes_Planets_PlanetId",
                table: "Alienes",
                column: "PlanetId",
                principalTable: "Planets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Earth_Alienes_AlienId",
                table: "Earth",
                column: "AlienId",
                principalTable: "Alienes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Powers_Alienes_AlienId",
                table: "Powers",
                column: "AlienId",
                principalTable: "Alienes",
                principalColumn: "Id");
        }
    }
}
