using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addObserverOrganizationPersonIdInDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ObserverOrganizationPersonId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ObserverOrganizationPersonId",
                table: "Documents",
                column: "ObserverOrganizationPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ObserverOrganizationPersons_ObserverOrganizationPersonId",
                table: "Documents",
                column: "ObserverOrganizationPersonId",
                principalTable: "ObserverOrganizationPersons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ObserverOrganizationPersons_ObserverOrganizationPersonId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ObserverOrganizationPersonId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ObserverOrganizationPersonId",
                table: "Documents");
        }
    }
}
