using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssignmentTwo.Migrations
{
    public partial class AdditionalFieldsForBookings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Bookings",
                columns: table => new
                {
                    BookingID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AdditionalLuggage = table.Column<bool>(nullable: false),
                    Passengers = table.Column<int>(nullable: false),
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "TicketClass");
        }
    }
}
