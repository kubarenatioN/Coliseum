﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursach.Migrations
{
    public partial class addGamesUsersconnection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_UsersPublicInfo_UserPublicInfoId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserPublicInfoId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserPublicInfoId",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "UsersGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPublicInfoId = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersGames_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersGames_UsersPublicInfo_UserPublicInfoId",
                        column: x => x.UserPublicInfoId,
                        principalTable: "UsersPublicInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersGames_GameId",
                table: "UsersGames",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersGames_UserPublicInfoId",
                table: "UsersGames",
                column: "UserPublicInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersGames");

            migrationBuilder.AddColumn<int>(
                name: "UserPublicInfoId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserPublicInfoId",
                table: "Games",
                column: "UserPublicInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_UsersPublicInfo_UserPublicInfoId",
                table: "Games",
                column: "UserPublicInfoId",
                principalTable: "UsersPublicInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
