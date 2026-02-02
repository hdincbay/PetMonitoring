using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace __PetMonitoring.Health.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MeasuredAt",
                table: "HeartRateRecords",
                newName: "CreatedDate");

            migrationBuilder.RenameIndex(
                name: "IX_HeartRateRecords_PetId_MeasuredAt",
                table: "HeartRateRecords",
                newName: "IX_HeartRateRecords_PetId_CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "HeartRateRecords",
                newName: "MeasuredAt");

            migrationBuilder.RenameIndex(
                name: "IX_HeartRateRecords_PetId_CreatedDate",
                table: "HeartRateRecords",
                newName: "IX_HeartRateRecords_PetId_MeasuredAt");
        }
    }
}
