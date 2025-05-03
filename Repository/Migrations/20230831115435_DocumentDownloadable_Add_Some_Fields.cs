using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DocumentDownloadable_Add_Some_Fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InformationText",
                table: "DocumentDownloadables",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRequired",
                table: "DocumentDownloadables",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "OrderIndex",
                table: "DocumentDownloadables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "DocumentDownloadables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "DocumentDownloadables",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InformationText",
                table: "DocumentDownloadables");

            migrationBuilder.DropColumn(
                name: "IsRequired",
                table: "DocumentDownloadables");

            migrationBuilder.DropColumn(
                name: "OrderIndex",
                table: "DocumentDownloadables");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "DocumentDownloadables");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "DocumentDownloadables");
        }
    }
}
