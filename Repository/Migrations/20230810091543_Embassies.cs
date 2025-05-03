using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Embassies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmbassyId",
                table: "AbroadVoters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Embassies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxNrOfVoters = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embassies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Embassies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Embassies_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Embassies_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Embassies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_EmbassyId",
                table: "AbroadVoters",
                column: "EmbassyId");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_CountryId",
                table: "Embassies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_CreatedById",
                table: "Embassies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_DeletedById",
                table: "Embassies",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_LastChangedById",
                table: "Embassies",
                column: "LastChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoters_Embassies_EmbassyId",
                table: "AbroadVoters",
                column: "EmbassyId",
                principalTable: "Embassies",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoters_Embassies_EmbassyId",
                table: "AbroadVoters");

            migrationBuilder.DropTable(
                name: "Embassies");

            migrationBuilder.DropIndex(
                name: "IX_AbroadVoters_EmbassyId",
                table: "AbroadVoters");

            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "EmbassyId",
                table: "AbroadVoters");
        }
    }
}
