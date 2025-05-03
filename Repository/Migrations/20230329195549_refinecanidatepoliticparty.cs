using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class refinecanidatepoliticparty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_CandidatePoliticalPartyCoalitions_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropIndex(
                name: "IX_CandidatePoliticParties_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties",
                column: "CandidatePoliticalPartyCoalitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_CandidatePoliticalPartyCoalitions_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties",
                column: "CandidatePoliticalPartyCoalitionId",
                principalTable: "CandidatePoliticalPartyCoalitions",
                principalColumn: "Id");
        }
    }
}
