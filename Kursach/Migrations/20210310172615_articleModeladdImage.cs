using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursach.Migrations
{
    public partial class articleModeladdImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageFileName",
                table: "Articles",
                nullable: true,
                defaultValue: "hello");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageFileName",
                table: "Articles");
        }
    }
}
