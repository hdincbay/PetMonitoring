using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.Temperature.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "TemperatureRecords");

            migrationBuilder.AddColumn<string>(
                name: "DeviceSerialNumber",
                table: "TemperatureRecords",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceSerialNumber",
                table: "TemperatureRecords");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "TemperatureRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
