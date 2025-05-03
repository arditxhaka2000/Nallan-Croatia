using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class municipality2Users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MunicipalityId",
                table: "AspNetUsers",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Municipalities_MunicipalityId",
                table: "AspNetUsers",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Municipalities_MunicipalityId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MunicipalityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "AspNetUsers");
        }
    }
}
