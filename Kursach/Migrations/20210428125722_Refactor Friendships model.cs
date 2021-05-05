using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursach.Migrations
{
    public partial class RefactorFriendshipsmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_UsersPublicInfo_FriendId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_UsersPublicInfo_UserId",
                table: "Friendships");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_FriendId",
                table: "Friendships",
                column: "FriendId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_UserId",
                table: "Friendships",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_FriendId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_UserId",
                table: "Friendships");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_UsersPublicInfo_FriendId",
                table: "Friendships",
                column: "FriendId",
                principalTable: "UsersPublicInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_UsersPublicInfo_UserId",
                table: "Friendships",
                column: "UserId",
                principalTable: "UsersPublicInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
