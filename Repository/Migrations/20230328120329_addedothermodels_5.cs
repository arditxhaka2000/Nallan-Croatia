using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addedothermodels_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_PoliticalParties_PoliticalPartyId",
                table: "CandidatePoliticParties");

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EmployeementId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartyPersonSignatureId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartySignatureId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "PoliticalPartyId",
                table: "CandidatePoliticParties",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "PoliticalPartyName",
                table: "CandidatePoliticParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CandidateDeclarationDate",
                table: "CandidateDetailPoliticParties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CandidateDeclarationPlace",
                table: "CandidateDetailPoliticParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PoliticalSubjectAuth",
                table: "CandidateDetailPoliticParties",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PoliticalSubjectAuthDate",
                table: "CandidateDetailPoliticParties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CandidatePoliticalPartyCoalitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticOnlyPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CandidatePoliticCoalitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_CandidatePoliticalPartyCoalitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitions_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitions_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitions_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticCoalitionId",
                        column: x => x.CandidatePoliticCoalitionId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitions_CandidatePoliticParties_CandidatePoliticOnlyPartyId",
                        column: x => x.CandidatePoliticOnlyPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employeements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InstitutionId = table.Column<int>(type: "int", nullable: true),
                    JobPositionId = table.Column<int>(type: "int", nullable: true),
                    SalaryTypeId = table.Column<int>(type: "int", nullable: true),
                    SalaryCoefientId = table.Column<int>(type: "int", nullable: true),
                    LabelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReasonContractTermination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfResignation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsEmployeement = table.Column<bool>(type: "bit", nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    EmployeementStatusId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Employeements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employeements_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_Lists_EmployeementStatusId",
                        column: x => x.EmployeementStatusId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_Lists_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_Lists_JobPositionId",
                        column: x => x.JobPositionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_Lists_SalaryCoefientId",
                        column: x => x.SalaryCoefientId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_Lists_SalaryTypeId",
                        column: x => x.SalaryTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ObserversApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    ObserversApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionId = table.Column<int>(type: "int", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiplomaticMissionId = table.Column<int>(type: "int", nullable: true),
                    DiplomaticMissionMediaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_ObserversApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserversApplications_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_Lists_DiplomaticMissionId",
                        column: x => x.DiplomaticMissionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_Lists_InstitutionId",
                        column: x => x.InstitutionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_Lists_ObserversApplicationTypeId",
                        column: x => x.ObserversApplicationTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplications_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartySignatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    TotalSignatures = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_PoliticalPartySignatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalPartySignatures_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartySignatures_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartySignatures_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartySignatures_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoliticalPartySignatures_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeReferences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeReferences_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeReferences_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeReferences_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeReferences_Employeements_EmployeementId",
                        column: x => x.EmployeementId,
                        principalTable: "Employeements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ObserversApplicationFieldInteresteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObserversApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObserversApplicationFieldTypeId = table.Column<int>(type: "int", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_ObserversApplicationFieldInteresteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserversApplicationFieldInteresteds_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplicationFieldInteresteds_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplicationFieldInteresteds_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplicationFieldInteresteds_Lists_ObserversApplicationFieldTypeId",
                        column: x => x.ObserversApplicationFieldTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserversApplicationFieldInteresteds_ObserversApplications_ObserversApplicationId",
                        column: x => x.ObserversApplicationId,
                        principalTable: "ObserversApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartyPersonSignatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PoliticalPartySignatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_PoliticalPartyPersonSignatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersonSignatures_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersonSignatures_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersonSignatures_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersonSignatures_PoliticalPartySignatures_PoliticalPartySignatureId",
                        column: x => x.PoliticalPartySignatureId,
                        principalTable: "PoliticalPartySignatures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployeeId",
                table: "Documents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployeementId",
                table: "Documents",
                column: "EmployeementId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyPersonSignatureId",
                table: "Documents",
                column: "PoliticalPartyPersonSignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartySignatureId",
                table: "Documents",
                column: "PoliticalPartySignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_CandidatePoliticCoalitionId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CandidatePoliticCoalitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_CandidatePoliticOnlyPartyId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CandidatePoliticOnlyPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_CreatedById",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_DeletedById",
                table: "CandidatePoliticalPartyCoalitions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_LastChangedById",
                table: "CandidatePoliticalPartyCoalitions",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_CreatedById",
                table: "Employeements",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_DeletedById",
                table: "Employeements",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_ElectionId",
                table: "Employeements",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_EmployeeId",
                table: "Employeements",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_EmployeementStatusId",
                table: "Employeements",
                column: "EmployeementStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_InstitutionId",
                table: "Employeements",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_JobPositionId",
                table: "Employeements",
                column: "JobPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LastChangedById",
                table: "Employeements",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_SalaryCoefientId",
                table: "Employeements",
                column: "SalaryCoefientId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_SalaryTypeId",
                table: "Employeements",
                column: "SalaryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReferences_CreatedById",
                table: "EmployeeReferences",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReferences_DeletedById",
                table: "EmployeeReferences",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReferences_EmployeementId",
                table: "EmployeeReferences",
                column: "EmployeementId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeReferences_LastChangedById",
                table: "EmployeeReferences",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplicationFieldInteresteds_CreatedById",
                table: "ObserversApplicationFieldInteresteds",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplicationFieldInteresteds_DeletedById",
                table: "ObserversApplicationFieldInteresteds",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplicationFieldInteresteds_LastChangedById",
                table: "ObserversApplicationFieldInteresteds",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplicationFieldInteresteds_ObserversApplicationFieldTypeId",
                table: "ObserversApplicationFieldInteresteds",
                column: "ObserversApplicationFieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplicationFieldInteresteds_ObserversApplicationId",
                table: "ObserversApplicationFieldInteresteds",
                column: "ObserversApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_CandidatePoliticPartyId",
                table: "ObserversApplications",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_CreatedById",
                table: "ObserversApplications",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_DeletedById",
                table: "ObserversApplications",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_DiplomaticMissionId",
                table: "ObserversApplications",
                column: "DiplomaticMissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_ElectionId",
                table: "ObserversApplications",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_InstitutionId",
                table: "ObserversApplications",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_LastChangedById",
                table: "ObserversApplications",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_MunicipalityId",
                table: "ObserversApplications",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserversApplications_ObserversApplicationTypeId",
                table: "ObserversApplications",
                column: "ObserversApplicationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersonSignatures_CreatedById",
                table: "PoliticalPartyPersonSignatures",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersonSignatures_DeletedById",
                table: "PoliticalPartyPersonSignatures",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersonSignatures_LastChangedById",
                table: "PoliticalPartyPersonSignatures",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersonSignatures_PoliticalPartySignatureId",
                table: "PoliticalPartyPersonSignatures",
                column: "PoliticalPartySignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartySignatures_CandidatePoliticPartyId",
                table: "PoliticalPartySignatures",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartySignatures_CreatedById",
                table: "PoliticalPartySignatures",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartySignatures_DeletedById",
                table: "PoliticalPartySignatures",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartySignatures_ElectionId",
                table: "PoliticalPartySignatures",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartySignatures_LastChangedById",
                table: "PoliticalPartySignatures",
                column: "LastChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_PoliticalParties_PoliticalPartyId",
                table: "CandidatePoliticParties",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Employeements_EmployeementId",
                table: "Documents",
                column: "EmployeementId",
                principalTable: "Employeements",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Employees_EmployeeId",
                table: "Documents",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalPartyPersonSignatures_PoliticalPartyPersonSignatureId",
                table: "Documents",
                column: "PoliticalPartyPersonSignatureId",
                principalTable: "PoliticalPartyPersonSignatures",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalPartySignatures_PoliticalPartySignatureId",
                table: "Documents",
                column: "PoliticalPartySignatureId",
                principalTable: "PoliticalPartySignatures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_PoliticalParties_PoliticalPartyId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employeements_EmployeementId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employees_EmployeeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalPartyPersonSignatures_PoliticalPartyPersonSignatureId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalPartySignatures_PoliticalPartySignatureId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropTable(
                name: "EmployeeReferences");

            migrationBuilder.DropTable(
                name: "ObserversApplicationFieldInteresteds");

            migrationBuilder.DropTable(
                name: "PoliticalPartyPersonSignatures");

            migrationBuilder.DropTable(
                name: "Employeements");

            migrationBuilder.DropTable(
                name: "ObserversApplications");

            migrationBuilder.DropTable(
                name: "PoliticalPartySignatures");

            migrationBuilder.DropIndex(
                name: "IX_Documents_EmployeeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_EmployeementId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyPersonSignatureId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartySignatureId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "EmployeementId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyPersonSignatureId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartySignatureId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyName",
                table: "CandidatePoliticParties");

            migrationBuilder.DropColumn(
                name: "CandidateDeclarationDate",
                table: "CandidateDetailPoliticParties");

            migrationBuilder.DropColumn(
                name: "CandidateDeclarationPlace",
                table: "CandidateDetailPoliticParties");

            migrationBuilder.DropColumn(
                name: "PoliticalSubjectAuth",
                table: "CandidateDetailPoliticParties");

            migrationBuilder.DropColumn(
                name: "PoliticalSubjectAuthDate",
                table: "CandidateDetailPoliticParties");

            migrationBuilder.AlterColumn<Guid>(
                name: "PoliticalPartyId",
                table: "CandidatePoliticParties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_PoliticalParties_PoliticalPartyId",
                table: "CandidatePoliticParties",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
