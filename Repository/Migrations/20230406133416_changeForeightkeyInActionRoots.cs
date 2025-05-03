using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class changeForeightkeyInActionRoots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActionRootRestRights_IdentityRole_IdentityRoleId",
                table: "UserActionRootRestRights");

            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserActionRootRestRights_AspNetRoles_IdentityRoleId",
                table: "UserActionRootRestRights",
                column: "IdentityRoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserActionRootRestRights_AspNetRoles_IdentityRoleId",
                table: "UserActionRootRestRights");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserActionRootRestRights_IdentityRole_IdentityRoleId",
                table: "UserActionRootRestRights",
                column: "IdentityRoleId",
                principalTable: "IdentityRole",
                principalColumn: "Id");
        }
    }
}
