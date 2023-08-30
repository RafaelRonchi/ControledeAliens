using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControledeAliens.Migrations
{
    /// <inheritdoc />
    public partial class EarthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "População",
                table: "Planets",
                newName: "Population");

            migrationBuilder.CreateTable(
                name: "Earth",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlienId = table.Column<int>(type: "int", nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExitTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Earth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Earth_Alienes_AlienId",
                        column: x => x.AlienId,
                        principalTable: "Alienes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Earth_AlienId",
                table: "Earth",
                column: "AlienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Earth");

            migrationBuilder.RenameColumn(
                name: "Population",
                table: "Planets",
                newName: "População");
        }
    }
}
