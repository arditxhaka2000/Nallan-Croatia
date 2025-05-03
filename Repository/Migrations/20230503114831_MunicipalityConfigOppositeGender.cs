using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class MunicipalityConfigOppositeGender : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateOppositeGenders_Elections_ElectionId",
                table: "CandidateOppositeGenders");

            migrationBuilder.DropIndex(
                name: "IX_CandidateOppositeGenders_ElectionId",
                table: "CandidateOppositeGenders");

            migrationBuilder.DropColumn(
                name: "CandidateNrOfList",
                table: "CandidateOppositeGenders");

            migrationBuilder.DropColumn(
                name: "ElectionId",
                table: "CandidateOppositeGenders");

            migrationBuilder.AddColumn<Guid>(
                name: "MunicipalityConfigOppositeGenderId",
                table: "CandidateOppositeGenders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MunicipalityConfigOppositeGenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParlamentaryElection = table.Column<bool>(type: "bit", nullable: false),
                    CandidateNrOfList = table.Column<int>(type: "int", nullable: false),
                    OppositeGenderPercentage = table.Column<int>(type: "int", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_MunicipalityConfigOppositeGenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MunicipalityConfigOppositeGenders_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityConfigOppositeGenders_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityConfigOppositeGenders_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityConfigOppositeGenders_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityConfigOppositeGenders_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_MunicipalityConfigOppositeGenderId",
                table: "CandidateOppositeGenders",
                column: "MunicipalityConfigOppositeGenderId");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityConfigOppositeGenders_CreatedById",
                table: "MunicipalityConfigOppositeGenders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityConfigOppositeGenders_DeletedById",
                table: "MunicipalityConfigOppositeGenders",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityConfigOppositeGenders_ElectionId",
                table: "MunicipalityConfigOppositeGenders",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityConfigOppositeGenders_LastChangedById",
                table: "MunicipalityConfigOppositeGenders",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityConfigOppositeGenders_MunicipalityId",
                table: "MunicipalityConfigOppositeGenders",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateOppositeGenders_MunicipalityConfigOppositeGenders_MunicipalityConfigOppositeGenderId",
                table: "CandidateOppositeGenders",
                column: "MunicipalityConfigOppositeGenderId",
                principalTable: "MunicipalityConfigOppositeGenders",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidateOppositeGenders_MunicipalityConfigOppositeGenders_MunicipalityConfigOppositeGenderId",
                table: "CandidateOppositeGenders");

            migrationBuilder.DropTable(
                name: "MunicipalityConfigOppositeGenders");

            migrationBuilder.DropIndex(
                name: "IX_CandidateOppositeGenders_MunicipalityConfigOppositeGenderId",
                table: "CandidateOppositeGenders");

            migrationBuilder.DropColumn(
                name: "MunicipalityConfigOppositeGenderId",
                table: "CandidateOppositeGenders");

            migrationBuilder.AddColumn<int>(
                name: "CandidateNrOfList",
                table: "CandidateOppositeGenders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ElectionId",
                table: "CandidateOppositeGenders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_ElectionId",
                table: "CandidateOppositeGenders",
                column: "ElectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidateOppositeGenders_Elections_ElectionId",
                table: "CandidateOppositeGenders",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");
        }
    }
}
