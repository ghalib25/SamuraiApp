using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class swordsamurai : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Swords",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    productionYear = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    samuraiId = table.Column<int>(type: "int", nullable: false),
                    samuraiName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Swords", x => x.id);
                    table.ForeignKey(
                        name: "FK_Swords_Samurais_samuraiId",
                        column: x => x.samuraiId,
                        principalTable: "Samurais",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SwordElements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    elementname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    swordId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwordElements", x => x.id);
                    table.ForeignKey(
                        name: "FK_SwordElements_Swords_swordId",
                        column: x => x.swordId,
                        principalTable: "Swords",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SwordElements_swordId",
                table: "SwordElements",
                column: "swordId");

            migrationBuilder.CreateIndex(
                name: "IX_Swords_samuraiId",
                table: "Swords",
                column: "samuraiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SwordElements");

            migrationBuilder.DropTable(
                name: "Swords");
        }
    }
}
