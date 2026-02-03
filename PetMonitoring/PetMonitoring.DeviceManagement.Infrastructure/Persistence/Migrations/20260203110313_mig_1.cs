using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.DeviceManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BatteryPercentage",
                table: "DeviceRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryPercentage",
                table: "DeviceRecords");
        }
    }
}
