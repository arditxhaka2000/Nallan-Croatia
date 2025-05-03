using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addednewcolumnelectionid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                table: "CandidatePoliticalPartyCoalitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_ElectionId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_Elections_ElectionId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_Elections_ElectionId",
                table: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_ElectionId",
                table: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "CandidatePoliticalPartyCoalitions");
        }
    }
}
