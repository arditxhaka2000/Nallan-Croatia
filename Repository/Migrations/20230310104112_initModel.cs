using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class initModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "55660013-d101-427f-a62a-f6568b936af1", "9e0568ef-f131-4044-9bd9-8d49d186d278" });

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55660013-d101-427f-a62a-f6568b936af1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0568ef-f131-4044-9bd9-8d49d186d278");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentDownloadableId",
                table: "DocumentTranslations",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "PollingStationChangeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DocumentDownloadable",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_DocumentDownloadable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDownloadable_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadable_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadable_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadable_Lists_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElectionTypeId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_Elections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Elections_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Elections_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Elections_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Elections_Lists_ElectionTypeId",
                        column: x => x.ElectionTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PolygonCoordiates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPolingCenterNr = table.Column<int>(type: "int", nullable: false),
                    TotalPolingStationsNr = table.Column<int>(type: "int", nullable: false),
                    TotalVotersNr = table.Column<int>(type: "int", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipalities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Municipalities_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Municipalities_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentDownloadableTranslation",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    DocumentDownloadableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDownloadableTranslation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDownloadableTranslation_DocumentDownloadable_DocumentDownloadableId",
                        column: x => x.DocumentDownloadableId,
                        principalTable: "DocumentDownloadable",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadableTranslation_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadableTranslation_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ElectionTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_ElectionTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectionTranslations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionTranslations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionTranslations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionTranslations_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    MunicipalityResidenceId = table.Column<int>(type: "int", nullable: true),
                    ResidenceAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclareEnticity = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    WorkingPositionId = table.Column<int>(type: "int", nullable: true),
                    LocationUnitId = table.Column<int>(type: "int", nullable: true),
                    HasCourtCertificate = table.Column<bool>(type: "bit", nullable: false),
                    BankHolderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BankNameId = table.Column<int>(type: "int", nullable: true),
                    HighestEducationLevelId = table.Column<int>(type: "int", nullable: true),
                    EmployeeSkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Lists_BankNameId",
                        column: x => x.BankNameId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Lists_HighestEducationLevelId",
                        column: x => x.HighestEducationLevelId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Lists_LocationUnitId",
                        column: x => x.LocationUnitId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Lists_WorkingPositionId",
                        column: x => x.WorkingPositionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_Municipalities_MunicipalityResidenceId",
                        column: x => x.MunicipalityResidenceId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MunicipalityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shortname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_MunicipalityTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MunicipalityTranslations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityTranslations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityTranslations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MunicipalityTranslations_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalParty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_PoliticalParty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalParty_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParty_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParty_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParty_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalParty_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollingCenters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActualNrOfPollingStations = table.Column<int>(type: "int", nullable: false),
                    MaxNrOfPollingStations = table.Column<int>(type: "int", nullable: false),
                    ActualNrOfVoters = table.Column<int>(type: "int", nullable: false),
                    MaxNrOfVoters = table.Column<int>(type: "int", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                name: "EmployeeEduactionTraining",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EducationTraningId = table.Column<int>(type: "int", nullable: true),
                    InstitucionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitucionLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AcademicTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FieldOfStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeEduactionTraining", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTraining_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTraining_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTraining_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTraining_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeEduactionTraining_Lists_EducationTraningId",
                        column: x => x.EducationTraningId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSkill",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WordId = table.Column<int>(type: "int", nullable: true),
                    ExcelId = table.Column<int>(type: "int", nullable: true),
                    DatabaseDevelopmentId = table.Column<int>(type: "int", nullable: true),
                    AccessId = table.Column<int>(type: "int", nullable: true),
                    OtherSoftProgram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherSkills = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeSkill", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Lists_AccessId",
                        column: x => x.AccessId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Lists_DatabaseDevelopmentId",
                        column: x => x.DatabaseDevelopmentId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Lists_ExcelId",
                        column: x => x.ExcelId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeSkill_Lists_WordId",
                        column: x => x.WordId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeWorkExperience",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SupervisorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupervisedEmployeeNr = table.Column<int>(type: "int", nullable: false),
                    SupervisedEmployeeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeavingReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_EmployeeWorkExperience", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperience_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperience_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperience_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EmployeeWorkExperience_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticParty",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateNr = table.Column<int>(type: "int", nullable: false),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    TypePoliticalPartyId = table.Column<int>(type: "int", nullable: true),
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementGivenPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementGivenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StatementCourtesyPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatementCourtesyDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_CandidatePoliticParty", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParty_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParty_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParty_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParty_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParty_Lists_TypePoliticalPartyId",
                        column: x => x.TypePoliticalPartyId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticParty_PoliticalParty_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartyControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlNameId = table.Column<int>(type: "int", nullable: true),
                    PoliticalPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoliticalPartyControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalPartyControl_Lists_ControlNameId",
                        column: x => x.ControlNameId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyControl_PoliticalParty_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PoliticalPartyPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PoliticalPartyPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPerson_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPerson_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPerson_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPerson_Lists_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPerson_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PoliticalPartyPerson_PoliticalParty_PoliticalPartyId",
                        column: x => x.PoliticalPartyId,
                        principalTable: "PoliticalParty",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollingStationChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestedPollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MAEComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefusalReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_PollingStationChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_PollingCenters_CurrentPollingCenterId",
                        column: x => x.CurrentPollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_PollingCenters_RequestedPollingCenterId",
                        column: x => x.RequestedPollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PollingStations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PollingStationTypeId = table.Column<int>(type: "int", nullable: true),
                    TotalNrOfVoters = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
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
                name: "CandidatePoliticalPartyPerson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastame = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PersonTypeId = table.Column<int>(type: "int", nullable: true),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CandidatePoliticalPartyPerson", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPerson_CandidatePoliticParty_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPerson_Lists_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticalPartyPerson_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticPartyCommunity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_CandidatePoliticPartyCommunity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunity_CandidatePoliticParty_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyCommunity_Lists_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CandidatePoliticPartyControl",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ControlNameId = table.Column<int>(type: "int", nullable: true),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_CandidatePoliticPartyControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControl_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControl_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControl_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControl_CandidatePoliticParty_CandidatePoliticPartyId",
                        column: x => x.CandidatePoliticPartyId,
                        principalTable: "CandidatePoliticParty",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidatePoliticPartyControl_Lists_ControlNameId",
                        column: x => x.ControlNameId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTranslations_DocumentDownloadableId",
                table: "DocumentTranslations",
                column: "DocumentDownloadableId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CandidatePoliticalPartyPersonId",
                table: "Documents",
                column: "CandidatePoliticalPartyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CandidatePoliticPartyId",
                table: "Documents",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyPersonId",
                table: "Documents",
                column: "PoliticalPartyPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PollingStationChangeId",
                table: "Documents",
                column: "PollingStationChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPerson_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPerson",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPerson_CreatedById",
                table: "CandidatePoliticalPartyPerson",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPerson_DeletedById",
                table: "CandidatePoliticalPartyPerson",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPerson_LastChangedById",
                table: "CandidatePoliticalPartyPerson",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPerson_MunicipalityId",
                table: "CandidatePoliticalPartyPerson",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticalPartyPerson_PersonTypeId",
                table: "CandidatePoliticalPartyPerson",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParty_CreatedById",
                table: "CandidatePoliticParty",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParty_DeletedById",
                table: "CandidatePoliticParty",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParty_ElectionId",
                table: "CandidatePoliticParty",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParty_LastChangedById",
                table: "CandidatePoliticParty",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParty_PoliticalPartyId",
                table: "CandidatePoliticParty",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticParty_TypePoliticalPartyId",
                table: "CandidatePoliticParty",
                column: "TypePoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunity_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunity",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunity_CommunityId",
                table: "CandidatePoliticPartyCommunity",
                column: "CommunityId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunity_CreatedById",
                table: "CandidatePoliticPartyCommunity",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunity_DeletedById",
                table: "CandidatePoliticPartyCommunity",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyCommunity_LastChangedById",
                table: "CandidatePoliticPartyCommunity",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControl_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControl",
                column: "CandidatePoliticPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControl_ControlNameId",
                table: "CandidatePoliticPartyControl",
                column: "ControlNameId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControl_CreatedById",
                table: "CandidatePoliticPartyControl",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControl_DeletedById",
                table: "CandidatePoliticPartyControl",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_CandidatePoliticPartyControl_LastChangedById",
                table: "CandidatePoliticPartyControl",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadable_CreatedById",
                table: "DocumentDownloadable",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadable_DeletedById",
                table: "DocumentDownloadable",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadable_DocumentTypeId",
                table: "DocumentDownloadable",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadable_LastChangedById",
                table: "DocumentDownloadable",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadableTranslation_DocumentDownloadableId",
                table: "DocumentDownloadableTranslation",
                column: "DocumentDownloadableId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadableTranslation_DocumentId",
                table: "DocumentDownloadableTranslation",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadableTranslation_LanguageId",
                table: "DocumentDownloadableTranslation",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_CreatedById",
                table: "Elections",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_DeletedById",
                table: "Elections",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_ElectionTypeId",
                table: "Elections",
                column: "ElectionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Elections_LastChangedById",
                table: "Elections",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionTranslations_CreatedById",
                table: "ElectionTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionTranslations_DeletedById",
                table: "ElectionTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionTranslations_ElectionId",
                table: "ElectionTranslations",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionTranslations_LanguageId",
                table: "ElectionTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionTranslations_LastChangedById",
                table: "ElectionTranslations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_BankNameId",
                table: "Employee",
                column: "BankNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CreatedById",
                table: "Employee",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DeletedById",
                table: "Employee",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ElectionId",
                table: "Employee",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GenderId",
                table: "Employee",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_HighestEducationLevelId",
                table: "Employee",
                column: "HighestEducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LastChangedById",
                table: "Employee",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_LocationUnitId",
                table: "Employee",
                column: "LocationUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_MunicipalityResidenceId",
                table: "Employee",
                column: "MunicipalityResidenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_WorkingPositionId",
                table: "Employee",
                column: "WorkingPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTraining_CreatedById",
                table: "EmployeeEduactionTraining",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTraining_DeletedById",
                table: "EmployeeEduactionTraining",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTraining_EducationTraningId",
                table: "EmployeeEduactionTraining",
                column: "EducationTraningId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTraining_EmployeeId",
                table: "EmployeeEduactionTraining",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeEduactionTraining_LastChangedById",
                table: "EmployeeEduactionTraining",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_AccessId",
                table: "EmployeeSkill",
                column: "AccessId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_CreatedById",
                table: "EmployeeSkill",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_DatabaseDevelopmentId",
                table: "EmployeeSkill",
                column: "DatabaseDevelopmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_DeletedById",
                table: "EmployeeSkill",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_ExcelId",
                table: "EmployeeSkill",
                column: "ExcelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_LastChangedById",
                table: "EmployeeSkill",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSkill_WordId",
                table: "EmployeeSkill",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperience_CreatedById",
                table: "EmployeeWorkExperience",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperience_DeletedById",
                table: "EmployeeWorkExperience",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperience_EmployeeId",
                table: "EmployeeWorkExperience",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkExperience_LastChangedById",
                table: "EmployeeWorkExperience",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_CreatedById",
                table: "Municipalities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_DeletedById",
                table: "Municipalities",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Municipalities_LastChangedById",
                table: "Municipalities",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityTranslations_CreatedById",
                table: "MunicipalityTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityTranslations_DeletedById",
                table: "MunicipalityTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityTranslations_LanguageId",
                table: "MunicipalityTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityTranslations_LastChangedById",
                table: "MunicipalityTranslations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_MunicipalityTranslations_MunicipalityId",
                table: "MunicipalityTranslations",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_CreatedById",
                table: "PoliticalParty",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_DeletedById",
                table: "PoliticalParty",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_ElectionId",
                table: "PoliticalParty",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_LastChangedById",
                table: "PoliticalParty",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalParty_MunicipalityId",
                table: "PoliticalParty",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyControl_ControlNameId",
                table: "PoliticalPartyControl",
                column: "ControlNameId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyControl_PoliticalPartyId",
                table: "PoliticalPartyControl",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPerson_CreatedById",
                table: "PoliticalPartyPerson",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPerson_DeletedById",
                table: "PoliticalPartyPerson",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPerson_LastChangedById",
                table: "PoliticalPartyPerson",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPerson_MunicipalityId",
                table: "PoliticalPartyPerson",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPerson_PersonTypeId",
                table: "PoliticalPartyPerson",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliticalPartyPerson_PoliticalPartyId",
                table: "PoliticalPartyPerson",
                column: "PoliticalPartyId");

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
                name: "IX_PollingStationChanges_CreatedById",
                table: "PollingStationChanges",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_CurrentPollingCenterId",
                table: "PollingStationChanges",
                column: "CurrentPollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_DecisionId",
                table: "PollingStationChanges",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_DeletedById",
                table: "PollingStationChanges",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_ElectionId",
                table: "PollingStationChanges",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_GenderId",
                table: "PollingStationChanges",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_LastChangedById",
                table: "PollingStationChanges",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_MunicipalityId",
                table: "PollingStationChanges",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_RequestedPollingCenterId",
                table: "PollingStationChanges",
                column: "RequestedPollingCenterId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CandidatePoliticalPartyPerson_CandidatePoliticalPartyPersonId",
                table: "Documents",
                column: "CandidatePoliticalPartyPersonId",
                principalTable: "CandidatePoliticalPartyPerson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "Documents",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalParty_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalPartyPerson_PoliticalPartyPersonId",
                table: "Documents",
                column: "PoliticalPartyPersonId",
                principalTable: "PoliticalPartyPerson",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PollingStationChanges_PollingStationChangeId",
                table: "Documents",
                column: "PollingStationChangeId",
                principalTable: "PollingStationChanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTranslations_DocumentDownloadable_DocumentDownloadableId",
                table: "DocumentTranslations",
                column: "DocumentDownloadableId",
                principalTable: "DocumentDownloadable",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CandidatePoliticalPartyPerson_CandidatePoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalParty_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalPartyPerson_PoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PollingStationChanges_PollingStationChangeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTranslations_DocumentDownloadable_DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartyPerson");

            migrationBuilder.DropTable(
                name: "CandidatePoliticPartyCommunity");

            migrationBuilder.DropTable(
                name: "CandidatePoliticPartyControl");

            migrationBuilder.DropTable(
                name: "DocumentDownloadableTranslation");

            migrationBuilder.DropTable(
                name: "ElectionTranslations");

            migrationBuilder.DropTable(
                name: "EmployeeEduactionTraining");

            migrationBuilder.DropTable(
                name: "EmployeeSkill");

            migrationBuilder.DropTable(
                name: "EmployeeWorkExperience");

            migrationBuilder.DropTable(
                name: "MunicipalityTranslations");

            migrationBuilder.DropTable(
                name: "PoliticalPartyControl");

            migrationBuilder.DropTable(
                name: "PoliticalPartyPerson");

            migrationBuilder.DropTable(
                name: "PollingStationChanges");

            migrationBuilder.DropTable(
                name: "PollingStations");

            migrationBuilder.DropTable(
                name: "CandidatePoliticParty");

            migrationBuilder.DropTable(
                name: "DocumentDownloadable");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "PollingCenters");

            migrationBuilder.DropTable(
                name: "PoliticalParty");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTranslations_DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CandidatePoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_CandidatePoliticPartyId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PollingStationChangeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropColumn(
                name: "CandidatePoliticPartyId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "CandidatePoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PollingStationChangeId",
                table: "Documents");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55660013-d101-427f-a62a-f6568b936af1", "a8299554-43f8-43b5-9552-2f9dfcf04fed", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLanguageId", "Discriminator", "Email", "EmailConfirmed", "FirstName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "active" },
                values: new object[] { "9e0568ef-f131-4044-9bd9-8d49d186d278", 0, "0d7ecc6c-d613-453f-9f82-823a9f57f830", null, "AppUser", "admin@admin.com", true, "Admin", null, "ADMIN", false, null, "admin@admin.COM", "admin@admin.com", "AQAAAAEAACcQAAAAEOm99Eqgq2AD087offzJX1reNA51HpNKo4EAQTFg57/1DfVKINwfChEkW2OLXJlzsA==", "+111111111111", true, "c9177580-f98c-42b7-b9ab-51c9d838a225", false, "admin@admin.COM", true });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Active", "Code", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "IsDeleted", "LastChangedById", "LastChangedDate", "Name" },
                values: new object[,]
                {
                    { 1, false, "sq", null, new DateTime(2023, 3, 1, 15, 8, 3, 896, DateTimeKind.Local).AddTicks(1544), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albania" },
                    { 2, false, "en", null, new DateTime(2023, 3, 1, 15, 8, 3, 896, DateTimeKind.Local).AddTicks(1591), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "English" },
                    { 3, false, "sr", null, new DateTime(2023, 3, 1, 15, 8, 3, 896, DateTimeKind.Local).AddTicks(1593), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serbian" },
                    { 4, false, "tr", null, new DateTime(2023, 3, 1, 15, 8, 3, 896, DateTimeKind.Local).AddTicks(1596), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkish" },
                    { 5, false, "bs", null, new DateTime(2023, 3, 1, 15, 8, 3, 896, DateTimeKind.Local).AddTicks(1598), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bosnian" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "55660013-d101-427f-a62a-f6568b936af1", "9e0568ef-f131-4044-9bd9-8d49d186d278" });
        }
    }
}
