using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class pollingcenterChangessss2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Apartment",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "MAEComment",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "PollingCenterChanges");

            migrationBuilder.RenameColumn(
                name: "StreetNr",
                table: "PollingCenterChanges",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "PollingCenterChanges",
                newName: "StreetNr");

            migrationBuilder.AddColumn<string>(
                name: "Apartment",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MAEComment",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
