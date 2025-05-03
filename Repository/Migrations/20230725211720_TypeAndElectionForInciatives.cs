using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class TypeAndElectionForInciatives : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_Lists_CitizenInitiativeId",
                table: "PoliticalParties");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_Lists_ElectionId",
                table: "PoliticalParties");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalParties_CitizenInitiativeId",
                table: "PoliticalParties");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalParties_ElectionId",
                table: "PoliticalParties");

            migrationBuilder.RenameColumn(
                name: "CitizenInitiativeId",
                table: "PoliticalParties",
                newName: "PoliticalPartyTypeId");

            migrationBuilder.AddColumn<string>(
                name: "ElectionName",
                table: "PoliticalParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoliticalPartyTypeName",
                table: "PoliticalParties",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElectionName",
                table: "PoliticalParties");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyTypeName",
                table: "PoliticalParties");

            migrationBuilder.RenameColumn(
                name: "PoliticalPartyTypeId",
                table: "PoliticalParties",
                newName: "CitizenInitiativeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_CitizenInitiativeId",
                table: "PoliticalParties",
                column: "CitizenInitiativeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_ElectionId",
                table: "PoliticalParties",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_Lists_CitizenInitiativeId",
                table: "PoliticalParties",
                column: "CitizenInitiativeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_Lists_ElectionId",
                table: "PoliticalParties",
                column: "ElectionId",
                principalTable: "Lists",
                principalColumn: "Id");
        }
    }
}
