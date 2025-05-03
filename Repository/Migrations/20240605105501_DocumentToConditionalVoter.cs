using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class DocumentToConditionalVoter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ConditionalVoterId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ConditionalVoterId",
                table: "Documents",
                column: "ConditionalVoterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ConditionalVoters_ConditionalVoterId",
                table: "Documents",
                column: "ConditionalVoterId",
                principalTable: "ConditionalVoters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ConditionalVoters_ConditionalVoterId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ConditionalVoterId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ConditionalVoterId",
                table: "Documents");
        }
    }
}
