using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursach.Migrations
{
    public partial class updateEventmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventImage",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "EventBannerImage",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventItemImage",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongDescription",
                table: "Events",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrizePool",
                table: "Events",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventBannerImage",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "EventItemImage",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LongDescription",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "PrizePool",
                table: "Events");

            migrationBuilder.AddColumn<byte[]>(
                name: "EventImage",
                table: "Events",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
