using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class pollingcenterChangessss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PollingCenterChanges_Elections_ElectionId",
                table: "PollingCenterChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_PollingCenterChanges_Lists_GenderId",
                table: "PollingCenterChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_PollingCenterChanges_PollingCenters_CurrentPollingCenterId",
                table: "PollingCenterChanges");

            migrationBuilder.DropForeignKey(
                name: "FK_PollingCenterChanges_PollingCenters_RequestedPollingCenterId",
                table: "PollingCenterChanges");

            migrationBuilder.DropIndex(
                name: "IX_PollingCenterChanges_CurrentPollingCenterId",
                table: "PollingCenterChanges");

            migrationBuilder.DropIndex(
                name: "IX_PollingCenterChanges_ElectionId",
                table: "PollingCenterChanges");

            migrationBuilder.DropIndex(
                name: "IX_PollingCenterChanges_GenderId",
                table: "PollingCenterChanges");

            migrationBuilder.DropIndex(
                name: "IX_PollingCenterChanges_RequestedPollingCenterId",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "PollingCenterChanges");

            migrationBuilder.AlterColumn<string>(
                name: "RequestedPollingCenterId",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CurrentPollingCenterId",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentPollingCenterCode",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrentPollingCenterName",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GenderName",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestedPollingCenterCode",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RequestedPollingCenterName",
                table: "PollingCenterChanges",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPollingCenterCode",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "CurrentPollingCenterName",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "GenderName",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "RequestedPollingCenterCode",
                table: "PollingCenterChanges");

            migrationBuilder.DropColumn(
                name: "RequestedPollingCenterName",
                table: "PollingCenterChanges");

            migrationBuilder.AlterColumn<Guid>(
                name: "RequestedPollingCenterId",
                table: "PollingCenterChanges",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentPollingCenterId",
                table: "PollingCenterChanges",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                table: "PollingCenterChanges",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_CurrentPollingCenterId",
                table: "PollingCenterChanges",
                column: "CurrentPollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_ElectionId",
                table: "PollingCenterChanges",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_GenderId",
                table: "PollingCenterChanges",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_RequestedPollingCenterId",
                table: "PollingCenterChanges",
                column: "RequestedPollingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_PollingCenterChanges_Elections_ElectionId",
                table: "PollingCenterChanges",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollingCenterChanges_Lists_GenderId",
                table: "PollingCenterChanges",
                column: "GenderId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollingCenterChanges_PollingCenters_CurrentPollingCenterId",
                table: "PollingCenterChanges",
                column: "CurrentPollingCenterId",
                principalTable: "PollingCenters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PollingCenterChanges_PollingCenters_RequestedPollingCenterId",
                table: "PollingCenterChanges",
                column: "RequestedPollingCenterId",
                principalTable: "PollingCenters",
                principalColumn: "Id");
        }
    }
}
