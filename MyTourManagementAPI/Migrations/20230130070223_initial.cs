using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTourManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminTable",
                columns: table => new
                {
                    adminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminTable", x => x.adminId);
                });

            migrationBuilder.CreateTable(
                name: "TravelAgencyDetails",
                columns: table => new
                {
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgencyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    accomodation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TravelMode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelAgencyDetails", x => x.AgencyId);
                });

            migrationBuilder.CreateTable(
                name: "UserRegisterDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<long>(type: "bigint", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegisterDetails", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "TourPackageDetails",
                columns: table => new
                {
                    TourId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TourName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Itinerary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tourimagepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Departurepoint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AgencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourPackageDetails", x => x.TourId);
                    table.ForeignKey(
                        name: "FK_TourPackageDetails_TravelAgencyDetails_AgencyId",
                        column: x => x.AgencyId,
                        principalTable: "TravelAgencyDetails",
                        principalColumn: "AgencyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfAdults = table.Column<int>(type: "int", nullable: false),
                    NumberChildren = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingDetails_TourPackageDetails_TourId",
                        column: x => x.TourId,
                        principalTable: "TourPackageDetails",
                        principalColumn: "TourId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaymentDetails",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentDetails", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_BookingDetails_Id",
                        column: x => x.Id,
                        principalTable: "BookingDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentDetails_UserRegisterDetails_UserId",
                        column: x => x.UserId,
                        principalTable: "UserRegisterDetails",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_TourId",
                table: "BookingDetails",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_Id",
                table: "PaymentDetails",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentDetails_UserId",
                table: "PaymentDetails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TourPackageDetails_AgencyId",
                table: "TourPackageDetails",
                column: "AgencyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminTable");

            migrationBuilder.DropTable(
                name: "PaymentDetails");

            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "UserRegisterDetails");

            migrationBuilder.DropTable(
                name: "TourPackageDetails");

            migrationBuilder.DropTable(
                name: "TravelAgencyDetails");
        }
    }
}
