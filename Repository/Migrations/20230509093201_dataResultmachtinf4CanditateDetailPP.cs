using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class dataResultmachtinf4CanditateDetailPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingPoliticalParties_CandidateDetailPoliticParties_CandidateDetailPoliticPartyId",
                table: "DataResultsMatchingPoliticalParties");

            migrationBuilder.RenameColumn(
                name: "CandidateDetailPoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                newName: "CandidatePoliticPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingPoliticalParties_CandidateDetailPoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                newName: "IX_DataResultsMatchingPoliticalParties_CandidatePoliticPartyId");

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingCandidateDetailPPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false),
                    CandidateDetailPoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataResultsMatchingFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DataResultsMatchingCandidateDetailPPs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidateDetailPPs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidateDetailPPs_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidateDetailPPs_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidateDetailPPs_CandidateDetailPoliticParties_CandidateDetailPoliticPartyId",
                        column: x => x.CandidateDetailPoliticPartyId,
                        principalTable: "CandidateDetailPoliticParties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId",
                        column: x => x.DataResultsMatchingFormId,
                        principalTable: "DataResultsMatchingForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_CandidateDetailPoliticPartyId",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "CandidateDetailPoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_CreatedById",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingFormId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DeletedById",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_LastChangedById",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "LastChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingPoliticalParties_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingPoliticalParties_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "DataResultsMatchingPoliticalParties");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.RenameColumn(
                name: "CandidatePoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                newName: "CandidateDetailPoliticPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingPoliticalParties_CandidatePoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                newName: "IX_DataResultsMatchingPoliticalParties_CandidateDetailPoliticPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingPoliticalParties_CandidateDetailPoliticParties_CandidateDetailPoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                column: "CandidateDetailPoliticPartyId",
                principalTable: "CandidateDetailPoliticParties",
                principalColumn: "Id");
        }
    }
}
