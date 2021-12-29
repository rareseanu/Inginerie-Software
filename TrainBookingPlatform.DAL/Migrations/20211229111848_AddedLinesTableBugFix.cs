using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainBookingPlatform.DAL.Migrations
{
    public partial class AddedLinesTableBugFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RouteNumber",
                table: "Routes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RouteNumber",
                table: "Routes");
        }
    }
}
