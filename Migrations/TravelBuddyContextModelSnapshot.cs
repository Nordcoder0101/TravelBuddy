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

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("TripId");

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

                    b.Property<string>("Airline");

                    b.Property<DateTime>("Arrival");

                    b.Property<string>("ArrivalCity");

                    b.Property<string>("ArrivalState");

                    b.Property<int>("DayId");

                    b.Property<string>("DepartingCity");

                    b.Property<string>("DepartingState");

                    b.Property<DateTime>("Departure");

                    b.Property<string>("FlightNumber");

                    b.HasKey("FlightId");

                    b.HasIndex("DayId");

                    b.ToTable("Flights");
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

                    b.HasIndex("UserId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("TravelBuddy.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

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
                    b.HasOne("TravelBuddy.Models.Trip", "Trip")
                        .WithMany("Day")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelBuddy.Models.Flight", b =>
                {
                    b.HasOne("TravelBuddy.Models.Day", "Day")
                        .WithMany("FlightsInDay")
                        .HasForeignKey("DayId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TravelBuddy.Models.Trip", b =>
                {
                    b.HasOne("TravelBuddy.Models.User", "User")
                        .WithMany("AllTrips")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
