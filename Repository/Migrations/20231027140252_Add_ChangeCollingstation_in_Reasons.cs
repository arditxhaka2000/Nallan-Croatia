using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Add_ChangeCollingstation_in_Reasons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PollingCenterChangeId",
                table: "AbroadVoterRefuseReasons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_PollingCenterChangeId",
                table: "AbroadVoterRefuseReasons",
                column: "PollingCenterChangeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoterRefuseReasons_PollingCenterChanges_PollingCenterChangeId",
                table: "AbroadVoterRefuseReasons",
                column: "PollingCenterChangeId",
                principalTable: "PollingCenterChanges",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoterRefuseReasons_PollingCenterChanges_PollingCenterChangeId",
                table: "AbroadVoterRefuseReasons");

            migrationBuilder.DropIndex(
                name: "IX_AbroadVoterRefuseReasons_PollingCenterChangeId",
                table: "AbroadVoterRefuseReasons");

            migrationBuilder.DropColumn(
                name: "PollingCenterChangeId",
                table: "AbroadVoterRefuseReasons");
        }
    }
}
