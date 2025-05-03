using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class fixColum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVoterId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "AbroadVoterId",
                table: "Documents",
                newName: "AbroadVotersId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_AbroadVoterId",
                table: "Documents",
                newName: "IX_Documents_AbroadVotersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVotersId",
                table: "Documents",
                column: "AbroadVotersId",
                principalTable: "AbroadVoters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVotersId",
                table: "Documents");

            migrationBuilder.RenameColumn(
                name: "AbroadVotersId",
                table: "Documents",
                newName: "AbroadVoterId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_AbroadVotersId",
                table: "Documents",
                newName: "IX_Documents_AbroadVoterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVoterId",
                table: "Documents",
                column: "AbroadVoterId",
                principalTable: "AbroadVoters",
                principalColumn: "Id");
        }
    }
}
