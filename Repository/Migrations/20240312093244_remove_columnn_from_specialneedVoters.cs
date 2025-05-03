using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class remove_columnn_from_specialneedVoters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_SubInstitucionId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropIndex(
                name: "IX_SpecialNeedsVoters_SubInstitucionId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropColumn(
                name: "SubInstitucionId",
                table: "SpecialNeedsVoters");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubInstitucionId",
                table: "SpecialNeedsVoters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_SubInstitucionId",
                table: "SpecialNeedsVoters",
                column: "SubInstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_SubInstitucionId",
                table: "SpecialNeedsVoters",
                column: "SubInstitucionId",
                principalTable: "Lists",
                principalColumn: "Id");
        }
    }
}
