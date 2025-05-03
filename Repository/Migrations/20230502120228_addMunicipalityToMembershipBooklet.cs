using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addMunicipalityToMembershipBooklet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "PoliticalPartySignatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartySignatures_MunicipalityId",
                table: "PoliticalPartySignatures",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartySignatures_Municipalities_MunicipalityId",
                table: "PoliticalPartySignatures",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartySignatures_Municipalities_MunicipalityId",
                table: "PoliticalPartySignatures");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalPartySignatures_MunicipalityId",
                table: "PoliticalPartySignatures");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "PoliticalPartySignatures");
        }
    }
}
