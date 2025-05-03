using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class persontypeofsignaturepersons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SignaturePersonTypeId",
                table: "PoliticalPartyPersonSignatures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersonSignatures_SignaturePersonTypeId",
                table: "PoliticalPartyPersonSignatures",
                column: "SignaturePersonTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersonSignatures_Lists_SignaturePersonTypeId",
                table: "PoliticalPartyPersonSignatures",
                column: "SignaturePersonTypeId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersonSignatures_Lists_SignaturePersonTypeId",
                table: "PoliticalPartyPersonSignatures");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalPartyPersonSignatures_SignaturePersonTypeId",
                table: "PoliticalPartyPersonSignatures");

            migrationBuilder.DropColumn(
                name: "SignaturePersonTypeId",
                table: "PoliticalPartyPersonSignatures");
        }
    }
}
