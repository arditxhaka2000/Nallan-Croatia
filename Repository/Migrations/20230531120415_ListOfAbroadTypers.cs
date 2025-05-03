using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ListOfAbroadTypers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AbroadVoterTypeId",
                table: "AbroadVoters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_AbroadVoterTypeId",
                table: "AbroadVoters",
                column: "AbroadVoterTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoters_Lists_AbroadVoterTypeId",
                table: "AbroadVoters",
                column: "AbroadVoterTypeId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoters_Lists_AbroadVoterTypeId",
                table: "AbroadVoters");

            migrationBuilder.DropIndex(
                name: "IX_AbroadVoters_AbroadVoterTypeId",
                table: "AbroadVoters");

            migrationBuilder.DropColumn(
                name: "AbroadVoterTypeId",
                table: "AbroadVoters");
        }
    }
}
