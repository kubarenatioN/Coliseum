using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursach.Migrations
{
    public partial class addUserstuff : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserPublicInfoId",
                table: "Games",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ColorThemes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColorThemes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersAccountInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    BannerImage = table.Column<string>(nullable: true),
                    AvatarImage = table.Column<byte[]>(nullable: true),
                    ColorThemeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersAccountInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersAccountInfo_ColorThemes_ColorThemeId",
                        column: x => x.ColorThemeId,
                        principalTable: "ColorThemes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersAccountInfo_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersPublicInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPublicInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersPublicInfo_Users_Id",
                        column: x => x.Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserPublicInfoId",
                table: "Games",
                column: "UserPublicInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserId",
                table: "Users",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersAccountInfo_ColorThemeId",
                table: "UsersAccountInfo",
                column: "ColorThemeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_UsersPublicInfo_UserPublicInfoId",
                table: "Games",
                column: "UserPublicInfoId",
                principalTable: "UsersPublicInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_UsersPublicInfo_UserPublicInfoId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "UsersAccountInfo");

            migrationBuilder.DropTable(
                name: "UsersPublicInfo");

            migrationBuilder.DropTable(
                name: "ColorThemes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Games_UserPublicInfoId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserPublicInfoId",
                table: "Games");
        }
    }
}
