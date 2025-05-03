using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addVPNVTypesinVPNV : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "SpecialNeedsVoters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_TypeId",
                table: "SpecialNeedsVoters",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_TypeId",
                table: "SpecialNeedsVoters",
                column: "TypeId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpecialNeedsVoters_Lists_TypeId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropIndex(
                name: "IX_SpecialNeedsVoters_TypeId",
                table: "SpecialNeedsVoters");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "SpecialNeedsVoters");
        }
    }
}
