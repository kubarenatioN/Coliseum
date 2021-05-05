using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursach.Migrations
{
    public partial class addGameOrgLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrganizationLogo",
                table: "Organizations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameLogo",
                table: "Games",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganizationLogo",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "GameLogo",
                table: "Games");
        }
    }
}
