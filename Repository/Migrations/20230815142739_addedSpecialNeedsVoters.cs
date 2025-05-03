using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addedSpecialNeedsVoters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoterRefuseReasons_AbroadVoters_AbroadVoterId",
                table: "AbroadVoterRefuseReasons");

            migrationBuilder.AlterColumn<Guid>(
                name: "AbroadVoterId",
                table: "AbroadVoterRefuseReasons",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialNeedsVotersId",
                table: "AbroadVoterRefuseReasons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_SpecialNeedsVotersId",
                table: "AbroadVoterRefuseReasons",
                column: "SpecialNeedsVotersId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoterRefuseReasons_AbroadVoters_AbroadVoterId",
                table: "AbroadVoterRefuseReasons",
                column: "AbroadVoterId",
                principalTable: "AbroadVoters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoterRefuseReasons_SpecialNeedsVoters_SpecialNeedsVotersId",
                table: "AbroadVoterRefuseReasons",
                column: "SpecialNeedsVotersId",
                principalTable: "SpecialNeedsVoters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoterRefuseReasons_AbroadVoters_AbroadVoterId",
                table: "AbroadVoterRefuseReasons");

            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoterRefuseReasons_SpecialNeedsVoters_SpecialNeedsVotersId",
                table: "AbroadVoterRefuseReasons");

            migrationBuilder.DropIndex(
                name: "IX_AbroadVoterRefuseReasons_SpecialNeedsVotersId",
                table: "AbroadVoterRefuseReasons");

            migrationBuilder.DropColumn(
                name: "SpecialNeedsVotersId",
                table: "AbroadVoterRefuseReasons");

            migrationBuilder.AlterColumn<Guid>(
                name: "AbroadVoterId",
                table: "AbroadVoterRefuseReasons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoterRefuseReasons_AbroadVoters_AbroadVoterId",
                table: "AbroadVoterRefuseReasons",
                column: "AbroadVoterId",
                principalTable: "AbroadVoters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
