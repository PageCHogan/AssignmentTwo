﻿// <auto-generated />
using AssignmentTwo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AssignmentTwo.Migrations
{
    [DbContext(typeof(AroundTheWorldContext))]
    [Migration("20180515083629_AdditionalTourInformation")]
    partial class AdditionalTourInformation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AssignmentTwo.Models.Airports", b =>
                {
                    b.Property<int>("AirportID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AirportCode");

                    b.Property<string>("AirportLocation");

                    b.HasKey("AirportID");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("AssignmentTwo.Models.Bookings", b =>
                {
                    b.Property<int>("BookingID")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AdditionalLuggage");

                    b.Property<string>("EmailAddress");

                    b.Property<int>("Passengers");

                    b.Property<string>("PassengersName");

                    b.Property<int>("PassportNumber");

                    b.Property<decimal>("Price");

                    b.Property<int?>("PrimaryFlightFlightID");

                    b.Property<int?>("ReturnFlightFlightID");

                    b.Property<bool>("ReturnTrip");

                    b.Property<int?>("TicketClassID");

                    b.Property<string>("UserID");

                    b.HasKey("BookingID");

                    b.HasIndex("PrimaryFlightFlightID");

                    b.HasIndex("ReturnFlightFlightID");

                    b.HasIndex("TicketClassID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("AssignmentTwo.Models.Contact.Contact", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Message")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("AssignmentTwo.Models.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartureAirportID");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int?>("DestinationAirportID");

                    b.Property<int>("FlightCapacity");

                    b.Property<decimal>("Price");

                    b.Property<int>("SeatsAvailable");

                    b.HasKey("FlightID");

                    b.HasIndex("DepartureAirportID");

                    b.HasIndex("DestinationAirportID");

                    b.ToTable("Flight");
                });

            modelBuilder.Entity("AssignmentTwo.Models.TicketClass", b =>
                {
                    b.Property<int>("TicketClassID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TicketClassType");

                    b.HasKey("TicketClassID");

                    b.ToTable("TicketClass");
                });

            modelBuilder.Entity("AssignmentTwo.Models.Tours", b =>
                {
                    b.Property<int>("TourID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AdditionalInformation");

                    b.Property<int>("TicketsAvailable");

                    b.Property<int>("TicketsSold");

                    b.Property<int>("TourDuration");

                    b.Property<string>("TourName");

                    b.Property<decimal>("TourPrice");

                    b.Property<DateTime>("TourTime");

                    b.HasKey("TourID");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("AssignmentTwo.Models.Bookings", b =>
                {
                    b.HasOne("AssignmentTwo.Models.Flight", "PrimaryFlight")
                        .WithMany()
                        .HasForeignKey("PrimaryFlightFlightID");

                    b.HasOne("AssignmentTwo.Models.Flight", "ReturnFlight")
                        .WithMany()
                        .HasForeignKey("ReturnFlightFlightID");

                    b.HasOne("AssignmentTwo.Models.TicketClass", "TicketClass")
                        .WithMany()
                        .HasForeignKey("TicketClassID");
                });

            modelBuilder.Entity("AssignmentTwo.Models.Flight", b =>
                {
                    b.HasOne("AssignmentTwo.Models.Airports", "Departure")
                        .WithMany()
                        .HasForeignKey("DepartureAirportID");

                    b.HasOne("AssignmentTwo.Models.Airports", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationAirportID");
                });
#pragma warning restore 612, 618
        }
    }
}
