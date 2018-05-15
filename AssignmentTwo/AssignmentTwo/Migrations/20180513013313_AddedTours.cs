using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssignmentTwo.Migrations
{
    public partial class AddedTours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tours",
                columns: table => new
                {
                    TourID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TicketsAvailable = table.Column<int>(nullable: false),
                    TicketsSold = table.Column<int>(nullable: false),
                    TourDuration = table.Column<int>(nullable: false),
                    TourName = table.Column<string>(nullable: true),
                    TourPrice = table.Column<decimal>(nullable: false),
                    TourTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tours", x => x.TourID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tours");
        }
    }
}
