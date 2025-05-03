using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addedALocationStation4Employeement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LocationElectionMunicipalityId",
                table: "Employeements",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationElectionPoliticalPartyId",
                table: "Employeements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationElectionPollingCenterId",
                table: "Employeements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LocationElectionPollingStationId",
                table: "Employeements",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LocationElectionMunicipalityId",
                table: "Employeements",
                column: "LocationElectionMunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LocationElectionPoliticalPartyId",
                table: "Employeements",
                column: "LocationElectionPoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LocationElectionPollingCenterId",
                table: "Employeements",
                column: "LocationElectionPollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LocationElectionPollingStationId",
                table: "Employeements",
                column: "LocationElectionPollingStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeements_Municipalities_LocationElectionMunicipalityId",
                table: "Employeements",
                column: "LocationElectionMunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeements_PoliticalParties_LocationElectionPoliticalPartyId",
                table: "Employeements",
                column: "LocationElectionPoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeements_PollingCenters_LocationElectionPollingCenterId",
                table: "Employeements",
                column: "LocationElectionPollingCenterId",
                principalTable: "PollingCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employeements_PollingStations_LocationElectionPollingStationId",
                table: "Employeements",
                column: "LocationElectionPollingStationId",
                principalTable: "PollingStations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employeements_Municipalities_LocationElectionMunicipalityId",
                table: "Employeements");

            migrationBuilder.DropForeignKey(
                name: "FK_Employeements_PoliticalParties_LocationElectionPoliticalPartyId",
                table: "Employeements");

            migrationBuilder.DropForeignKey(
                name: "FK_Employeements_PollingCenters_LocationElectionPollingCenterId",
                table: "Employeements");

            migrationBuilder.DropForeignKey(
                name: "FK_Employeements_PollingStations_LocationElectionPollingStationId",
                table: "Employeements");

            migrationBuilder.DropIndex(
                name: "IX_Employeements_LocationElectionMunicipalityId",
                table: "Employeements");

            migrationBuilder.DropIndex(
                name: "IX_Employeements_LocationElectionPoliticalPartyId",
                table: "Employeements");

            migrationBuilder.DropIndex(
                name: "IX_Employeements_LocationElectionPollingCenterId",
                table: "Employeements");

            migrationBuilder.DropIndex(
                name: "IX_Employeements_LocationElectionPollingStationId",
                table: "Employeements");

            migrationBuilder.DropColumn(
                name: "LocationElectionMunicipalityId",
                table: "Employeements");

            migrationBuilder.DropColumn(
                name: "LocationElectionPoliticalPartyId",
                table: "Employeements");

            migrationBuilder.DropColumn(
                name: "LocationElectionPollingCenterId",
                table: "Employeements");

            migrationBuilder.DropColumn(
                name: "LocationElectionPollingStationId",
                table: "Employeements");
        }
    }
}
