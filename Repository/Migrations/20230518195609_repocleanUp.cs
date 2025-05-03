using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class repocleanUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CandidatePoliticalPartyPersons_CandidatePoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_DataResultMatchings_DataResultsMatchingId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employeements_EmployeementId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Employees_EmployeeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ObserverOrganizationPersons_ObserverOrganizationPersonId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ObserverOrganizations_ObserverOrganizationId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ObserversApplications_ObserversApplicationId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalParties_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalPartyPersons_PoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalPartySignatures_PoliticalPartySignatureId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "CandidateOppositeGenders");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartyCoalitionDetail");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartyPersons");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartySupports");

            migrationBuilder.DropTable(
                name: "CandidatePoliticPartyCommunities");

            migrationBuilder.DropTable(
                name: "CandidatePoliticPartyControls");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingCandidatePPEmployees");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingEmployees");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingPoliticalParties");

            migrationBuilder.DropTable(
                name: "EmployeeEduactionTrainings");

            migrationBuilder.DropTable(
                name: "EmployeeEvaluationTraining");

            migrationBuilder.DropTable(
                name: "EmployeeLanguageSkills");

            migrationBuilder.DropTable(
                name: "EmployeeReferences");

            migrationBuilder.DropTable(
                name: "EmployeeSkills");

            migrationBuilder.DropTable(
                name: "EmployeeWorkExperiences");

            migrationBuilder.DropTable(
                name: "ObserverOrganizationPersons");

            migrationBuilder.DropTable(
                name: "ObserverOrganizationTranslations");

            migrationBuilder.DropTable(
                name: "ObserversApplicationFieldInteresteds");

            migrationBuilder.DropTable(
                name: "PoliticalPartyControls");

            migrationBuilder.DropTable(
                name: "PoliticalPartyPersons");

            migrationBuilder.DropTable(
                name: "PoliticalPartyPersonSignatures");

            migrationBuilder.DropTable(
                name: "StripeNrs");

            migrationBuilder.DropTable(
                name: "Voters");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartyCoalitions");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.DropTable(
                name: "EmployeeEvaluates");

            migrationBuilder.DropTable(
                name: "Employeements");

            migrationBuilder.DropTable(
                name: "ObserverOrganizations");

            migrationBuilder.DropTable(
                name: "PoliticalPartySignatures");

            migrationBuilder.DropTable(
                name: "CandidateDetailPoliticParties");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingForms");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "ObserversApplications");

            migrationBuilder.DropTable(
                name: "DataResultMatchings");

            migrationBuilder.DropTable(
                name: "CandidatePoliticParties");

            migrationBuilder.DropTable(
                name: "PollingStations");

            migrationBuilder.DropTable(
                name: "PoliticalParties");

            migrationBuilder.DropTable(
                name: "PollingCenters");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CandidatePoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CandidatePoliticPartyId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DataResultsMatchingId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_EmployeeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_EmployeementId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ObserverOrganizationId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ObserverOrganizationPersonId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ObserversApplicationId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartySignatureId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CandidatePoliticPartyId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CandidatePoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DataResultsMatchingId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "EmployeementId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ObserverOrganizationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ObserverOrganizationPersonId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ObserversApplicationId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartySignatureId",
                table: "Documents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CandidatePoliticPartyId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CandidatePoliticalPartyPersonId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DataResultsMatchingId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "ObserverOrganizationId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ObserverOrganizationPersonId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ObserversApplicationId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartyId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartyPersonId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartySignatureId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CandidateOppositeGenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityConfigOppositeGenderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNr = table.Column<int>(type: "int", nullable: false),
                    SmallestNrByGender = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_CandidateOppositeGenders_MunicipalityConfigOppositeGenders_MunicipalityConfigOppositeGenderId",
                        column: x => x.MunicipalityConfigOppositeGenderId,
                        principalTable: "MunicipalityConfigOppositeGenders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankNameId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    HighestEducationLevelId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LocationUnitId = table.Column<int>(type: "int", nullable: true),
                    MunicipalityResidenceId = table.Column<int>(type: "int", nullable: true),
                    WorkingPositionId = table.Column<int>(type: "int", nullable: true),
                    BankHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeclareEnticity = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HasCourtCertificate = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsEmployeed = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Lists_BankNameId",
                        column: x => x.BankNameId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Lists_HighestEducationLevelId",
                        column: x => x.HighestEducationLevelId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Lists_LocationUnitId",
                        column: x => x.LocationUnitId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Lists_WorkingPositionId",
                        column: x => x.WorkingPositionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Municipalities_MunicipalityResidenceId",
                        column: x => x.MunicipalityResidenceId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsParliamentary = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageName = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "PollingCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    ActualNrOfPollingStations = table.Column<int>(type: "int", nullable: false),
                    ActualNrOfVoters = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaxNrOfPollingStations = table.Column<int>(type: "int", nullable: false),
                    MaxNrOfVoters = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollingCenters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollingCenters_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenters_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenters_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenters_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenters_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEduactionTrainings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EducationTraningId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AcademicTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InstitucionLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEduactionTrainings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTrainings_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTrainings_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTrainings_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTrainings_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTrainings_Lists_EducationTraningId",
                        column: x => x.EducationTraningId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEvaluates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SupervisorRatingId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElectionSentence = table.Column<bool>(type: "bit", nullable: false),
                    HasViolentPenal = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEvaluates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluates_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluates_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluates_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluates_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluates_Lists_SupervisorRatingId",
                        column: x => x.SupervisorRatingId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLanguageSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReadingId = table.Column<int>(type: "int", nullable: true),
                    SpeakingId = table.Column<int>(type: "int", nullable: true),
                    UnderstandingId = table.Column<int>(type: "int", nullable: true),
                    WritingId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLanguageSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_Lists_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_Lists_ReadingId",
                        column: x => x.ReadingId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_Lists_SpeakingId",
                        column: x => x.SpeakingId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_Lists_UnderstandingId",
                        column: x => x.UnderstandingId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeLanguageSkills_Lists_WritingId",
                        column: x => x.WritingId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DatabaseDevelopmentId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExcelId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WordId = table.Column<int>(type: "int", nullable: true),
                    ApplingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OtherSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherSoftProgram = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Lists_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Lists_DatabaseDevelopmentId",
                        column: x => x.DatabaseDevelopmentId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Lists_ExcelId",
                        column: x => x.ExcelId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkills_Lists_WordId",
                        column: x => x.WordId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkExperiences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmployerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeavingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupervisedEmployeeNr = table.Column<int>(type: "int", nullable: false),
                    SupervisedEmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkExperiences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperiences_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperiences_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperiences_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperiences_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypePoliticalPartyId = table.Column<int>(type: "int", nullable: true),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CandidateNr = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticalPartyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PullNoteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PullNoteFirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PullNoteLastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PullNotePlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementCourtesyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementCourtesyPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementGivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementGivenPlace = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePoliticParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParties_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParties_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParties_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParties_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParties_Lists_TypePoliticalPartyId",
                        column: x => x.TypePoliticalPartyId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParties_PoliticalParties_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartyControls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlNameId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalPartyControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalPartyControls_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyControls_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyControls_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyControls_Lists_ControlNameId",
                        column: x => x.ControlNameId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyControls_PoliticalParties_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartyPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PersonTypeId = table.Column<int>(type: "int", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        name: "FK_PoliticalPartyPersons_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersons_PoliticalParties_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollingStations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PollingStationTypeId = table.Column<int>(type: "int", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalNrOfVoters = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollingStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollingStations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStations_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStations_Lists_PollingStationTypeId",
                        column: x => x.PollingStationTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStations_PollingCenters_PollingCenterId",
                        column: x => x.PollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeEvaluationTraining",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CompletedTrainingId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeEvaluateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeEvaluationTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluationTraining_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluationTraining_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluationTraining_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluationTraining_EmployeeEvaluates_EmployeeEvaluateId",
                        column: x => x.EmployeeEvaluateId,
                        principalTable: "EmployeeEvaluates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluationTraining_Lists_CompletedTrainingId",
                        column: x => x.CompletedTrainingId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEvaluationTraining_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidateDetailPoliticParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CandidateDeclarationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CandidateDeclarationPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNr = table.Column<int>(type: "int", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticalSubjectAuth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticalSubjectAuthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateDetailPoliticParties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateDetailPoliticParties_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateDetailPoliticParties_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateDetailPoliticParties_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateDetailPoliticParties_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateDetailPoliticParties_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidateDetailPoliticParties_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticalPartyCoalitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticCoalitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyCoalitions_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticalPartyPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PersonTypeId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AlternateEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lastame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePoliticalPartyPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPersons_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPersons_Lists_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPersons_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticalPartySupports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderNr = table.Column<int>(type: "int", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePoliticalPartySupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartySupports_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartySupports_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartySupports_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartySupports_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticPartyCommunities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePoliticPartyCommunities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunities_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunities_Lists_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticPartyControls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlNameId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidatePoliticPartyControls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControls_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControls_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControls_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControls_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControls_Lists_ControlNameId",
                        column: x => x.ControlNameId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ObserversApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DiplomaticMissionId = table.Column<int>(type: "int", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    InstitutionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    ObserversApplicationTypeId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmNotDiscualifition = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DiplomaticMissionMediaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrganizationName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalSignatures = table.Column<int>(type: "int", nullable: false)
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
                    table.ForeignKey(
                        name: "FK_PoliticalPartySignatures_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataResultMatchings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PollingStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Employeements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EmployeementStatusId = table.Column<int>(type: "int", nullable: true),
                    InstitutionId = table.Column<int>(type: "int", nullable: true),
                    JobPositionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LocationElectionMunicipalityId = table.Column<int>(type: "int", nullable: true),
                    LocationElectionPoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationElectionPollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LocationElectionPollingStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SalaryCoefientId = table.Column<int>(type: "int", nullable: true),
                    SalaryTypeId = table.Column<int>(type: "int", nullable: true),
                    ContractEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractTerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfResignation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LabelDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReasonContractTermination = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Employeements_Municipalities_LocationElectionMunicipalityId",
                        column: x => x.LocationElectionMunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_PoliticalParties_LocationElectionPoliticalPartyId",
                        column: x => x.LocationElectionPoliticalPartyId,
                        principalTable: "PoliticalParties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_PollingCenters_LocationElectionPollingCenterId",
                        column: x => x.LocationElectionPollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employeements_PollingStations_LocationElectionPollingStationId",
                        column: x => x.LocationElectionPollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Voters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PollingStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PollingStationAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PollingStationCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Voters_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_PollingCenters_PollingCenterId",
                        column: x => x.PollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Voters_PollingStations_PollingStationId",
                        column: x => x.PollingStationId,
                        principalTable: "PollingStations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticalPartyCoalitionDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticalPartyCoalitionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CandidatePoliticOnlyPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ObserverOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    ObserversApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObserverOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_ObserversApplications_ObserversApplicationId",
                        column: x => x.ObserversApplicationId,
                        principalTable: "ObserversApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObserversApplicationFieldInteresteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ObserversApplicationFieldTypeId = table.Column<int>(type: "int", nullable: true),
                    ObserversApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PoliticalPartySignatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SignaturePersonTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                        name: "FK_PoliticalPartyPersonSignatures_Lists_SignaturePersonTypeId",
                        column: x => x.SignaturePersonTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPersonSignatures_PoliticalPartySignatures_PoliticalPartySignatureId",
                        column: x => x.PoliticalPartySignatureId,
                        principalTable: "PoliticalPartySignatures",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingForms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataResultsMatchingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AcceptedNrOfPapers = table.Column<int>(type: "int", nullable: false),
                    ConditionalDifferenceOfCNoSAndCNPIB = table.Column<int>(type: "int", nullable: false),
                    ConditionalNumberOfEnvelopeInsideBox = table.Column<int>(type: "int", nullable: false),
                    ConditionalNumberOfSignatures = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DamagedNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DifferenceOfAnpTnp = table.Column<int>(type: "int", nullable: false),
                    DifferenceOfNoSAndNPIB = table.Column<int>(type: "int", nullable: false),
                    EmptyNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    InvalidNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDual = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumberOfPapersInsideBox = table.Column<int>(type: "int", nullable: false),
                    NumberOfSignatures = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfEnpInpVnp = table.Column<int>(type: "int", nullable: false),
                    TotalNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    TotalValidNumberOfVotes = table.Column<int>(type: "int", nullable: false),
                    UnusedNumberOfPapers = table.Column<int>(type: "int", nullable: false),
                    ValidNumberOfPapers = table.Column<int>(type: "int", nullable: false)
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
                name: "EmployeeReferences",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "ObserverOrganizationPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ObserverOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObserverOrganizationPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_ObserverOrganizations_ObserverOrganizationId",
                        column: x => x.ObserverOrganizationId,
                        principalTable: "ObserverOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObserverOrganizationTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ObserverOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObserverOrganizationTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_ObserverOrganizations_ObserverOrganizationId",
                        column: x => x.ObserverOrganizationId,
                        principalTable: "ObserverOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingCandidateDetailPPs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateDetailPoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataResultsMatchingFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataResultsMatchingFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataResultsMatchingFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Votes = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_DataResultsMatchingPoliticalParties_CandidatePoliticParties_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParties",
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
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataResultsMatchingFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nr = table.Column<string>(type: "nvarchar(max)", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingCandidatePPEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataResultsMatchingFormId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataResultsMatchingCandidateDetailPPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataResultsMatchingCandidatePPEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingCandidateDetailPPId",
                        column: x => x.DataResultsMatchingCandidateDetailPPId,
                        principalTable: "DataResultsMatchingCandidateDetailPPs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingForms_DataResultsMatchingFormId",
                        column: x => x.DataResultsMatchingFormId,
                        principalTable: "DataResultsMatchingForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CandidatePoliticalPartyPersonId",
                table: "Documents",
                column: "CandidatePoliticalPartyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CandidatePoliticPartyId",
                table: "Documents",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DataResultsMatchingId",
                table: "Documents",
                column: "DataResultsMatchingId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployeeId",
                table: "Documents",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EmployeementId",
                table: "Documents",
                column: "EmployeementId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ObserverOrganizationId",
                table: "Documents",
                column: "ObserverOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ObserverOrganizationPersonId",
                table: "Documents",
                column: "ObserverOrganizationPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ObserversApplicationId",
                table: "Documents",
                column: "ObserversApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyPersonId",
                table: "Documents",
                column: "PoliticalPartyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartySignatureId",
                table: "Documents",
                column: "PoliticalPartySignatureId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetailPoliticParties_CandidatePoliticPartyId",
                table: "CandidateDetailPoliticParties",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetailPoliticParties_CreatedById",
                table: "CandidateDetailPoliticParties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetailPoliticParties_DeletedById",
                table: "CandidateDetailPoliticParties",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetailPoliticParties_GenderId",
                table: "CandidateDetailPoliticParties",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetailPoliticParties_LastChangedById",
                table: "CandidateDetailPoliticParties",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateDetailPoliticParties_MunicipalityId",
                table: "CandidateDetailPoliticParties",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_CreatedById",
                table: "CandidateOppositeGenders",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_DeletedById",
                table: "CandidateOppositeGenders",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_LastChangedById",
                table: "CandidateOppositeGenders",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateOppositeGenders_MunicipalityConfigOppositeGenderId",
                table: "CandidateOppositeGenders",
                column: "MunicipalityConfigOppositeGenderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_CandidatePoliticCoalitionId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CandidatePoliticCoalitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_CreatedById",
                table: "CandidatePoliticalPartyCoalitions",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_DeletedById",
                table: "CandidatePoliticalPartyCoalitions",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_ElectionId",
                table: "CandidatePoliticalPartyCoalitions",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyCoalitions_LastChangedById",
                table: "CandidatePoliticalPartyCoalitions",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPersons_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPersons",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPersons_CreatedById",
                table: "CandidatePoliticalPartyPersons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPersons_DeletedById",
                table: "CandidatePoliticalPartyPersons",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPersons_LastChangedById",
                table: "CandidatePoliticalPartyPersons",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPersons_MunicipalityId",
                table: "CandidatePoliticalPartyPersons",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPersons_PersonTypeId",
                table: "CandidatePoliticalPartyPersons",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartySupports_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartySupports",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartySupports_CreatedById",
                table: "CandidatePoliticalPartySupports",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartySupports_DeletedById",
                table: "CandidatePoliticalPartySupports",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartySupports_LastChangedById",
                table: "CandidatePoliticalPartySupports",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_CreatedById",
                table: "CandidatePoliticParties",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_DecisionId",
                table: "CandidatePoliticParties",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_DeletedById",
                table: "CandidatePoliticParties",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_ElectionId",
                table: "CandidatePoliticParties",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_LastChangedById",
                table: "CandidatePoliticParties",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_PoliticalPartyId",
                table: "CandidatePoliticParties",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParties_TypePoliticalPartyId",
                table: "CandidatePoliticParties",
                column: "TypePoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunities_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunities",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunities_CommunityId",
                table: "CandidatePoliticPartyCommunities",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunities_CreatedById",
                table: "CandidatePoliticPartyCommunities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunities_DeletedById",
                table: "CandidatePoliticPartyCommunities",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunities_LastChangedById",
                table: "CandidatePoliticPartyCommunities",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControls_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControls",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControls_ControlNameId",
                table: "CandidatePoliticPartyControls",
                column: "ControlNameId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControls_CreatedById",
                table: "CandidatePoliticPartyControls",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControls_DeletedById",
                table: "CandidatePoliticPartyControls",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControls_LastChangedById",
                table: "CandidatePoliticPartyControls",
                column: "LastChangedById");

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

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_CreatedById",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingCandidateDetailPPId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DataResultsMatchingCandidateDetailPPId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DataResultsMatchingFormId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DeletedById",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_EmployeeId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_LastChangedById",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "LastChangedById");

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
                name: "IX_DataResultsMatchingPoliticalParties_CandidatePoliticPartyId",
                table: "DataResultsMatchingPoliticalParties",
                column: "CandidatePoliticPartyId");

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
                name: "IX_EmployeeEduactionTrainings_CreatedById",
                table: "EmployeeEduactionTrainings",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTrainings_DeletedById",
                table: "EmployeeEduactionTrainings",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTrainings_EducationTraningId",
                table: "EmployeeEduactionTrainings",
                column: "EducationTraningId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTrainings_EmployeeId",
                table: "EmployeeEduactionTrainings",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTrainings_LastChangedById",
                table: "EmployeeEduactionTrainings",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluates_CreatedById",
                table: "EmployeeEvaluates",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluates_DeletedById",
                table: "EmployeeEvaluates",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluates_EmployeeId",
                table: "EmployeeEvaluates",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluates_LastChangedById",
                table: "EmployeeEvaluates",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluates_SupervisorRatingId",
                table: "EmployeeEvaluates",
                column: "SupervisorRatingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationTraining_CompletedTrainingId",
                table: "EmployeeEvaluationTraining",
                column: "CompletedTrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationTraining_CreatedById",
                table: "EmployeeEvaluationTraining",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationTraining_DeletedById",
                table: "EmployeeEvaluationTraining",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationTraining_EmployeeEvaluateId",
                table: "EmployeeEvaluationTraining",
                column: "EmployeeEvaluateId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationTraining_LastChangedById",
                table: "EmployeeEvaluationTraining",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEvaluationTraining_MunicipalityId",
                table: "EmployeeEvaluationTraining",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_CreatedById",
                table: "EmployeeLanguageSkills",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_DeletedById",
                table: "EmployeeLanguageSkills",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_EmployeeId",
                table: "EmployeeLanguageSkills",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_LanguageId",
                table: "EmployeeLanguageSkills",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_LastChangedById",
                table: "EmployeeLanguageSkills",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_ReadingId",
                table: "EmployeeLanguageSkills",
                column: "ReadingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_SpeakingId",
                table: "EmployeeLanguageSkills",
                column: "SpeakingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_UnderstandingId",
                table: "EmployeeLanguageSkills",
                column: "UnderstandingId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLanguageSkills_WritingId",
                table: "EmployeeLanguageSkills",
                column: "WritingId");

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
                name: "IX_Employeements_LocationElectionMunicipalityId",
                table: "Employeements",
                column: "LocationElectionMunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LocationElectionPoliticalPartyId",
                table: "Employeements",
                column: "LocationElectionPoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LocationElectionPollingCenterId",
                table: "Employeements",
                column: "LocationElectionPollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Employeements_LocationElectionPollingStationId",
                table: "Employeements",
                column: "LocationElectionPollingStationId");

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
                name: "IX_Employees_BankNameId",
                table: "Employees",
                column: "BankNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CreatedById",
                table: "Employees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DeletedById",
                table: "Employees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ElectionId",
                table: "Employees",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HighestEducationLevelId",
                table: "Employees",
                column: "HighestEducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LastChangedById",
                table: "Employees",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationUnitId",
                table: "Employees",
                column: "LocationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_MunicipalityResidenceId",
                table: "Employees",
                column: "MunicipalityResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkingPositionId",
                table: "Employees",
                column: "WorkingPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_AccessId",
                table: "EmployeeSkills",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_CreatedById",
                table: "EmployeeSkills",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_DatabaseDevelopmentId",
                table: "EmployeeSkills",
                column: "DatabaseDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_DeletedById",
                table: "EmployeeSkills",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_ExcelId",
                table: "EmployeeSkills",
                column: "ExcelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_LastChangedById",
                table: "EmployeeSkills",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkills_WordId",
                table: "EmployeeSkills",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperiences_CreatedById",
                table: "EmployeeWorkExperiences",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperiences_DeletedById",
                table: "EmployeeWorkExperiences",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperiences_EmployeeId",
                table: "EmployeeWorkExperiences",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperiences_LastChangedById",
                table: "EmployeeWorkExperiences",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_CreatedById",
                table: "ObserverOrganizationPersons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_DeletedById",
                table: "ObserverOrganizationPersons",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_LastChangedById",
                table: "ObserverOrganizationPersons",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_ObserverOrganizationId",
                table: "ObserverOrganizationPersons",
                column: "ObserverOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_CreatedById",
                table: "ObserverOrganizations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_DeletedById",
                table: "ObserverOrganizations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_LastChangedById",
                table: "ObserverOrganizations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_MunicipalityId",
                table: "ObserverOrganizations",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_ObserversApplicationId",
                table: "ObserverOrganizations",
                column: "ObserversApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_CreatedById",
                table: "ObserverOrganizationTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_DeletedById",
                table: "ObserverOrganizationTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_LanguageId",
                table: "ObserverOrganizationTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_LastChangedById",
                table: "ObserverOrganizationTranslations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_ObserverOrganizationId",
                table: "ObserverOrganizationTranslations",
                column: "ObserverOrganizationId");

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
                name: "IX_PoliticalPartyControls_ControlNameId",
                table: "PoliticalPartyControls",
                column: "ControlNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyControls_CreatedById",
                table: "PoliticalPartyControls",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyControls_DeletedById",
                table: "PoliticalPartyControls",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyControls_LastChangedById",
                table: "PoliticalPartyControls",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyControls_PoliticalPartyId",
                table: "PoliticalPartyControls",
                column: "PoliticalPartyId");

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
                name: "IX_PoliticalPartyPersons_MunicipalityId",
                table: "PoliticalPartyPersons",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_PersonTypeId",
                table: "PoliticalPartyPersons",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPersons_PoliticalPartyId",
                table: "PoliticalPartyPersons",
                column: "PoliticalPartyId");

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
                name: "IX_PoliticalPartyPersonSignatures_SignaturePersonTypeId",
                table: "PoliticalPartyPersonSignatures",
                column: "SignaturePersonTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartySignatures_MunicipalityId",
                table: "PoliticalPartySignatures",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenters_CreatedById",
                table: "PollingCenters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenters_DeletedById",
                table: "PollingCenters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenters_ElectionId",
                table: "PollingCenters",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenters_LastChangedById",
                table: "PollingCenters",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenters_MunicipalityId",
                table: "PollingCenters",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_CreatedById",
                table: "PollingStations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_DeletedById",
                table: "PollingStations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_ElectionId",
                table: "PollingStations",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_LastChangedById",
                table: "PollingStations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_PollingCenterId",
                table: "PollingStations",
                column: "PollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStations_PollingStationTypeId",
                table: "PollingStations",
                column: "PollingStationTypeId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Voters_CreatedById",
                table: "Voters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_DeletedById",
                table: "Voters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_ElectionId",
                table: "Voters",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_GenderId",
                table: "Voters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_LastChangedById",
                table: "Voters",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_MunicipalityId",
                table: "Voters",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_PollingCenterId",
                table: "Voters",
                column: "PollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Voters_PollingStationId",
                table: "Voters",
                column: "PollingStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CandidatePoliticalPartyPersons_CandidatePoliticalPartyPersonId",
                table: "Documents",
                column: "CandidatePoliticalPartyPersonId",
                principalTable: "CandidatePoliticalPartyPersons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "Documents",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_DataResultMatchings_DataResultsMatchingId",
                table: "Documents",
                column: "DataResultsMatchingId",
                principalTable: "DataResultMatchings",
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
                name: "FK_Documents_ObserverOrganizationPersons_ObserverOrganizationPersonId",
                table: "Documents",
                column: "ObserverOrganizationPersonId",
                principalTable: "ObserverOrganizationPersons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ObserverOrganizations_ObserverOrganizationId",
                table: "Documents",
                column: "ObserverOrganizationId",
                principalTable: "ObserverOrganizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ObserversApplications_ObserversApplicationId",
                table: "Documents",
                column: "ObserversApplicationId",
                principalTable: "ObserversApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalParties_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalPartyPersons_PoliticalPartyPersonId",
                table: "Documents",
                column: "PoliticalPartyPersonId",
                principalTable: "PoliticalPartyPersons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalPartySignatures_PoliticalPartySignatureId",
                table: "Documents",
                column: "PoliticalPartySignatureId",
                principalTable: "PoliticalPartySignatures",
                principalColumn: "Id");
        }
    }
}
