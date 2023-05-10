using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameCity.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GameReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Game",
                newName: "Title");

            migrationBuilder.CreateTable(
                name: "DeveloperEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImg = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeveloperEntity", x => x.Id);
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
                name: "IX_DeveloperEntityGameEntity_GameListId",
                table: "DeveloperEntityGameEntity",
                column: "GameListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeveloperEntityGameEntity");

            migrationBuilder.DropTable(
                name: "DeveloperEntity");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Game",
                newName: "Name");
        }
    }
}
