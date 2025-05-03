using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class changeForentkeyDRMEmployees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.RenameColumn(
                name: "DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "DataResultsMatchingFormId");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingFormId",
                principalTable: "DataResultsMatchingForms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.RenameColumn(
                name: "DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "DataResultsMatchingFormId1");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId1");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingFormId1",
                principalTable: "DataResultsMatchingForms",
                principalColumn: "Id");
        }
    }
}
