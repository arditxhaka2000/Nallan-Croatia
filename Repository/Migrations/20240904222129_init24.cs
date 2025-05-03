using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class init24 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Municipalities_MunicipalityId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVotersId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_ConditionalVoters_ConditionalVoterId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Lists_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalParties_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PollingCenterChanges_PollingCenterChangeId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_SpecialNeedsVoters_SpecialNeedsVotersId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTranslations_DocumentDownloadables_DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropTable(
                name: "AbroadVoter4Municipalities");

            migrationBuilder.DropTable(
                name: "AbroadVoterRefuseReasons");

            migrationBuilder.DropTable(
                name: "AbroadVoterUserAssignees");

            migrationBuilder.DropTable(
                name: "ConditionalBallotEnvelopes");

            migrationBuilder.DropTable(
                name: "ConditionalVoters");

            migrationBuilder.DropTable(
                name: "DocumentDownloadableTranslations");

            migrationBuilder.DropTable(
                name: "ElectionMunicipalities");

            migrationBuilder.DropTable(
                name: "ElectionTranslations");

            migrationBuilder.DropTable(
                name: "ListTranslations");

            migrationBuilder.DropTable(
                name: "MunicipalityConfigOppositeGenders");

            migrationBuilder.DropTable(
                name: "MunicipalityTranslations");

            migrationBuilder.DropTable(
                name: "PoliticalPartyPersons");

            migrationBuilder.DropTable(
                name: "ReportsRoles");

            migrationBuilder.DropTable(
                name: "UserMunicipalities");

            migrationBuilder.DropTable(
                name: "ServiceConfigurations");

            migrationBuilder.DropTable(
                name: "PollingCenterChanges");

            migrationBuilder.DropTable(
                name: "SpecialNeedsVoters");

            migrationBuilder.DropTable(
                name: "AbroadVoters");

            migrationBuilder.DropTable(
                name: "DocumentDownloadables");

            migrationBuilder.DropTable(
                name: "PoliticalParties");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "Embassies");

            migrationBuilder.DropTable(
                name: "Elections");

            migrationBuilder.DropTable(
                name: "Municipalities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "ListTypes");

            migrationBuilder.DropIndex(
                name: "IX_DocumentTranslations_DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropIndex(
                name: "IX_Documents_AbroadVotersId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_ConditionalVoterId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_PollingCenterChangeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_SpecialNeedsVotersId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MunicipalityId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropColumn(
                name: "AbroadVotersId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "ConditionalVoterId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "IsRefusedByAbroadVoters",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "IsRefusedByPoliticalParty",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "PollingCenterChangeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "SpecialNeedsVotersId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "HasChangeGeneratedPassword",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MunicipalityId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DocumentDownloadableId",
                table: "DocumentTranslations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AbroadVotersId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ConditionalVoterId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefusedByAbroadVoters",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRefusedByPoliticalParty",
                table: "Documents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "PoliticalPartyId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PollingCenterChangeId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SpecialNeedsVotersId",
                table: "Documents",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasChangeGeneratedPassword",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MunicipalityId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ConditionalBallotEnvelopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionalBallotEnvelopes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionalBallotEnvelopes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConditionalBallotEnvelopes_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConditionalBallotEnvelopes_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ConditionalVoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CBECode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExistInLPV = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionalVoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConditionalVoters_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConditionalVoters_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ConditionalVoters_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prefix = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Countries_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListTypes_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListTypes_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListTypes_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Municipalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OpositeGenderpercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    PolygonCoordiates = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalPolingCenterNr = table.Column<int>(type: "int", nullable: false),
                    TotalPolingStationsNr = table.Column<int>(type: "int", nullable: false),
                    TotalVotersNr = table.Column<int>(type: "int", nullable: false)
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
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NameForShow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameProcedure = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ServiceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceConfigurations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceConfigurations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceConfigurations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ListTypeChildId = table.Column<int>(type: "int", nullable: true),
                    ListTypeId = table.Column<int>(type: "int", nullable: true),
                    CentralListId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lists_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lists_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lists_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lists_ListTypes_ListTypeChildId",
                        column: x => x.ListTypeChildId,
                        principalTable: "ListTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Lists_ListTypes_ListTypeId",
                        column: x => x.ListTypeId,
                        principalTable: "ListTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MunicipalityTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shortname = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "UserMunicipalities",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserMunicipalities", x => new { x.UserId, x.MunicipalityId });
                    table.ForeignKey(
                        name: "FK_UserMunicipalities_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserMunicipalities_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportsRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportsRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportsRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportsRoles_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportsRoles_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportsRoles_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ReportsRoles_Reports_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Reports",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbroadVoter4Municipalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    ServiceConfigurationId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbroadVoter4Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_ServiceConfigurations_ServiceConfigurationId",
                        column: x => x.ServiceConfigurationId,
                        principalTable: "ServiceConfigurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Elections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionTypeId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Election4Assembly = table.Column<bool>(type: "bit", nullable: false),
                    Election4President = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "Embassies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DiplomaticRelationTypeId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaxNrOfVoters = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embassies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Embassies_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Embassies_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Embassies_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Embassies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Embassies_Lists_DiplomaticRelationTypeId",
                        column: x => x.DiplomaticRelationTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ListTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ListId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameTransitive = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListTranslations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListTranslations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListTranslations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ListTranslations_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
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
                    Acronym = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentDiscussion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DecissionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    ElectionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDiscussion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromDiscussion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDiscussion = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OfficialName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoliticalPartyTypeId = table.Column<int>(type: "int", nullable: true),
                    PoliticalPartyTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToDiscussion = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "PollingCenterChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentPollingCenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPollingCenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPollingCenterName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    GenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefusalReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedPollingCenterCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedPollingCenterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestedPollingCenterName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollingCenterChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DocumentDownloadables",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DocumentTypeId = table.Column<int>(type: "int", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InformationText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderIndex = table.Column<int>(type: "int", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDownloadables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDownloadables_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadables_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadables_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadables_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadables_Lists_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ElectionMunicipalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsSelected = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectionMunicipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectionMunicipalities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionMunicipalities_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionMunicipalities_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionMunicipalities_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ElectionMunicipalities_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ElectionTranslations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "MunicipalityConfigOppositeGenders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    CandidateNrOfList = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OppositeGenderPercentage = table.Column<int>(type: "int", nullable: true),
                    ParlamentaryElection = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "SpecialNeedsVoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    InstitucionId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstitutionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAEComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefusalReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialNeedsVoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_Lists_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_Lists_InstitucionId",
                        column: x => x.InstitucionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_Lists_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SpecialNeedsVoters_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbroadVoters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbroadVoterTypeId = table.Column<int>(type: "int", nullable: true),
                    AssigneeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    EmbassyId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    AboardCity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboardCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAbroadKosovoPostalBoox = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsDiplomaticRepresented = table.Column<bool>(type: "bit", nullable: false),
                    IsKosovoPostalBoox = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAEComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbroadVoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoters_AspNetUsers_AssigneeId",
                        column: x => x.AssigneeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                        name: "FK_AbroadVoters_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_Embassies_EmbassyId",
                        column: x => x.EmbassyId,
                        principalTable: "Embassies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoters_Lists_AbroadVoterTypeId",
                        column: x => x.AbroadVoterTypeId,
                        principalTable: "Lists",
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
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "DocumentDownloadableTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentDownloadableId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentDownloadableTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentDownloadableTranslations_DocumentDownloadables_DocumentDownloadableId",
                        column: x => x.DocumentDownloadableId,
                        principalTable: "DocumentDownloadables",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadableTranslations_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DocumentDownloadableTranslations_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbroadVoterRefuseReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbroadVoterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PollingCenterChangeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RefuseReasonId = table.Column<int>(type: "int", nullable: true),
                    SpecialNeedsVotersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbroadVoterRefuseReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AbroadVoters_AbroadVoterId",
                        column: x => x.AbroadVoterId,
                        principalTable: "AbroadVoters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_Lists_RefuseReasonId",
                        column: x => x.RefuseReasonId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_PollingCenterChanges_PollingCenterChangeId",
                        column: x => x.PollingCenterChangeId,
                        principalTable: "PollingCenterChanges",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_SpecialNeedsVoters_SpecialNeedsVotersId",
                        column: x => x.SpecialNeedsVotersId,
                        principalTable: "SpecialNeedsVoters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AbroadVoterUserAssignees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbroadVoterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Assignee2Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AssigneeFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbroadVoterUserAssignees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AbroadVoters_AbroadVoterId",
                        column: x => x.AbroadVoterId,
                        principalTable: "AbroadVoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTranslations_DocumentDownloadableId",
                table: "DocumentTranslations",
                column: "DocumentDownloadableId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AbroadVotersId",
                table: "Documents",
                column: "AbroadVotersId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ConditionalVoterId",
                table: "Documents",
                column: "ConditionalVoterId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PollingCenterChangeId",
                table: "Documents",
                column: "PollingCenterChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_SpecialNeedsVotersId",
                table: "Documents",
                column: "SpecialNeedsVotersId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MunicipalityId",
                table: "AspNetUsers",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_CreatedById",
                table: "AbroadVoter4Municipalities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_DeletedById",
                table: "AbroadVoter4Municipalities",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_LastChangedById",
                table: "AbroadVoter4Municipalities",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_MunicipalityId",
                table: "AbroadVoter4Municipalities",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_ServiceConfigurationId",
                table: "AbroadVoter4Municipalities",
                column: "ServiceConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_AbroadVoterId",
                table: "AbroadVoterRefuseReasons",
                column: "AbroadVoterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_CreatedById",
                table: "AbroadVoterRefuseReasons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_DeletedById",
                table: "AbroadVoterRefuseReasons",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_LastChangedById",
                table: "AbroadVoterRefuseReasons",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_PollingCenterChangeId",
                table: "AbroadVoterRefuseReasons",
                column: "PollingCenterChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_RefuseReasonId",
                table: "AbroadVoterRefuseReasons",
                column: "RefuseReasonId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_SpecialNeedsVotersId",
                table: "AbroadVoterRefuseReasons",
                column: "SpecialNeedsVotersId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_AbroadVoterTypeId",
                table: "AbroadVoters",
                column: "AbroadVoterTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_AssigneeId",
                table: "AbroadVoters",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_CountryId",
                table: "AbroadVoters",
                column: "CountryId");

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
                name: "IX_AbroadVoters_EmbassyId",
                table: "AbroadVoters",
                column: "EmbassyId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_AbroadVoterId",
                table: "AbroadVoterUserAssignees",
                column: "AbroadVoterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_CreatedById",
                table: "AbroadVoterUserAssignees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_DeletedById",
                table: "AbroadVoterUserAssignees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_LastChangedById",
                table: "AbroadVoterUserAssignees",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_UserId",
                table: "AbroadVoterUserAssignees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionalBallotEnvelopes_CreatedById",
                table: "ConditionalBallotEnvelopes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionalBallotEnvelopes_DeletedById",
                table: "ConditionalBallotEnvelopes",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionalBallotEnvelopes_LastChangedById",
                table: "ConditionalBallotEnvelopes",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionalVoters_CreatedById",
                table: "ConditionalVoters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionalVoters_DeletedById",
                table: "ConditionalVoters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ConditionalVoters_LastChangedById",
                table: "ConditionalVoters",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_CreatedById",
                table: "Countries",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_DeletedById",
                table: "Countries",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_LastChangedById",
                table: "Countries",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadables_CreatedById",
                table: "DocumentDownloadables",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadables_DeletedById",
                table: "DocumentDownloadables",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadables_DocumentTypeId",
                table: "DocumentDownloadables",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadables_ElectionId",
                table: "DocumentDownloadables",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadables_LastChangedById",
                table: "DocumentDownloadables",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadableTranslations_DocumentDownloadableId",
                table: "DocumentDownloadableTranslations",
                column: "DocumentDownloadableId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadableTranslations_DocumentId",
                table: "DocumentDownloadableTranslations",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentDownloadableTranslations_LanguageId",
                table: "DocumentDownloadableTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionMunicipalities_CreatedById",
                table: "ElectionMunicipalities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionMunicipalities_DeletedById",
                table: "ElectionMunicipalities",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionMunicipalities_ElectionId",
                table: "ElectionMunicipalities",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionMunicipalities_LastChangedById",
                table: "ElectionMunicipalities",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ElectionMunicipalities_MunicipalityId",
                table: "ElectionMunicipalities",
                column: "MunicipalityId");

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
                name: "IX_Embassies_CountryId",
                table: "Embassies",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_CreatedById",
                table: "Embassies",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_DeletedById",
                table: "Embassies",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_DiplomaticRelationTypeId",
                table: "Embassies",
                column: "DiplomaticRelationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_LastChangedById",
                table: "Embassies",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_CreatedById",
                table: "Lists",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_DeletedById",
                table: "Lists",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_LastChangedById",
                table: "Lists",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_ListTypeChildId",
                table: "Lists",
                column: "ListTypeChildId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_ListTypeId",
                table: "Lists",
                column: "ListTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ListTranslations_CreatedById",
                table: "ListTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ListTranslations_DeletedById",
                table: "ListTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ListTranslations_LanguageId",
                table: "ListTranslations",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ListTranslations_LastChangedById",
                table: "ListTranslations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ListTranslations_ListId",
                table: "ListTranslations",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListTypes_CreatedById",
                table: "ListTypes",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ListTypes_DeletedById",
                table: "ListTypes",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ListTypes_LastChangedById",
                table: "ListTypes",
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
                name: "IX_PollingCenterChanges_CreatedById",
                table: "PollingCenterChanges",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_DecisionId",
                table: "PollingCenterChanges",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_DeletedById",
                table: "PollingCenterChanges",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_LastChangedById",
                table: "PollingCenterChanges",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_MunicipalityId",
                table: "PollingCenterChanges",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CreatedById",
                table: "Reports",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_DeletedById",
                table: "Reports",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_LastChangedById",
                table: "Reports",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsRoles_CreatedById",
                table: "ReportsRoles",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsRoles_DeletedById",
                table: "ReportsRoles",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsRoles_LastChangedById",
                table: "ReportsRoles",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsRoles_ReportId",
                table: "ReportsRoles",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportsRoles_RoleId",
                table: "ReportsRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfigurations_CreatedById",
                table: "ServiceConfigurations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfigurations_DeletedById",
                table: "ServiceConfigurations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceConfigurations_LastChangedById",
                table: "ServiceConfigurations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_CategoryId",
                table: "SpecialNeedsVoters",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_CreatedById",
                table: "SpecialNeedsVoters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_DecisionId",
                table: "SpecialNeedsVoters",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_DeletedById",
                table: "SpecialNeedsVoters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_ElectionId",
                table: "SpecialNeedsVoters",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_GenderId",
                table: "SpecialNeedsVoters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_InstitucionId",
                table: "SpecialNeedsVoters",
                column: "InstitucionId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_LastChangedById",
                table: "SpecialNeedsVoters",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_MunicipalityId",
                table: "SpecialNeedsVoters",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialNeedsVoters_TypeId",
                table: "SpecialNeedsVoters",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserMunicipalities_MunicipalityId",
                table: "UserMunicipalities",
                column: "MunicipalityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Municipalities_MunicipalityId",
                table: "AspNetUsers",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_AbroadVoters_AbroadVotersId",
                table: "Documents",
                column: "AbroadVotersId",
                principalTable: "AbroadVoters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_ConditionalVoters_ConditionalVoterId",
                table: "Documents",
                column: "ConditionalVoterId",
                principalTable: "ConditionalVoters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Lists_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PoliticalParties_PoliticalPartyId",
                table: "Documents",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PollingCenterChanges_PollingCenterChangeId",
                table: "Documents",
                column: "PollingCenterChangeId",
                principalTable: "PollingCenterChanges",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_SpecialNeedsVoters_SpecialNeedsVotersId",
                table: "Documents",
                column: "SpecialNeedsVotersId",
                principalTable: "SpecialNeedsVoters",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentTranslations_DocumentDownloadables_DocumentDownloadableId",
                table: "DocumentTranslations",
                column: "DocumentDownloadableId",
                principalTable: "DocumentDownloadables",
                principalColumn: "Id");
        }
    }
}
