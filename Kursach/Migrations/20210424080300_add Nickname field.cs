using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursach.Migrations
{
    public partial class addNicknamefield : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "UsersPublicInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "UsersPublicInfo");
        }
    }
}
