﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainBookingPlatform.DAL.Repository;

namespace TrainBookingPlatform.DAL.Migrations
{
    [DbContext(typeof(TrainBookingPlatformDbContext))]
    partial class TrainBookingPlatformDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DepartureTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LineId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LineId");

                    b.HasIndex("RouteId");

                    b.HasIndex("TrainId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Line", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("DepartureStationId")
                        .HasColumnType("int");

                    b.Property<int?>("DestinationStationId")
                        .HasColumnType("int");

                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartureStationId");

                    b.HasIndex("DestinationStationId");

                    b.HasIndex("RouteId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpiresAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RouteNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Station", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfLines")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartureId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchasedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WagonNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DepartureId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Wagon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("TrainId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Wagons");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Departure", b =>
                {
                    b.HasOne("TrainBookingPlatform.DAL.Entities.Line", null)
                        .WithMany("Departures")
                        .HasForeignKey("LineId");

                    b.HasOne("TrainBookingPlatform.DAL.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainBookingPlatform.DAL.Entities.Train", "Train")
                        .WithMany("Departures")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");

                    b.Navigation("Train");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Line", b =>
                {
                    b.HasOne("TrainBookingPlatform.DAL.Entities.Station", "DepartureStation")
                        .WithMany("DepartureRoutes")
                        .HasForeignKey("DepartureStationId");

                    b.HasOne("TrainBookingPlatform.DAL.Entities.Station", "DestinationStation")
                        .WithMany("DestinationRoutes")
                        .HasForeignKey("DestinationStationId");

                    b.HasOne("TrainBookingPlatform.DAL.Entities.Route", "Route")
                        .WithMany()
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DepartureStation");

                    b.Navigation("DestinationStation");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.RefreshToken", b =>
                {
                    b.HasOne("TrainBookingPlatform.DAL.Entities.User", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Ticket", b =>
                {
                    b.HasOne("TrainBookingPlatform.DAL.Entities.Departure", "Departure")
                        .WithMany("Tickets")
                        .HasForeignKey("DepartureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainBookingPlatform.DAL.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departure");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.User", b =>
                {
                    b.HasOne("TrainBookingPlatform.DAL.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Wagon", b =>
                {
                    b.HasOne("TrainBookingPlatform.DAL.Entities.Train", "Train")
                        .WithMany("Wagons")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Train");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Departure", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Line", b =>
                {
                    b.Navigation("Departures");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Station", b =>
                {
                    b.Navigation("DepartureRoutes");

                    b.Navigation("DestinationRoutes");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.Train", b =>
                {
                    b.Navigation("Departures");

                    b.Navigation("Wagons");
                });

            modelBuilder.Entity("TrainBookingPlatform.DAL.Entities.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
