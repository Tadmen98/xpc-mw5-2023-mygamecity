using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameCity.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GameReviewCategoryRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Categories_CategoryEntityId",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_CategoryEntityId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "Game");

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

            migrationBuilder.CreateIndex(
                name: "IX_CategoryEntityGameEntity_GamesId",
                table: "CategoryEntityGameEntity",
                column: "GamesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryEntityGameEntity");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryEntityId",
                table: "Game",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Game_CategoryEntityId",
                table: "Game",
                column: "CategoryEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_Categories_CategoryEntityId",
                table: "Game",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");
        }
    }
}
