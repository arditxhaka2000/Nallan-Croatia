using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CRC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DataResultsMatchingId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataResultMatchings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PollingStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DataResultMatchings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_PollingCenters_PollingCenterId",
                        column: x => x.PollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultMatchings_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDual = table.Column<bool>(type: "bit", nullable: false),
                    AcceptedNrOfPapers = table.Column<int>(type: "int", nullable: false),
                    NumberOfSignatures = table.Column<int>(type: "int", nullable: false),
                    ConditionalNumberOfSignatures = table.Column<int>(type: "int", nullable: false),
                    UnusedNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    DamagedNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    NumberOfPapersInsideBox = table.Column<int>(type: "int", nullable: false),
                    ConditionalNumberOfEnvelopeInsideBox = table.Column<int>(type: "int", nullable: false),
                    DifferenceOfNoSAndNPIB = table.Column<int>(type: "int", nullable: false),
                    ConditionalDifferenceOfCNoSAndCNPIB = table.Column<int>(type: "int", nullable: false),
                    EmptyNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    InvalidNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    ValidNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfEnpInpVnp = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    DifferenceOfAnpTnp = table.Column<int>(type: "int", nullable: false),
                    TotalValidNumberOfVotes = table.Column<int>(type: "int", nullable: false),
                    DataResultsMatchingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DataResultsMatchingForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingForms_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingForms_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingForms_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingForms_DataResultMatchings_DataResultsMatchingId",
                        column: x => x.DataResultsMatchingId,
                        principalTable: "DataResultMatchings",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DataResultsMatchingEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingEmployees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingEmployees_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingEmployees_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingEmployees_DataResultsMatchingForms_DataResultsMatchingFormId",
                        column: x => x.DataResultsMatchingFormId,
                        principalTable: "DataResultsMatchingForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingPoliticalParties",
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
                    table.PrimaryKey("PK_DataResultsMatchingPoliticalParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingPoliticalParties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingPoliticalParties_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingPoliticalParties_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingPoliticalParties_CandidateDetailPoliticParties_CandidateDetailPoliticPartyId",
                        column: x => x.CandidateDetailPoliticPartyId,
                        principalTable: "CandidateDetailPoliticParties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingPoliticalParties_DataResultsMatchingForms_DataResultsMatchingFormId",
                        column: x => x.DataResultsMatchingFormId,
                        principalTable: "DataResultsMatchingForms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StripeNrs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_StripeNrs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StripeNrs_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StripeNrs_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StripeNrs_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StripeNrs_DataResultsMatchingForms_DataResultsMatchingFormId",
                        column: x => x.DataResultsMatchingFormId,
                        principalTable: "DataResultsMatchingForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StripeNrs_Lists_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DataResultsMatchingId",
                table: "Documents",
                column: "DataResultsMatchingId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_CreatedById",
                table: "DataResultMatchings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_DecisionId",
                table: "DataResultMatchings",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_DeletedById",
                table: "DataResultMatchings",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_ElectionId",
                table: "DataResultMatchings",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_LastChangedById",
                table: "DataResultMatchings",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_MunicipalityId",
                table: "DataResultMatchings",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_PollingCenterId",
                table: "DataResultMatchings",
                column: "PollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultMatchings_PollingStationId",
                table: "DataResultMatchings",
                column: "PollingStationId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingEmployees_CreatedById",
                table: "DataResultsMatchingEmployees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingEmployees_DataResultsMatchingFormId",
                table: "DataResultsMatchingEmployees",
                column: "DataResultsMatchingFormId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingEmployees_DeletedById",
                table: "DataResultsMatchingEmployees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingEmployees_EmployeeId",
                table: "DataResultsMatchingEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingEmployees_LastChangedById",
                table: "DataResultsMatchingEmployees",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingForms_CreatedById",
                table: "DataResultsMatchingForms",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingForms_DataResultsMatchingId",
                table: "DataResultsMatchingForms",
                column: "DataResultsMatchingId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingForms_DeletedById",
                table: "DataResultsMatchingForms",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingForms_LastChangedById",
                table: "DataResultsMatchingForms",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingPoliticalParties_CandidateDetailPoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                column: "CandidateDetailPoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingPoliticalParties_CreatedById",
                table: "DataResultsMatchingPoliticalParties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingPoliticalParties_DataResultsMatchingFormId",
                table: "DataResultsMatchingPoliticalParties",
                column: "DataResultsMatchingFormId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingPoliticalParties_DeletedById",
                table: "DataResultsMatchingPoliticalParties",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingPoliticalParties_LastChangedById",
                table: "DataResultsMatchingPoliticalParties",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_StripeNrs_CreatedById",
                table: "StripeNrs",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_StripeNrs_DataResultsMatchingFormId",
                table: "StripeNrs",
                column: "DataResultsMatchingFormId");

            migrationBuilder.CreateIndex(
                name: "IX_StripeNrs_DeletedById",
                table: "StripeNrs",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_StripeNrs_LastChangedById",
                table: "StripeNrs",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_StripeNrs_TypeId",
                table: "StripeNrs",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DataResultMatchings_DataResultsMatchingId",
                table: "Documents",
                column: "DataResultsMatchingId",
                principalTable: "DataResultMatchings",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DataResultMatchings_DataResultsMatchingId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingEmployees");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingPoliticalParties");

            migrationBuilder.DropTable(
                name: "StripeNrs");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingForms");

            migrationBuilder.DropTable(
                name: "DataResultMatchings");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DataResultsMatchingId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DataResultsMatchingId",
                table: "Documents");
        }
    }
}
