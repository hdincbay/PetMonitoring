using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.DeviceManagement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceRecords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeviceRecords_PetId_CreatedDate",
                table: "DeviceRecords",
                columns: new[] { "PetId", "CreatedDate" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeviceRecords");
        }
    }
}
