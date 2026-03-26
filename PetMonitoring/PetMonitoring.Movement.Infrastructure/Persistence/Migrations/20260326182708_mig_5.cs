using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.Movement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StepCount",
                table: "MovementRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StepCount",
                table: "MovementRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
