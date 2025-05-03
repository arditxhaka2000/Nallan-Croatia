using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class PPPMunicipalityADDED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "PoliticalPartyPersons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_MunicipalityId",
                table: "PoliticalPartyPersons",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersons_Municipalities_MunicipalityId",
                table: "PoliticalPartyPersons",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersons_Municipalities_MunicipalityId",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalPartyPersons_MunicipalityId",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "PoliticalPartyPersons");
        }
    }
}
