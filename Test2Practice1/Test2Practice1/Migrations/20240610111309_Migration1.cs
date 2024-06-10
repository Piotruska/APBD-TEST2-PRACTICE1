using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test2Practice1.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Test2Practice1");

            migrationBuilder.CreateTable(
                name: "BoatStandard",
                schema: "Test2Practice1",
                columns: table => new
                {
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoatStandard", x => x.IdBoatStandard);
                });

            migrationBuilder.CreateTable(
                name: "ClientCategory",
                schema: "Test2Practice1",
                columns: table => new
                {
                    IdClientCategory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DicsountPerc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientCategory", x => x.IdClientCategory);
                });

            migrationBuilder.CreateTable(
                name: "Sailboat",
                schema: "Test2Practice1",
                columns: table => new
                {
                    IdSailboat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sailboat", x => x.IdSailboat);
                    table.ForeignKey(
                        name: "FK_Sailboat_BoatStandard_IdBoatStandard",
                        column: x => x.IdBoatStandard,
                        principalSchema: "Test2Practice1",
                        principalTable: "BoatStandard",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                schema: "Test2Practice1",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Pesel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IdClientCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.IdClient);
                    table.ForeignKey(
                        name: "FK_Client_ClientCategory_IdClientCategory",
                        column: x => x.IdClientCategory,
                        principalSchema: "Test2Practice1",
                        principalTable: "ClientCategory",
                        principalColumn: "IdClientCategory",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                schema: "Test2Practice1",
                columns: table => new
                {
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdClient = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateTo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdBoatStandard = table.Column<int>(type: "int", nullable: false),
                    Capasity = table.Column<int>(type: "int", nullable: false),
                    NumOfBoats = table.Column<int>(type: "int", nullable: false),
                    Fulfilled = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.IdReservation);
                    table.ForeignKey(
                        name: "FK_Reservation_BoatStandard_IdBoatStandard",
                        column: x => x.IdBoatStandard,
                        principalSchema: "Test2Practice1",
                        principalTable: "BoatStandard",
                        principalColumn: "IdBoatStandard",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Client_IdClient",
                        column: x => x.IdClient,
                        principalSchema: "Test2Practice1",
                        principalTable: "Client",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sailboat_Reservation",
                schema: "Test2Practice1",
                columns: table => new
                {
                    IdSailboat = table.Column<int>(type: "int", nullable: false),
                    IdReservation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sailboat_Reservation", x => new { x.IdReservation, x.IdSailboat });
                    table.ForeignKey(
                        name: "FK_Sailboat_Reservation_Reservation_IdReservation",
                        column: x => x.IdReservation,
                        principalSchema: "Test2Practice1",
                        principalTable: "Reservation",
                        principalColumn: "IdReservation",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sailboat_Reservation_Sailboat_IdSailboat",
                        column: x => x.IdSailboat,
                        principalSchema: "Test2Practice1",
                        principalTable: "Sailboat",
                        principalColumn: "IdSailboat",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Client_IdClientCategory",
                schema: "Test2Practice1",
                table: "Client",
                column: "IdClientCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdBoatStandard",
                schema: "Test2Practice1",
                table: "Reservation",
                column: "IdBoatStandard");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_IdClient",
                schema: "Test2Practice1",
                table: "Reservation",
                column: "IdClient");

            migrationBuilder.CreateIndex(
                name: "IX_Sailboat_IdBoatStandard",
                schema: "Test2Practice1",
                table: "Sailboat",
                column: "IdBoatStandard");

            migrationBuilder.CreateIndex(
                name: "IX_Sailboat_Reservation_IdSailboat",
                schema: "Test2Practice1",
                table: "Sailboat_Reservation",
                column: "IdSailboat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sailboat_Reservation",
                schema: "Test2Practice1");

            migrationBuilder.DropTable(
                name: "Reservation",
                schema: "Test2Practice1");

            migrationBuilder.DropTable(
                name: "Sailboat",
                schema: "Test2Practice1");

            migrationBuilder.DropTable(
                name: "Client",
                schema: "Test2Practice1");

            migrationBuilder.DropTable(
                name: "BoatStandard",
                schema: "Test2Practice1");

            migrationBuilder.DropTable(
                name: "ClientCategory",
                schema: "Test2Practice1");
        }
    }
}
