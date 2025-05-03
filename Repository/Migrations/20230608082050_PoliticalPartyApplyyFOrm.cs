using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class PoliticalPartyApplyyFOrm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartyId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PoliticalParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    VillageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PoliticalParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalParties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParties_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParties_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParties_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParties_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartyPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonTypeId = table.Column<int>(type: "int", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_PoliticalPartyPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersons_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersons_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersons_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersons_Lists_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersons_PoliticalParties_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_CreatedById",
                table: "PoliticalParties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_DecisionId",
                table: "PoliticalParties",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_DeletedById",
                table: "PoliticalParties",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_LastChangedById",
                table: "PoliticalParties",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParties_MunicipalityId",
                table: "PoliticalParties",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_CreatedById",
                table: "PoliticalPartyPersons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_DeletedById",
                table: "PoliticalPartyPersons",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_LastChangedById",
                table: "PoliticalPartyPersons",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_PersonTypeId",
                table: "PoliticalPartyPersons",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_PoliticalPartyId",
                table: "PoliticalPartyPersons",
                column: "PoliticalPartyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalParties_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalParties_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "PoliticalPartyPersons");

            migrationBuilder.DropTable(
                name: "PoliticalParties");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyId",
                table: "Documents");
        }
    }
}
