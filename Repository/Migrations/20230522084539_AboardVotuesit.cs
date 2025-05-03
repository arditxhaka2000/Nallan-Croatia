using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AboardVotuesit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AbroadVoterId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbroadVoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboardCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboardCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAEComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_AbroadVoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoters_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AbroadVoterId",
                table: "Documents",
                column: "AbroadVoterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_CreatedById",
                table: "AbroadVoters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_DecisionId",
                table: "AbroadVoters",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_DeletedById",
                table: "AbroadVoters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_ElectionId",
                table: "AbroadVoters",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_GenderId",
                table: "AbroadVoters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_LastChangedById",
                table: "AbroadVoters",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_MunicipalityId",
                table: "AbroadVoters",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVoterId",
                table: "Documents",
                column: "AbroadVoterId",
                principalTable: "AbroadVoters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVoterId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "AbroadVoters");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AbroadVoterId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "AbroadVoterId",
                table: "Documents");
        }
    }
}
