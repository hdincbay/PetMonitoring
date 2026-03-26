using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.Movement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActiveMinutes",
                table: "MovementRecords");

            migrationBuilder.DropColumn(
                name: "DistanceInMeters",
                table: "MovementRecords");

            migrationBuilder.DropColumn(
                name: "InactiveMinutes",
                table: "MovementRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveMinutes",
                table: "MovementRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "DistanceInMeters",
                table: "MovementRecords",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "InactiveMinutes",
                table: "MovementRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
