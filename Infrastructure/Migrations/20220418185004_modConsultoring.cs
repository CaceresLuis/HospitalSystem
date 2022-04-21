using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class modConsultoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuoteByhour",
                table: "Reservations");

            migrationBuilder.AddColumn<string>(
                name: "ConsultingRoom",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConsultoringRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultoringRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoctorConsultoringRooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuoteTotal = table.Column<int>(type: "int", nullable: false),
                    Schedule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    DoctorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ConsultoringRoomId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorConsultoringRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoctorConsultoringRooms_ConsultoringRooms_ConsultoringRoomId",
                        column: x => x.ConsultoringRoomId,
                        principalTable: "ConsultoringRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DoctorConsultoringRooms_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DoctorConsultoringRooms_ConsultoringRoomId",
                table: "DoctorConsultoringRooms",
                column: "ConsultoringRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_DoctorConsultoringRooms_DoctorId",
                table: "DoctorConsultoringRooms",
                column: "DoctorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DoctorConsultoringRooms");

            migrationBuilder.DropTable(
                name: "ConsultoringRooms");

            migrationBuilder.DropColumn(
                name: "ConsultingRoom",
                table: "Reservations");

            migrationBuilder.AddColumn<int>(
                name: "QuoteByhour",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
