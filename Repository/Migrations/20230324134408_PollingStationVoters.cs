using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class PollingStationVoters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PollingStationId",
                table: "Voters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Voters_PollingStationId",
                table: "Voters",
                column: "PollingStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_PollingStations_PollingStationId",
                table: "Voters",
                column: "PollingStationId",
                principalTable: "PollingStations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voters_PollingStations_PollingStationId",
                table: "Voters");

            migrationBuilder.DropIndex(
                name: "IX_Voters_PollingStationId",
                table: "Voters");

            migrationBuilder.DropColumn(
                name: "PollingStationId",
                table: "Voters");
        }
    }
}
