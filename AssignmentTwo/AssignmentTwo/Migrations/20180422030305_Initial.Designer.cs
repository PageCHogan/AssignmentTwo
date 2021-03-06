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
    [Migration("20180422030305_Initial")]
    partial class Initial
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

            modelBuilder.Entity("AssignmentTwo.Models.Flight", b =>
                {
                    b.Property<int>("FlightID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DepartureAirportID");

                    b.Property<DateTime>("DepartureDate");

                    b.Property<int?>("DestinationAirportID");

                    b.Property<int>("FlightCapacity");

                    b.Property<int>("SeatsAvailable");

                    b.HasKey("FlightID");

                    b.HasIndex("DepartureAirportID");

                    b.HasIndex("DestinationAirportID");

                    b.ToTable("Flight");
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
