using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyGameCity.DAL.Migrations
{
    /// <inheritdoc />
    public partial class GameReviewRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Comodity_GameId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comodity",
                table: "Comodity");

            migrationBuilder.RenameTable(
                name: "Comodity",
                newName: "Game");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryEntityId",
                table: "Game",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Game",
                table: "Game",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Game_GameId",
                table: "Review",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_Categories_CategoryEntityId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Game_GameId",
                table: "Review");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Game",
                table: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Game_CategoryEntityId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "CategoryEntityId",
                table: "Game");

            migrationBuilder.RenameTable(
                name: "Game",
                newName: "Comodity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comodity",
                table: "Comodity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Comodity_GameId",
                table: "Review",
                column: "GameId",
                principalTable: "Comodity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
