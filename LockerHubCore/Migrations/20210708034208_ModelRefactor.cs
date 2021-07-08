using Microsoft.EntityFrameworkCore.Migrations;

namespace LockerHubCore.Migrations
{
    public partial class ModelRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Lockers");

            migrationBuilder.AddColumn<int>(
                name: "NoAvailable",
                table: "Lockers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoAvailable",
                table: "Lockers");

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Lockers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
