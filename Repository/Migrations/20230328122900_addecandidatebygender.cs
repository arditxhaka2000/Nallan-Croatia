using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addecandidatebygender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalPartyPersonSignatures_PoliticalPartyPersonSignatureId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyPersonSignatureId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyPersonSignatureId",
                table: "Documents");

            migrationBuilder.CreateTable(
                name: "CandidateOppositeGenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    CandidateNrOfList = table.Column<int>(type: "int", nullable: false),
                    SmallestNrByGender = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_CandidateOppositeGenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateOppositeGenders_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateOppositeGenders_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateOppositeGenders_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateOppositeGenders_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_CreatedById",
                table: "CandidateOppositeGenders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_DeletedById",
                table: "CandidateOppositeGenders",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_ElectionId",
                table: "CandidateOppositeGenders",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_LastChangedById",
                table: "CandidateOppositeGenders",
                column: "LastChangedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CandidateOppositeGenders");

            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartyPersonSignatureId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyPersonSignatureId",
                table: "Documents",
                column: "PoliticalPartyPersonSignatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalPartyPersonSignatures_PoliticalPartyPersonSignatureId",
                table: "Documents",
                column: "PoliticalPartyPersonSignatureId",
                principalTable: "PoliticalPartyPersonSignatures",
                principalColumn: "Id");
        }
    }
}
