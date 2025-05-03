using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class changeFKDRMCOOE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultMatchings_DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultMatchings_DataResultsMatchingId",
                table: "DataResultsMatchingCandidatePPEmployees");

            migrationBuilder.DropIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.DropColumn(
                name: "DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.RenameColumn(
                name: "DataResultsMatchingId",
                table: "DataResultsMatchingCandidatePPEmployees",
                newName: "DataResultsMatchingFormId");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingId",
                table: "DataResultsMatchingCandidatePPEmployees",
                newName: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingForms_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DataResultsMatchingFormId",
                principalTable: "DataResultsMatchingForms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingForms_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidatePPEmployees");

            migrationBuilder.RenameColumn(
                name: "DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidatePPEmployees",
                newName: "DataResultsMatchingId");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidatePPEmployees",
                newName: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingId");

            migrationBuilder.AddColumn<Guid>(
                name: "DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultMatchings_DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingId",
                principalTable: "DataResultMatchings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultMatchings_DataResultsMatchingId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DataResultsMatchingId",
                principalTable: "DataResultMatchings",
                principalColumn: "Id");
        }
    }
}
