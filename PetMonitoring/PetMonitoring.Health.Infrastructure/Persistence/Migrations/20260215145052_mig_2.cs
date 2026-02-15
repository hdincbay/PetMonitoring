using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace __PetMonitoring.Health.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HeartRateRecords_PetId_CreatedDate",
                table: "HeartRateRecords");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "HeartRateRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "HeartRateRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_HeartRateRecords_PetId_CreatedDate",
                table: "HeartRateRecords",
                columns: new[] { "PetId", "CreatedDate" });
        }
    }
}
