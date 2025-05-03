using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ElectionPerInciativaEdheKandidat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                table: "PoliticalParties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_ElectionId",
                table: "PoliticalParties",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_Lists_ElectionId",
                table: "PoliticalParties",
                column: "ElectionId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_Lists_ElectionId",
                table: "PoliticalParties");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalParties_ElectionId",
                table: "PoliticalParties");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "PoliticalParties");
        }
    }
}
