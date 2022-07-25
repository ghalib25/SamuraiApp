using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SamuraiApp.Data.Migrations
{
    public partial class lastest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swords_Samurais_samuraiId",
                table: "Swords");

            migrationBuilder.DropTable(
                name: "SwordElements");

            migrationBuilder.DropColumn(
                name: "samuraiName",
                table: "Swords");

            migrationBuilder.RenameColumn(
                name: "samuraiId",
                table: "Swords",
                newName: "SamuraiId");

            migrationBuilder.RenameColumn(
                name: "productionYear",
                table: "Swords",
                newName: "ProductionYear");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Swords",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Swords",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Swords_samuraiId",
                table: "Swords",
                newName: "IX_Swords_SamuraiId");

            migrationBuilder.AlterColumn<int>(
                name: "SamuraiId",
                table: "Swords",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ProductionYear",
                table: "Swords",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Elements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Elements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElementSword",
                columns: table => new
                {
                    ElementsId = table.Column<int>(type: "int", nullable: false),
                    SwordsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementSword", x => new { x.ElementsId, x.SwordsId });
                    table.ForeignKey(
                        name: "FK_ElementSword_Elements_ElementsId",
                        column: x => x.ElementsId,
                        principalTable: "Elements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElementSword_Swords_SwordsId",
                        column: x => x.SwordsId,
                        principalTable: "Swords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ElementSword_SwordsId",
                table: "ElementSword",
                column: "SwordsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords",
                column: "SamuraiId",
                principalTable: "Samurais",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Swords_Samurais_SamuraiId",
                table: "Swords");

            migrationBuilder.DropTable(
                name: "ElementSword");

            migrationBuilder.DropTable(
                name: "Elements");

            migrationBuilder.RenameColumn(
                name: "SamuraiId",
                table: "Swords",
                newName: "samuraiId");

            migrationBuilder.RenameColumn(
                name: "ProductionYear",
                table: "Swords",
                newName: "productionYear");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Swords",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Swords",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Swords_SamuraiId",
                table: "Swords",
                newName: "IX_Swords_samuraiId");

            migrationBuilder.AlterColumn<int>(
                name: "samuraiId",
                table: "Swords",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "productionYear",
                table: "Swords",
                type: "int",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "samuraiName",
                table: "Swords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SwordElements",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    swordId = table.Column<int>(type: "int", nullable: false),
                    elementname = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.AddForeignKey(
                name: "FK_Swords_Samurais_samuraiId",
                table: "Swords",
                column: "samuraiId",
                principalTable: "Samurais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
