using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class add_newlisttypechildid_new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListTypeChildId",
                table: "Lists",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ListTypeId1",
                table: "Lists",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Lists_ListTypeChildId",
                table: "Lists",
                column: "ListTypeChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_ListTypeId1",
                table: "Lists",
                column: "ListTypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_ListTypes_ListTypeChildId",
                table: "Lists",
                column: "ListTypeChildId",
                principalTable: "ListTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lists_ListTypes_ListTypeId1",
                table: "Lists",
                column: "ListTypeId1",
                principalTable: "ListTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lists_ListTypes_ListTypeChildId",
                table: "Lists");

            migrationBuilder.DropForeignKey(
                name: "FK_Lists_ListTypes_ListTypeId1",
                table: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Lists_ListTypeChildId",
                table: "Lists");

            migrationBuilder.DropIndex(
                name: "IX_Lists_ListTypeId1",
                table: "Lists");

            migrationBuilder.DropColumn(
                name: "ListTypeChildId",
                table: "Lists");

            migrationBuilder.DropColumn(
                name: "ListTypeId1",
                table: "Lists");
        }
    }
}
