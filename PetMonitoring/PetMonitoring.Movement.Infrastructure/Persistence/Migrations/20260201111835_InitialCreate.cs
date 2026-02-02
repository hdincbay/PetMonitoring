using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.Movement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeartRateRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StepCount = table.Column<int>(type: "int", nullable: false),
                    DistanceInMeters = table.Column<double>(type: "float", nullable: false),
                    ActivityLevel = table.Column<int>(type: "int", nullable: false),
                    ActiveMinutes = table.Column<int>(type: "int", nullable: false),
                    InactiveMinutes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeartRateRecords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeartRateRecords_PetId_CreatedDate",
                table: "HeartRateRecords",
                columns: new[] { "PetId", "CreatedDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeartRateRecords");
        }
    }
}
