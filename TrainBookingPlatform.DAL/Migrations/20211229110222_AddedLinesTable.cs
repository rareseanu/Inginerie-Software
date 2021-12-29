using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainBookingPlatform.DAL.Migrations
{
    public partial class AddedLinesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Stations_DepartureStationId",
                table: "Routes");

            migrationBuilder.DropForeignKey(
                name: "FK_Routes_Stations_DestinationStationId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DepartureStationId",
                table: "Routes");

            migrationBuilder.DropIndex(
                name: "IX_Routes_DestinationStationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DepartureStationId",
                table: "Routes");

            migrationBuilder.DropColumn(
                name: "DestinationStationId",
                table: "Routes");

            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "Departures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Lines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: false),
                    DestinationStationId = table.Column<int>(type: "int", nullable: true),
                    DepartureStationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lines_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lines_Stations_DepartureStationId",
                        column: x => x.DepartureStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lines_Stations_DestinationStationId",
                        column: x => x.DestinationStationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departures_LineId",
                table: "Departures",
                column: "LineId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_DepartureStationId",
                table: "Lines",
                column: "DepartureStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_DestinationStationId",
                table: "Lines",
                column: "DestinationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Lines_RouteId",
                table: "Lines",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departures_Lines_LineId",
                table: "Departures",
                column: "LineId",
                principalTable: "Lines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departures_Lines_LineId",
                table: "Departures");

            migrationBuilder.DropTable(
                name: "Lines");

            migrationBuilder.DropIndex(
                name: "IX_Departures_LineId",
                table: "Departures");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Departures");

            migrationBuilder.AddColumn<int>(
                name: "DepartureStationId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationStationId",
                table: "Routes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DepartureStationId",
                table: "Routes",
                column: "DepartureStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Routes_DestinationStationId",
                table: "Routes",
                column: "DestinationStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Stations_DepartureStationId",
                table: "Routes",
                column: "DepartureStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Routes_Stations_DestinationStationId",
                table: "Routes",
                column: "DestinationStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
