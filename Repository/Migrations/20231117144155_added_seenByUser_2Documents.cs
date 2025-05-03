using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class added_seenByUser_2Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSeen",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SeenByUserId",
                table: "Documents",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_SeenByUserId",
                table: "Documents",
                column: "SeenByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AspNetUsers_SeenByUserId",
                table: "Documents",
                column: "SeenByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AspNetUsers_SeenByUserId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_SeenByUserId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "IsSeen",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SeenByUserId",
                table: "Documents");
        }
    }
}
