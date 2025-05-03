using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addsome_columns_politicalparty_tbl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CommentDiscussion",
                table: "PoliticalParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FromDiscussion",
                table: "PoliticalParties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiscussion",
                table: "PoliticalParties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ToDiscussion",
                table: "PoliticalParties",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentDiscussion",
                table: "PoliticalParties");

            migrationBuilder.DropColumn(
                name: "FromDiscussion",
                table: "PoliticalParties");

            migrationBuilder.DropColumn(
                name: "IsDiscussion",
                table: "PoliticalParties");

            migrationBuilder.DropColumn(
                name: "ToDiscussion",
                table: "PoliticalParties");
        }
    }
}
