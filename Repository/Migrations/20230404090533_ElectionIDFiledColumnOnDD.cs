using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ElectionIDFiledColumnOnDD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                table: "DocumentDownloadables",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadables_ElectionId",
                table: "DocumentDownloadables",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadables_Elections_ElectionId",
                table: "DocumentDownloadables",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadables_Elections_ElectionId",
                table: "DocumentDownloadables");

            migrationBuilder.DropIndex(
                name: "IX_DocumentDownloadables_ElectionId",
                table: "DocumentDownloadables");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "DocumentDownloadables");
        }
    }
}
