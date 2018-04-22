using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssignmentTwo.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    AirportID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AirportCode = table.Column<string>(nullable: true),
                    AirportLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.AirportID);
                });

            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DepartureAirportID = table.Column<int>(nullable: true),
                    DepartureDate = table.Column<DateTime>(nullable: false),
                    DestinationAirportID = table.Column<int>(nullable: true),
                    FlightCapacity = table.Column<int>(nullable: false),
                    SeatsAvailable = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightID);
                    table.ForeignKey(
                        name: "FK_Flight_Airports_DepartureAirportID",
                        column: x => x.DepartureAirportID,
                        principalTable: "Airports",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flight_Airports_DestinationAirportID",
                        column: x => x.DestinationAirportID,
                        principalTable: "Airports",
                        principalColumn: "AirportID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureAirportID",
                table: "Flight",
                column: "DepartureAirportID");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DestinationAirportID",
                table: "Flight",
                column: "DestinationAirportID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
