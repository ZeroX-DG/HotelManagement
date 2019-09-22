using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelManagement.Data.Migrations
{
    public partial class InitialTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Detail = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HouseKeepers",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Grade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseKeepers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ParkingLot",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    BlockNum = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingLot", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    ImageName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MaxGuests = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    NumChildren = table.Column<int>(nullable: false),
                    NumAdults = table.Column<int>(nullable: false),
                    AgencyID = table.Column<string>(nullable: true),
                    CompanyID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Guests_Agencies_AgencyID",
                        column: x => x.AgencyID,
                        principalTable: "Agencies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Guests_Companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Companies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    ReferenceNum = table.Column<string>(nullable: false),
                    GuestID = table.Column<string>(nullable: true),
                    ParkingLotID = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    NumGuest = table.Column<int>(nullable: false),
                    TotalFee = table.Column<double>(nullable: false),
                    Paid = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.ReferenceNum);
                    table.ForeignKey(
                        name: "FK_Bookings_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_ParkingLot_ParkingLotID",
                        column: x => x.ParkingLotID,
                        principalTable: "ParkingLot",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    RoomTypeID = table.Column<string>(nullable: true),
                    BookingReferenceNum = table.Column<string>(nullable: true),
                    Floor = table.Column<string>(nullable: false),
                    RoomNum = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Bookings_BookingReferenceNum",
                        column: x => x.BookingReferenceNum,
                        principalTable: "Bookings",
                        principalColumn: "ReferenceNum",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Rooms_RoomTypes_RoomTypeID",
                        column: x => x.RoomTypeID,
                        principalTable: "RoomTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    GuestID = table.Column<string>(nullable: true),
                    RoomID = table.Column<string>(nullable: true),
                    CardHolder = table.Column<string>(nullable: false),
                    CardNum = table.Column<string>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    Amount = table.Column<double>(nullable: false),
                    PaymentTerm = table.Column<string>(nullable: false),
                    PaymentDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Payments_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    RoomID = table.Column<string>(nullable: true),
                    HouseKeeperID = table.Column<string>(nullable: true),
                    QualityChecked = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Schedules_HouseKeepers_HouseKeeperID",
                        column: x => x.HouseKeeperID,
                        principalTable: "HouseKeepers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Schedules_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckSheets",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ScheduleID = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Notes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckSheets", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CheckSheets_Schedules_ScheduleID",
                        column: x => x.ScheduleID,
                        principalTable: "Schedules",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_GuestID",
                table: "Bookings",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ParkingLotID",
                table: "Bookings",
                column: "ParkingLotID");

            migrationBuilder.CreateIndex(
                name: "IX_CheckSheets_ScheduleID",
                table: "CheckSheets",
                column: "ScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_AgencyID",
                table: "Guests",
                column: "AgencyID");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_CompanyID",
                table: "Guests",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_GuestID",
                table: "Payments",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RoomID",
                table: "Payments",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BookingReferenceNum",
                table: "Rooms",
                column: "BookingReferenceNum");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_RoomTypeID",
                table: "Rooms",
                column: "RoomTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_HouseKeeperID",
                table: "Schedules",
                column: "HouseKeeperID");

            migrationBuilder.CreateIndex(
                name: "IX_Schedules_RoomID",
                table: "Schedules",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckSheets");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Schedules");

            migrationBuilder.DropTable(
                name: "HouseKeepers");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "RoomTypes");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "ParkingLot");

            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
