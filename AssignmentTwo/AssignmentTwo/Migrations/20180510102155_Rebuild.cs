using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssignmentTwo.Migrations
{
    public partial class Rebuild : Migration
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
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TicketClass",
                columns: table => new
                {
                    TicketClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketClassType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketClass", x => x.TicketClassID);
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
                    Price = table.Column<decimal>(nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalLuggage = table.Column<bool>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    Passengers = table.Column<int>(nullable: false),
                    PassengersName = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    PrimaryFlightFlightID = table.Column<int>(nullable: true),
                    ReturnFlightFlightID = table.Column<int>(nullable: true),
                    ReturnTrip = table.Column<bool>(nullable: false),
                    TicketClassID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingID);
                    table.ForeignKey(
                        name: "FK_Bookings_Flight_PrimaryFlightFlightID",
                        column: x => x.PrimaryFlightFlightID,
                        principalTable: "Flight",
                        principalColumn: "FlightID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Flight_ReturnFlightFlightID",
                        column: x => x.ReturnFlightFlightID,
                        principalTable: "Flight",
                        principalColumn: "FlightID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_TicketClass_TicketClassID",
                        column: x => x.TicketClassID,
                        principalTable: "TicketClass",
                        principalColumn: "TicketClassID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PrimaryFlightFlightID",
                table: "Bookings",
                column: "PrimaryFlightFlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ReturnFlightFlightID",
                table: "Bookings",
                column: "ReturnFlightFlightID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TicketClassID",
                table: "Bookings",
                column: "TicketClassID");

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
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Flight");

            migrationBuilder.DropTable(
                name: "TicketClass");

            migrationBuilder.DropTable(
                name: "Airports");
        }
    }
}
