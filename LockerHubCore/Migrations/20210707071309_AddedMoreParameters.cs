using Microsoft.EntityFrameworkCore.Migrations;

namespace LockerHubCore.Migrations
{
    public partial class AddedMoreParameters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Lockers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Lockers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Lockers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Lockers");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Lockers");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Lockers");
        }
    }
}
