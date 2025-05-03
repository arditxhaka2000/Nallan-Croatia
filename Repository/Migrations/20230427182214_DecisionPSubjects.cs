using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DecisionPSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DecisionId",
                table: "PoliticalParties",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_DecisionId",
                table: "PoliticalParties",
                column: "DecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_Lists_DecisionId",
                table: "PoliticalParties",
                column: "DecisionId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_Lists_DecisionId",
                table: "PoliticalParties");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalParties_DecisionId",
                table: "PoliticalParties");

            migrationBuilder.DropColumn(
                name: "DecisionId",
                table: "PoliticalParties");
        }
    }
}
