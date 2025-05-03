using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addCitizenInitiativeIdRelationshipInPoliticalParty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CitizenInitiativeId",
                table: "PoliticalParties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_CitizenInitiativeId",
                table: "PoliticalParties",
                column: "CitizenInitiativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_Lists_CitizenInitiativeId",
                table: "PoliticalParties",
                column: "CitizenInitiativeId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_Lists_CitizenInitiativeId",
                table: "PoliticalParties");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalParties_CitizenInitiativeId",
                table: "PoliticalParties");

            migrationBuilder.DropColumn(
                name: "CitizenInitiativeId",
                table: "PoliticalParties");
        }
    }
}
