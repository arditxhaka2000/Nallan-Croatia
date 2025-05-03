using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedWriteDateValidation4UserActionRootRestRight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateFromWriteValidation",
                table: "UserActionRootRestRights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateToWriteValidation",
                table: "UserActionRootRestRights",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasWriteDateValidation",
                table: "UserActionRootRestRights",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateFromWriteValidation",
                table: "UserActionRootRestRights");

            migrationBuilder.DropColumn(
                name: "DateToWriteValidation",
                table: "UserActionRootRestRights");

            migrationBuilder.DropColumn(
                name: "HasWriteDateValidation",
                table: "UserActionRootRestRights");
        }
    }
}
