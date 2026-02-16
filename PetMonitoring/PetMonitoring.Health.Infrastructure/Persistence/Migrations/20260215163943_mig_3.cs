using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace __PetMonitoring.Health.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceId",
                table: "HeartRateRecords");

            migrationBuilder.AddColumn<string>(
                name: "DeviceSerialNumber",
                table: "HeartRateRecords",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceSerialNumber",
                table: "HeartRateRecords");

            migrationBuilder.AddColumn<Guid>(
                name: "DeviceId",
                table: "HeartRateRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
