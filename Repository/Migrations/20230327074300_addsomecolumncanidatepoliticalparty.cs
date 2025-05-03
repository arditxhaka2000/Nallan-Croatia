using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addsomecolumncanidatepoliticalparty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "CandidatePoliticParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DecisionId",
                table: "CandidatePoliticParties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PullNoteDate",
                table: "CandidatePoliticParties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PullNoteFirstName",
                table: "CandidatePoliticParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PullNoteLastName",
                table: "CandidatePoliticParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PullNotePlace",
                table: "CandidatePoliticParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_DecisionId",
                table: "CandidatePoliticParties",
                column: "DecisionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_Lists_DecisionId",
                table: "CandidatePoliticParties",
                column: "DecisionId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_Lists_DecisionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropIndex(
                name: "IX_CandidatePoliticParties_DecisionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "Comment",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "DecisionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "PullNoteDate",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "PullNoteFirstName",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "PullNoteLastName",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "PullNotePlace",
                table: "CandidatePoliticParties");
        }
    }
}
