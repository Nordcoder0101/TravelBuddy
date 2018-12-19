﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelBuddy.Models;

namespace TravelBuddy.Migrations
{
    [DbContext(typeof(TravelBuddyContext))]
    partial class TravelBuddyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("TravelBuddy.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CreatorId");

                    b.Property<string>("CreatorName");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("ActivityId");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("TravelBuddy.Models.ActivityAndDay", b =>
                {
                    b.Property<int>("ActivityAndDayId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ActivityId");

                    b.Property<int?>("DayId");

                    b.Property<int>("UserId");

                    b.HasKey("ActivityAndDayId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("DayId");

                    b.ToTable("ActivityAndDays");
                });

            modelBuilder.Entity("TravelBuddy.Models.Day", b =>
                {
                    b.Property<int>("DayId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DayOfTheWeek");

                    b.Property<DateTime>("TheDay");

                    b.Property<int>("TripId");

                    b.HasKey("DayId");

                    b.HasIndex("TripId");

                    b.ToTable("Days");
                });

            modelBuilder.Entity("TravelBuddy.Models.Flight", b =>
                {
                    b.Property<int>("FlightId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Airline")
                        .IsRequired();

                    b.Property<DateTime>("Arrival");

                    b.Property<string>("ArrivalCity")
                        .IsRequired();

                    b.Property<int>("DayId");

                    b.Property<string>("DepartingCity")
                        .IsRequired();

                    b.Property<DateTime>("Departure");

                    b.Property<string>("FlightNumber");

                    b.Property<int?>("TripId");

                    b.HasKey("FlightId");

                    b.HasIndex("DayId");

                    b.HasIndex("TripId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("TravelBuddy.Models.RoadTrip", b =>
                {
                    b.Property<int>("DriveId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayId");

                    b.Property<string>("Destination")
                        .IsRequired();

                    b.Property<DateTime>("StartDateTime");

                    b.Property<string>("StartingPoint")
                        .IsRequired();

                    b.Property<int?>("TripId");

                    b.HasKey("DriveId");

                    b.HasIndex("DayId");

                    b.HasIndex("TripId");

                    b.ToTable("RoadTrips");
                });

            modelBuilder.Entity("TravelBuddy.Models.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EndDate");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("TripName");

                    b.Property<int>("UserId");

                    b.HasKey("TripId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TravelBuddy.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TravelBuddy.Models.ActivityAndDay", b =>
                {
                    b.HasOne("TravelBuddy.Models.Activity", "Activity")
                        .WithMany("ActivityAndDays")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelBuddy.Models.Day", "Day")
                        .WithMany("ActivityAndDays")
                        .HasForeignKey("DayId");
                });

            modelBuilder.Entity("TravelBuddy.Models.Day", b =>
                {
                    b.HasOne("TravelBuddy.Models.Trip")
                        .WithMany("DaysInTrip")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelBuddy.Models.Flight", b =>
                {
                    b.HasOne("TravelBuddy.Models.Day")
                        .WithMany("Flights")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelBuddy.Models.Trip")
                        .WithMany("FlightsInTrip")
                        .HasForeignKey("TripId");
                });

            modelBuilder.Entity("TravelBuddy.Models.RoadTrip", b =>
                {
                    b.HasOne("TravelBuddy.Models.Day")
                        .WithMany("RoadTrips")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TravelBuddy.Models.Trip")
                        .WithMany("RoadTripsForTrip")
                        .HasForeignKey("TripId");
                });
#pragma warning restore 612, 618
        }
    }
}
