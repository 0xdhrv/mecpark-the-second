﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

namespace WebApi.Migrations
{
    [DbContext(typeof(SqliteDataContext))]
    [Migration("20210319084444_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("WebApi.Entities.AllocationManager", b =>
                {
                    b.Property<int>("AllocationManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("AllocationManagerId");

                    b.ToTable("AllocationManagers");
                });

            modelBuilder.Entity("WebApi.Entities.Parking", b =>
                {
                    b.Property<int>("ParkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DriverNamre")
                        .HasColumnType("TEXT");

                    b.Property<string>("LicensePlateNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("checkIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("checkOut")
                        .HasColumnType("TEXT");

                    b.Property<bool>("withCleaningService")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParkingId");

                    b.ToTable("Parking");
                });

            modelBuilder.Entity("WebApi.Entities.ParkingHistory", b =>
                {
                    b.Property<int>("ParkingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cost")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DriverNamre")
                        .HasColumnType("TEXT");

                    b.Property<TimeSpan>("Interval")
                        .HasColumnType("TEXT");

                    b.Property<string>("LicensePlateNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("checkIn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("checkOut")
                        .HasColumnType("TEXT");

                    b.Property<bool>("withCleaningService")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParkingId");

                    b.ToTable("ParkingHistories");
                });

            modelBuilder.Entity("WebApi.Entities.ParkingManager", b =>
                {
                    b.Property<int>("ParkingManagerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.HasKey("ParkingManagerId");

                    b.ToTable("ParkingManagers");
                });

            modelBuilder.Entity("WebApi.Entities.ParkingSpace", b =>
                {
                    b.Property<int>("ParkingSpaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ActiveSlots")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllocationManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CleaningRate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParkingManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParkingRate")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TotalSlots")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("hasCleaningService")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isFull")
                        .HasColumnType("INTEGER");

                    b.HasKey("ParkingSpaceId");

                    b.HasIndex("AllocationManagerId");

                    b.HasIndex("ParkingManagerId");

                    b.ToTable("ParkingSpaces");
                });

            modelBuilder.Entity("WebApi.Entities.Slot", b =>
                {
                    b.Property<int>("SlotId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Distance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FloorId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ParkingSpaceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SlotCode")
                        .HasColumnType("TEXT");

                    b.Property<bool>("isConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isOccupied")
                        .HasColumnType("INTEGER");

                    b.HasKey("SlotId");

                    b.HasIndex("ParkingSpaceId");

                    b.ToTable("Slots");
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("BLOB");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApi.Entities.ParkingSpace", b =>
                {
                    b.HasOne("WebApi.Entities.AllocationManager", "AllocationManager")
                        .WithMany()
                        .HasForeignKey("AllocationManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApi.Entities.ParkingManager", "ParkingManager")
                        .WithMany()
                        .HasForeignKey("ParkingManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApi.Entities.Slot", b =>
                {
                    b.HasOne("WebApi.Entities.ParkingSpace", "ParkingSpace")
                        .WithMany("Slots")
                        .HasForeignKey("ParkingSpaceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
