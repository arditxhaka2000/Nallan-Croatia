using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class add_CountryId_AbroadVoterTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "AbroadVoters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_CountryId",
                table: "AbroadVoters",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoters_Countries_CountryId",
                table: "AbroadVoters",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoters_Countries_CountryId",
                table: "AbroadVoters");

            migrationBuilder.DropIndex(
                name: "IX_AbroadVoters_CountryId",
                table: "AbroadVoters");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "AbroadVoters");
        }
    }
}
