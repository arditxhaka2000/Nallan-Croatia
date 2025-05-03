using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addRelationshipObserversApplicationIdInDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ObserversApplicationId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ObserversApplicationId",
                table: "Documents",
                column: "ObserversApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ObserversApplications_ObserversApplicationId",
                table: "Documents",
                column: "ObserversApplicationId",
                principalTable: "ObserversApplications",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ObserversApplications_ObserversApplicationId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ObserversApplicationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ObserversApplicationId",
                table: "Documents");
        }
    }
}
