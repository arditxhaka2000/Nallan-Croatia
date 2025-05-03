using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ZVKCodeNoRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConditionalVoters_ConditionalBallotEnvelopes_ConditionalBallotEnvelopeId",
                table: "ConditionalVoters");

            migrationBuilder.DropIndex(
                name: "IX_ConditionalVoters_ConditionalBallotEnvelopeId",
                table: "ConditionalVoters");

            migrationBuilder.DropColumn(
                name: "ConditionalBallotEnvelopeId",
                table: "ConditionalVoters");

            migrationBuilder.AddColumn<string>(
                name: "CBECode",
                table: "ConditionalVoters",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CBECode",
                table: "ConditionalVoters");

            migrationBuilder.AddColumn<Guid>(
                name: "ConditionalBallotEnvelopeId",
                table: "ConditionalVoters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ConditionalVoters_ConditionalBallotEnvelopeId",
                table: "ConditionalVoters",
                column: "ConditionalBallotEnvelopeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConditionalVoters_ConditionalBallotEnvelopes_ConditionalBallotEnvelopeId",
                table: "ConditionalVoters",
                column: "ConditionalBallotEnvelopeId",
                principalTable: "ConditionalBallotEnvelopes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
