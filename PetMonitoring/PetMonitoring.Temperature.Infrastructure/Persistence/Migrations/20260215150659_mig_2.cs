using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.Temperature.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TemperatureRecords_PetId_CreatedDate",
                table: "TemperatureRecords");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "TemperatureRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "TemperatureRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureRecords_PetId_CreatedDate",
                table: "TemperatureRecords",
                columns: new[] { "PetId", "CreatedDate" });
        }
    }
}
