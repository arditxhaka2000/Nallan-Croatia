using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addnewtableforcoalition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticCoalitionId",
                table: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropColumn(
                name: "CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CandidatePoliticalPartyCoalitionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticOnlyPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CandidatePoliticalPartyCoalitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CandidatePoliticalPartyCoalitionDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitionDetail_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitionDetail_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitionDetail_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitionDetail_CandidatePoliticalPartyCoalitions_CandidatePoliticalPartyCoalitionId",
                        column: x => x.CandidatePoliticalPartyCoalitionId,
                        principalTable: "CandidatePoliticalPartyCoalitions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitionDetail_CandidatePoliticParties_CandidatePoliticOnlyPartyId",
                        column: x => x.CandidatePoliticOnlyPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties",
                column: "CandidatePoliticalPartyCoalitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitionDetail_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticalPartyCoalitionDetail",
                column: "CandidatePoliticalPartyCoalitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitionDetail_CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitionDetail",
                column: "CandidatePoliticOnlyPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitionDetail_CreatedById",
                table: "CandidatePoliticalPartyCoalitionDetail",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitionDetail_DeletedById",
                table: "CandidatePoliticalPartyCoalitionDetail",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitionDetail_LastChangedById",
                table: "CandidatePoliticalPartyCoalitionDetail",
                column: "LastChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticCoalitionId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CandidatePoliticCoalitionId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_CandidatePoliticalPartyCoalitions_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties",
                column: "CandidatePoliticalPartyCoalitionId",
                principalTable: "CandidatePoliticalPartyCoalitions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticCoalitionId",
                table: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_CandidatePoliticalPartyCoalitions_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartyCoalitionDetail");

            migrationBuilder.DropIndex(
                name: "IX_CandidatePoliticParties_CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "CandidatePoliticalPartyCoalitionId",
                table: "CandidatePoliticParties");

            migrationBuilder.AddColumn<Guid>(
                name: "CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitions",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CandidatePoliticOnlyPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticCoalitionId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CandidatePoliticCoalitionId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CandidatePoliticOnlyPartyId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
