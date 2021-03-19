using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AllocationManagers",
                columns: table => new
                {
                    AllocationManagerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllocationManagers", x => x.AllocationManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Parking",
                columns: table => new
                {
                    ParkingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlateNumber = table.Column<string>(nullable: true),
                    DriverNamre = table.Column<string>(nullable: true),
                    withCleaningService = table.Column<bool>(nullable: false),
                    checkIn = table.Column<DateTime>(nullable: false),
                    checkOut = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parking", x => x.ParkingId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingHistories",
                columns: table => new
                {
                    ParkingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LicensePlateNumber = table.Column<string>(nullable: true),
                    DriverNamre = table.Column<string>(nullable: true),
                    withCleaningService = table.Column<bool>(nullable: false),
                    checkIn = table.Column<DateTime>(nullable: false),
                    checkOut = table.Column<DateTime>(nullable: false),
                    Cost = table.Column<int>(nullable: false),
                    Interval = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingHistories", x => x.ParkingId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingManagers",
                columns: table => new
                {
                    ParkingManagerId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingManagers", x => x.ParkingManagerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSpaces",
                columns: table => new
                {
                    ParkingSpaceId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TotalSlots = table.Column<int>(nullable: false),
                    ActiveSlots = table.Column<int>(nullable: false),
                    AllocationManagerId = table.Column<int>(nullable: false),
                    ParkingManagerId = table.Column<int>(nullable: false),
                    hasCleaningService = table.Column<bool>(nullable: false),
                    isFull = table.Column<bool>(nullable: false),
                    ParkingRate = table.Column<int>(nullable: false),
                    CleaningRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSpaces", x => x.ParkingSpaceId);
                    table.ForeignKey(
                        name: "FK_ParkingSpaces_AllocationManagers_AllocationManagerId",
                        column: x => x.AllocationManagerId,
                        principalTable: "AllocationManagers",
                        principalColumn: "AllocationManagerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingSpaces_ParkingManagers_ParkingManagerId",
                        column: x => x.ParkingManagerId,
                        principalTable: "ParkingManagers",
                        principalColumn: "ParkingManagerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Slots",
                columns: table => new
                {
                    SlotId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SlotCode = table.Column<string>(nullable: true),
                    FloorId = table.Column<int>(nullable: false),
                    Distance = table.Column<int>(nullable: false),
                    isOccupied = table.Column<bool>(nullable: false),
                    isConfirmed = table.Column<bool>(nullable: false),
                    ParkingSpaceId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slots", x => x.SlotId);
                    table.ForeignKey(
                        name: "FK_Slots_ParkingSpaces_ParkingSpaceId",
                        column: x => x.ParkingSpaceId,
                        principalTable: "ParkingSpaces",
                        principalColumn: "ParkingSpaceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_AllocationManagerId",
                table: "ParkingSpaces",
                column: "AllocationManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSpaces_ParkingManagerId",
                table: "ParkingSpaces",
                column: "ParkingManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Slots_ParkingSpaceId",
                table: "Slots",
                column: "ParkingSpaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parking");

            migrationBuilder.DropTable(
                name: "ParkingHistories");

            migrationBuilder.DropTable(
                name: "Slots");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ParkingSpaces");

            migrationBuilder.DropTable(
                name: "AllocationManagers");

            migrationBuilder.DropTable(
                name: "ParkingManagers");
        }
    }
}
