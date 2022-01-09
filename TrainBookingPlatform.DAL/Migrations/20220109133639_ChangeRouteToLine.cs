using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainBookingPlatform.DAL.Migrations
{
    public partial class ChangeRouteToLine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Lines_LineId",
                table: "Departures");

            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Routes_RouteId",
                table: "Departures");

            migrationBuilder.DropIndex(
                name: "IX_Departures_RouteId",
                table: "Departures");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "Departures");

            migrationBuilder.AlterColumn<int>(
                name: "LineId",
                table: "Departures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Lines_LineId",
                table: "Departures",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Lines_LineId",
                table: "Departures");

            migrationBuilder.AlterColumn<int>(
                name: "LineId",
                table: "Departures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RouteId",
                table: "Departures",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departures_RouteId",
                table: "Departures",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Lines_LineId",
                table: "Departures",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Routes_RouteId",
                table: "Departures",
                column: "RouteId",
                principalTable: "Routes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
