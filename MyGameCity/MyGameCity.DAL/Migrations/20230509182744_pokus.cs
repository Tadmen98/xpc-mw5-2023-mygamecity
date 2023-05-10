using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameCity.DAL.Migrations
{
    /// <inheritdoc />
    public partial class pokus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEntityGameEntity");

            migrationBuilder.DropTable(
                name: "DeveloperEntityGameEntity");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "DeveloperEntity");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryEntityGameEntity",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GamesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryEntityGameEntity", x => new { x.CategoryId, x.GamesId });
                    table.ForeignKey(
                        name: "FK_CategoryEntityGameEntity_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryEntityGameEntity_Game_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeveloperEntityGameEntity",
                columns: table => new
                {
                    DeveloperId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GameListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperEntityGameEntity", x => new { x.DeveloperId, x.GameListId });
                    table.ForeignKey(
                        name: "FK_DeveloperEntityGameEntity_DeveloperEntity_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "DeveloperEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeveloperEntityGameEntity_Game_GameListId",
                        column: x => x.GameListId,
                        principalTable: "Game",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEntityGameEntity_GamesId",
                table: "CategoryEntityGameEntity",
                column: "GamesId");

            migrationBuilder.CreateIndex(
                name: "IX_DeveloperEntityGameEntity_GameListId",
                table: "DeveloperEntityGameEntity",
                column: "GameListId");
        }
    }
}
