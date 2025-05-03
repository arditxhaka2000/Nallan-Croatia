using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class added_some_column_specialneedVoters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "SpecialNeedsVoters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstitucionId",
                table: "SpecialNeedsVoters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SubInstitucionId",
                table: "SpecialNeedsVoters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_CategoryId",
                table: "SpecialNeedsVoters",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_InstitucionId",
                table: "SpecialNeedsVoters",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_SubInstitucionId",
                table: "SpecialNeedsVoters",
                column: "SubInstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_CategoryId",
                table: "SpecialNeedsVoters",
                column: "CategoryId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_InstitucionId",
                table: "SpecialNeedsVoters",
                column: "InstitucionId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_SubInstitucionId",
                table: "SpecialNeedsVoters",
                column: "SubInstitucionId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_CategoryId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_InstitucionId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_SubInstitucionId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropIndex(
                name: "IX_SpecialNeedsVoters_CategoryId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropIndex(
                name: "IX_SpecialNeedsVoters_InstitucionId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropIndex(
                name: "IX_SpecialNeedsVoters_SubInstitucionId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropColumn(
                name: "InstitucionId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropColumn(
                name: "SubInstitucionId",
                table: "SpecialNeedsVoters");
        }
    }
}
