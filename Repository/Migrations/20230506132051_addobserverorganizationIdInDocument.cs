using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addobserverorganizationIdInDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ObserverOrganizationId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ObserverOrganizationId",
                table: "Documents",
                column: "ObserverOrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ObserverOrganizations_ObserverOrganizationId",
                table: "Documents",
                column: "ObserverOrganizationId",
                principalTable: "ObserverOrganizations",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ObserverOrganizations_ObserverOrganizationId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ObserverOrganizationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ObserverOrganizationId",
                table: "Documents");
        }
    }
}
