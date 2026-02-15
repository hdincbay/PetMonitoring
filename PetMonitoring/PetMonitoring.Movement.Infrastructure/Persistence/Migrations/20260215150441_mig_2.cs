using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetMonitoring.Movement.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MovementRecords_PetId_CreatedDate",
                table: "MovementRecords");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "MovementRecords");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "MovementRecords",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MovementRecords_PetId_CreatedDate",
                table: "MovementRecords",
                columns: new[] { "PetId", "CreatedDate" });
        }
    }
}
