using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class initModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_CreatedById",
                table: "CandidatePoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_DeletedById",
                table: "CandidatePoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_LastChangedById",
                table: "CandidatePoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_Lists_PersonTypeId",
                table: "CandidatePoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_Municipalities_MunicipalityId",
                table: "CandidatePoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParty_AspNetUsers_CreatedById",
                table: "CandidatePoliticParty");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParty_AspNetUsers_DeletedById",
                table: "CandidatePoliticParty");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParty_AspNetUsers_LastChangedById",
                table: "CandidatePoliticParty");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParty_Elections_ElectionId",
                table: "CandidatePoliticParty");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParty_Lists_TypePoliticalPartyId",
                table: "CandidatePoliticParty");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParty_PoliticalParty_PoliticalPartyId",
                table: "CandidatePoliticParty");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyCommunity");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyCommunity");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyCommunity");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunity");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_Lists_CommunityId",
                table: "CandidatePoliticPartyCommunity");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControl_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyControl");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControl_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyControl");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControl_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyControl");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControl_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControl");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControl_Lists_ControlNameId",
                table: "CandidatePoliticPartyControl");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadable_AspNetUsers_CreatedById",
                table: "DocumentDownloadable");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadable_AspNetUsers_DeletedById",
                table: "DocumentDownloadable");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadable_AspNetUsers_LastChangedById",
                table: "DocumentDownloadable");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadable_Lists_DocumentTypeId",
                table: "DocumentDownloadable");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadableTranslation_DocumentDownloadable_DocumentDownloadableId",
                table: "DocumentDownloadableTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadableTranslation_Documents_DocumentId",
                table: "DocumentDownloadableTranslation");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadableTranslation_Languages_LanguageId",
                table: "DocumentDownloadableTranslation");

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
                name: "FK_DocumentTranslations_DocumentDownloadable_DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_CreatedById",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_DeletedById",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_LastChangedById",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Elections_ElectionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Lists_BankNameId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Lists_GenderId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Lists_HighestEducationLevelId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Lists_LocationUnitId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Lists_WorkingPositionId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Municipalities_MunicipalityResidenceId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTraining_AspNetUsers_CreatedById",
                table: "EmployeeEduactionTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTraining_AspNetUsers_DeletedById",
                table: "EmployeeEduactionTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTraining_AspNetUsers_LastChangedById",
                table: "EmployeeEduactionTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTraining_Employee_EmployeeId",
                table: "EmployeeEduactionTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTraining_Lists_EducationTraningId",
                table: "EmployeeEduactionTraining");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_AspNetUsers_CreatedById",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_AspNetUsers_DeletedById",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_AspNetUsers_LastChangedById",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeeId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Lists_AccessId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Lists_DatabaseDevelopmentId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Lists_ExcelId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkill_Lists_WordId",
                table: "EmployeeSkill");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperience_AspNetUsers_CreatedById",
                table: "EmployeeWorkExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperience_AspNetUsers_DeletedById",
                table: "EmployeeWorkExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperience_AspNetUsers_LastChangedById",
                table: "EmployeeWorkExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperience_Employee_EmployeeId",
                table: "EmployeeWorkExperience");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParty_AspNetUsers_CreatedById",
                table: "PoliticalParty");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParty_AspNetUsers_DeletedById",
                table: "PoliticalParty");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParty_AspNetUsers_LastChangedById",
                table: "PoliticalParty");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParty_Elections_ElectionId",
                table: "PoliticalParty");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParty_Municipalities_MunicipalityId",
                table: "PoliticalParty");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyControl_Lists_ControlNameId",
                table: "PoliticalPartyControl");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyControl_PoliticalParty_PoliticalPartyId",
                table: "PoliticalPartyControl");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPerson_AspNetUsers_CreatedById",
                table: "PoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPerson_AspNetUsers_DeletedById",
                table: "PoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPerson_AspNetUsers_LastChangedById",
                table: "PoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPerson_Lists_PersonTypeId",
                table: "PoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPerson_Municipalities_MunicipalityId",
                table: "PoliticalPartyPerson");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPerson_PoliticalParty_PoliticalPartyId",
                table: "PoliticalPartyPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticalPartyPerson",
                table: "PoliticalPartyPerson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticalPartyControl",
                table: "PoliticalPartyControl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticalParty",
                table: "PoliticalParty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeWorkExperience",
                table: "EmployeeWorkExperience");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSkill",
                table: "EmployeeSkill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEduactionTraining",
                table: "EmployeeEduactionTraining");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentDownloadableTranslation",
                table: "DocumentDownloadableTranslation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentDownloadable",
                table: "DocumentDownloadable");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticPartyControl",
                table: "CandidatePoliticPartyControl");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticPartyCommunity",
                table: "CandidatePoliticPartyCommunity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticParty",
                table: "CandidatePoliticParty");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticalPartyPerson",
                table: "CandidatePoliticalPartyPerson");

            migrationBuilder.RenameTable(
                name: "PoliticalPartyPerson",
                newName: "PoliticalPartyPersons");

            migrationBuilder.RenameTable(
                name: "PoliticalPartyControl",
                newName: "PoliticalPartyControls");

            migrationBuilder.RenameTable(
                name: "PoliticalParty",
                newName: "PoliticalParties");

            migrationBuilder.RenameTable(
                name: "EmployeeWorkExperience",
                newName: "EmployeeWorkExperiences");

            migrationBuilder.RenameTable(
                name: "EmployeeSkill",
                newName: "EmployeeSkills");

            migrationBuilder.RenameTable(
                name: "EmployeeEduactionTraining",
                newName: "EmployeeEduactionTrainings");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "DocumentDownloadableTranslation",
                newName: "DocumentDownloadableTranslations");

            migrationBuilder.RenameTable(
                name: "DocumentDownloadable",
                newName: "DocumentDownloadables");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticPartyControl",
                newName: "CandidatePoliticPartyControls");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticPartyCommunity",
                newName: "CandidatePoliticPartyCommunities");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticParty",
                newName: "CandidatePoliticParties");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticalPartyPerson",
                newName: "CandidatePoliticalPartyPersons");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPerson_PoliticalPartyId",
                table: "PoliticalPartyPersons",
                newName: "IX_PoliticalPartyPersons_PoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPerson_PersonTypeId",
                table: "PoliticalPartyPersons",
                newName: "IX_PoliticalPartyPersons_PersonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPerson_MunicipalityId",
                table: "PoliticalPartyPersons",
                newName: "IX_PoliticalPartyPersons_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPerson_LastChangedById",
                table: "PoliticalPartyPersons",
                newName: "IX_PoliticalPartyPersons_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPerson_DeletedById",
                table: "PoliticalPartyPersons",
                newName: "IX_PoliticalPartyPersons_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPerson_CreatedById",
                table: "PoliticalPartyPersons",
                newName: "IX_PoliticalPartyPersons_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyControl_PoliticalPartyId",
                table: "PoliticalPartyControls",
                newName: "IX_PoliticalPartyControls_PoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyControl_ControlNameId",
                table: "PoliticalPartyControls",
                newName: "IX_PoliticalPartyControls_ControlNameId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParty_MunicipalityId",
                table: "PoliticalParties",
                newName: "IX_PoliticalParties_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParty_LastChangedById",
                table: "PoliticalParties",
                newName: "IX_PoliticalParties_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParty_ElectionId",
                table: "PoliticalParties",
                newName: "IX_PoliticalParties_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParty_DeletedById",
                table: "PoliticalParties",
                newName: "IX_PoliticalParties_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParty_CreatedById",
                table: "PoliticalParties",
                newName: "IX_PoliticalParties_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperience_LastChangedById",
                table: "EmployeeWorkExperiences",
                newName: "IX_EmployeeWorkExperiences_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperience_EmployeeId",
                table: "EmployeeWorkExperiences",
                newName: "IX_EmployeeWorkExperiences_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperience_DeletedById",
                table: "EmployeeWorkExperiences",
                newName: "IX_EmployeeWorkExperiences_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperience_CreatedById",
                table: "EmployeeWorkExperiences",
                newName: "IX_EmployeeWorkExperiences_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_WordId",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_LastChangedById",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_ExcelId",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_ExcelId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_EmployeeId",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_DeletedById",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_DatabaseDevelopmentId",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_DatabaseDevelopmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_CreatedById",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkill_AccessId",
                table: "EmployeeSkills",
                newName: "IX_EmployeeSkills_AccessId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTraining_LastChangedById",
                table: "EmployeeEduactionTrainings",
                newName: "IX_EmployeeEduactionTrainings_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTraining_EmployeeId",
                table: "EmployeeEduactionTrainings",
                newName: "IX_EmployeeEduactionTrainings_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTraining_EducationTraningId",
                table: "EmployeeEduactionTrainings",
                newName: "IX_EmployeeEduactionTrainings_EducationTraningId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTraining_DeletedById",
                table: "EmployeeEduactionTrainings",
                newName: "IX_EmployeeEduactionTrainings_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTraining_CreatedById",
                table: "EmployeeEduactionTrainings",
                newName: "IX_EmployeeEduactionTrainings_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_WorkingPositionId",
                table: "Employees",
                newName: "IX_Employees_WorkingPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_MunicipalityResidenceId",
                table: "Employees",
                newName: "IX_Employees_MunicipalityResidenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_LocationUnitId",
                table: "Employees",
                newName: "IX_Employees_LocationUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_LastChangedById",
                table: "Employees",
                newName: "IX_Employees_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_HighestEducationLevelId",
                table: "Employees",
                newName: "IX_Employees_HighestEducationLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_GenderId",
                table: "Employees",
                newName: "IX_Employees_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_ElectionId",
                table: "Employees",
                newName: "IX_Employees_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DeletedById",
                table: "Employees",
                newName: "IX_Employees_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CreatedById",
                table: "Employees",
                newName: "IX_Employees_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_BankNameId",
                table: "Employees",
                newName: "IX_Employees_BankNameId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadableTranslation_LanguageId",
                table: "DocumentDownloadableTranslations",
                newName: "IX_DocumentDownloadableTranslations_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadableTranslation_DocumentId",
                table: "DocumentDownloadableTranslations",
                newName: "IX_DocumentDownloadableTranslations_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadableTranslation_DocumentDownloadableId",
                table: "DocumentDownloadableTranslations",
                newName: "IX_DocumentDownloadableTranslations_DocumentDownloadableId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadable_LastChangedById",
                table: "DocumentDownloadables",
                newName: "IX_DocumentDownloadables_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadable_DocumentTypeId",
                table: "DocumentDownloadables",
                newName: "IX_DocumentDownloadables_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadable_DeletedById",
                table: "DocumentDownloadables",
                newName: "IX_DocumentDownloadables_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadable_CreatedById",
                table: "DocumentDownloadables",
                newName: "IX_DocumentDownloadables_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControl_LastChangedById",
                table: "CandidatePoliticPartyControls",
                newName: "IX_CandidatePoliticPartyControls_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControl_DeletedById",
                table: "CandidatePoliticPartyControls",
                newName: "IX_CandidatePoliticPartyControls_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControl_CreatedById",
                table: "CandidatePoliticPartyControls",
                newName: "IX_CandidatePoliticPartyControls_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControl_ControlNameId",
                table: "CandidatePoliticPartyControls",
                newName: "IX_CandidatePoliticPartyControls_ControlNameId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControl_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControls",
                newName: "IX_CandidatePoliticPartyControls_CandidatePoliticPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunity_LastChangedById",
                table: "CandidatePoliticPartyCommunities",
                newName: "IX_CandidatePoliticPartyCommunities_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunity_DeletedById",
                table: "CandidatePoliticPartyCommunities",
                newName: "IX_CandidatePoliticPartyCommunities_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunity_CreatedById",
                table: "CandidatePoliticPartyCommunities",
                newName: "IX_CandidatePoliticPartyCommunities_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunity_CommunityId",
                table: "CandidatePoliticPartyCommunities",
                newName: "IX_CandidatePoliticPartyCommunities_CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunity_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunities",
                newName: "IX_CandidatePoliticPartyCommunities_CandidatePoliticPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParty_TypePoliticalPartyId",
                table: "CandidatePoliticParties",
                newName: "IX_CandidatePoliticParties_TypePoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParty_PoliticalPartyId",
                table: "CandidatePoliticParties",
                newName: "IX_CandidatePoliticParties_PoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParty_LastChangedById",
                table: "CandidatePoliticParties",
                newName: "IX_CandidatePoliticParties_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParty_ElectionId",
                table: "CandidatePoliticParties",
                newName: "IX_CandidatePoliticParties_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParty_DeletedById",
                table: "CandidatePoliticParties",
                newName: "IX_CandidatePoliticParties_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParty_CreatedById",
                table: "CandidatePoliticParties",
                newName: "IX_CandidatePoliticParties_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPerson_PersonTypeId",
                table: "CandidatePoliticalPartyPersons",
                newName: "IX_CandidatePoliticalPartyPersons_PersonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPerson_MunicipalityId",
                table: "CandidatePoliticalPartyPersons",
                newName: "IX_CandidatePoliticalPartyPersons_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPerson_LastChangedById",
                table: "CandidatePoliticalPartyPersons",
                newName: "IX_CandidatePoliticalPartyPersons_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPerson_DeletedById",
                table: "CandidatePoliticalPartyPersons",
                newName: "IX_CandidatePoliticalPartyPersons_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPerson_CreatedById",
                table: "CandidatePoliticalPartyPersons",
                newName: "IX_CandidatePoliticalPartyPersons_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPerson_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPersons",
                newName: "IX_CandidatePoliticalPartyPersons_CandidatePoliticPartyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticalPartyPersons",
                table: "PoliticalPartyPersons",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticalPartyControls",
                table: "PoliticalPartyControls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticalParties",
                table: "PoliticalParties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeWorkExperiences",
                table: "EmployeeWorkExperiences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSkills",
                table: "EmployeeSkills",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEduactionTrainings",
                table: "EmployeeEduactionTrainings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentDownloadableTranslations",
                table: "DocumentDownloadableTranslations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentDownloadables",
                table: "DocumentDownloadables",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticPartyControls",
                table: "CandidatePoliticPartyControls",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticPartyCommunities",
                table: "CandidatePoliticPartyCommunities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticParties",
                table: "CandidatePoliticParties",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticalPartyPersons",
                table: "CandidatePoliticalPartyPersons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CandidateDetailPoliticParties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNr = table.Column<int>(type: "int", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "CandidatePoliticalPartySupports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderNr = table.Column<int>(type: "int", nullable: false),
                    CandidatePoliticPartyId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "EmployeeEvaluates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SupervisorRatingId = table.Column<int>(type: "int", nullable: true),
                    HasViolentPenal = table.Column<bool>(type: "bit", nullable: false),
                    ElectionSentence = table.Column<bool>(type: "bit", nullable: false),
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
                    LanguageId = table.Column<int>(type: "int", nullable: true),
                    WritingId = table.Column<int>(type: "int", nullable: true),
                    ReadingId = table.Column<int>(type: "int", nullable: true),
                    SpeakingId = table.Column<int>(type: "int", nullable: true),
                    UnderstandingId = table.Column<int>(type: "int", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                name: "voters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    PollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PollingStationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PollingStationAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    table.PrimaryKey("PK_voters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_voters_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_voters_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_voters_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_voters_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_voters_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_voters_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_voters_PollingCenters_PollingCenterId",
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
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    FinishedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    EmployeeEvaluateId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "IX_voters_CreatedById",
                table: "voters",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_voters_DeletedById",
                table: "voters",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_voters_ElectionId",
                table: "voters",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_voters_GenderId",
                table: "voters",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_voters_LastChangedById",
                table: "voters",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_voters_MunicipalityId",
                table: "voters",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_voters_PollingCenterId",
                table: "voters",
                column: "PollingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_CreatedById",
                table: "CandidatePoliticalPartyPersons",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_DeletedById",
                table: "CandidatePoliticalPartyPersons",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_LastChangedById",
                table: "CandidatePoliticalPartyPersons",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPersons",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_Lists_PersonTypeId",
                table: "CandidatePoliticalPartyPersons",
                column: "PersonTypeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_Municipalities_MunicipalityId",
                table: "CandidatePoliticalPartyPersons",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_AspNetUsers_CreatedById",
                table: "CandidatePoliticParties",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_AspNetUsers_DeletedById",
                table: "CandidatePoliticParties",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_AspNetUsers_LastChangedById",
                table: "CandidatePoliticParties",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_Elections_ElectionId",
                table: "CandidatePoliticParties",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_Lists_TypePoliticalPartyId",
                table: "CandidatePoliticParties",
                column: "TypePoliticalPartyId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParties_PoliticalParties_PoliticalPartyId",
                table: "CandidatePoliticParties",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyCommunities",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyCommunities",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyCommunities",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunities",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_Lists_CommunityId",
                table: "CandidatePoliticPartyCommunities",
                column: "CommunityId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControls_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyControls",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControls_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyControls",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControls_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyControls",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControls_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControls",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControls_Lists_ControlNameId",
                table: "CandidatePoliticPartyControls",
                column: "ControlNameId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadables_AspNetUsers_CreatedById",
                table: "DocumentDownloadables",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadables_AspNetUsers_DeletedById",
                table: "DocumentDownloadables",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadables_AspNetUsers_LastChangedById",
                table: "DocumentDownloadables",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadables_Lists_DocumentTypeId",
                table: "DocumentDownloadables",
                column: "DocumentTypeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadableTranslations_DocumentDownloadables_DocumentDownloadableId",
                table: "DocumentDownloadableTranslations",
                column: "DocumentDownloadableId",
                principalTable: "DocumentDownloadables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadableTranslations_Documents_DocumentId",
                table: "DocumentDownloadableTranslations",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadableTranslations_Languages_LanguageId",
                table: "DocumentDownloadableTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

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
                name: "FK_DocumentTranslations_DocumentDownloadables_DocumentDownloadableId",
                table: "DocumentTranslations",
                column: "DocumentDownloadableId",
                principalTable: "DocumentDownloadables",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTrainings_AspNetUsers_CreatedById",
                table: "EmployeeEduactionTrainings",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTrainings_AspNetUsers_DeletedById",
                table: "EmployeeEduactionTrainings",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTrainings_AspNetUsers_LastChangedById",
                table: "EmployeeEduactionTrainings",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTrainings_Employees_EmployeeId",
                table: "EmployeeEduactionTrainings",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTrainings_Lists_EducationTraningId",
                table: "EmployeeEduactionTrainings",
                column: "EducationTraningId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_CreatedById",
                table: "Employees",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_DeletedById",
                table: "Employees",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetUsers_LastChangedById",
                table: "Employees",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Elections_ElectionId",
                table: "Employees",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Lists_BankNameId",
                table: "Employees",
                column: "BankNameId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Lists_GenderId",
                table: "Employees",
                column: "GenderId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Lists_HighestEducationLevelId",
                table: "Employees",
                column: "HighestEducationLevelId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Lists_LocationUnitId",
                table: "Employees",
                column: "LocationUnitId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Lists_WorkingPositionId",
                table: "Employees",
                column: "WorkingPositionId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Municipalities_MunicipalityResidenceId",
                table: "Employees",
                column: "MunicipalityResidenceId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_AspNetUsers_CreatedById",
                table: "EmployeeSkills",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_AspNetUsers_DeletedById",
                table: "EmployeeSkills",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_AspNetUsers_LastChangedById",
                table: "EmployeeSkills",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Employees_EmployeeId",
                table: "EmployeeSkills",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Lists_AccessId",
                table: "EmployeeSkills",
                column: "AccessId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Lists_DatabaseDevelopmentId",
                table: "EmployeeSkills",
                column: "DatabaseDevelopmentId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Lists_ExcelId",
                table: "EmployeeSkills",
                column: "ExcelId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkills_Lists_WordId",
                table: "EmployeeSkills",
                column: "WordId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperiences_AspNetUsers_CreatedById",
                table: "EmployeeWorkExperiences",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperiences_AspNetUsers_DeletedById",
                table: "EmployeeWorkExperiences",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperiences_AspNetUsers_LastChangedById",
                table: "EmployeeWorkExperiences",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperiences_Employees_EmployeeId",
                table: "EmployeeWorkExperiences",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_AspNetUsers_CreatedById",
                table: "PoliticalParties",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_AspNetUsers_DeletedById",
                table: "PoliticalParties",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_AspNetUsers_LastChangedById",
                table: "PoliticalParties",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_Elections_ElectionId",
                table: "PoliticalParties",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParties_Municipalities_MunicipalityId",
                table: "PoliticalParties",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyControls_Lists_ControlNameId",
                table: "PoliticalPartyControls",
                column: "ControlNameId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyControls_PoliticalParties_PoliticalPartyId",
                table: "PoliticalPartyControls",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersons_AspNetUsers_CreatedById",
                table: "PoliticalPartyPersons",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersons_AspNetUsers_DeletedById",
                table: "PoliticalPartyPersons",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersons_AspNetUsers_LastChangedById",
                table: "PoliticalPartyPersons",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersons_Lists_PersonTypeId",
                table: "PoliticalPartyPersons",
                column: "PersonTypeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersons_Municipalities_MunicipalityId",
                table: "PoliticalPartyPersons",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPersons_PoliticalParties_PoliticalPartyId",
                table: "PoliticalPartyPersons",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParties",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_CreatedById",
                table: "CandidatePoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_DeletedById",
                table: "CandidatePoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_AspNetUsers_LastChangedById",
                table: "CandidatePoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_Lists_PersonTypeId",
                table: "CandidatePoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticalPartyPersons_Municipalities_MunicipalityId",
                table: "CandidatePoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_AspNetUsers_CreatedById",
                table: "CandidatePoliticParties");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_AspNetUsers_DeletedById",
                table: "CandidatePoliticParties");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_AspNetUsers_LastChangedById",
                table: "CandidatePoliticParties");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_Elections_ElectionId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_Lists_TypePoliticalPartyId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticParties_PoliticalParties_PoliticalPartyId",
                table: "CandidatePoliticParties");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyCommunities_Lists_CommunityId",
                table: "CandidatePoliticPartyCommunities");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControls_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControls_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControls_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControls_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_CandidatePoliticPartyControls_Lists_ControlNameId",
                table: "CandidatePoliticPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadables_AspNetUsers_CreatedById",
                table: "DocumentDownloadables");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadables_AspNetUsers_DeletedById",
                table: "DocumentDownloadables");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadables_AspNetUsers_LastChangedById",
                table: "DocumentDownloadables");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadables_Lists_DocumentTypeId",
                table: "DocumentDownloadables");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadableTranslations_DocumentDownloadables_DocumentDownloadableId",
                table: "DocumentDownloadableTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadableTranslations_Documents_DocumentId",
                table: "DocumentDownloadableTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentDownloadableTranslations_Languages_LanguageId",
                table: "DocumentDownloadableTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CandidatePoliticalPartyPersons_CandidatePoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_CandidatePoliticParties_CandidatePoliticPartyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalParties_PoliticalPartyId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PoliticalPartyPersons_PoliticalPartyPersonId",
                table: "Documents");

            migrationBuilder.DropForeignKey(
                name: "FK_DocumentTranslations_DocumentDownloadables_DocumentDownloadableId",
                table: "DocumentTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTrainings_AspNetUsers_CreatedById",
                table: "EmployeeEduactionTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTrainings_AspNetUsers_DeletedById",
                table: "EmployeeEduactionTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTrainings_AspNetUsers_LastChangedById",
                table: "EmployeeEduactionTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTrainings_Employees_EmployeeId",
                table: "EmployeeEduactionTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeEduactionTrainings_Lists_EducationTraningId",
                table: "EmployeeEduactionTrainings");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_CreatedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_DeletedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetUsers_LastChangedById",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Elections_ElectionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Lists_BankNameId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Lists_GenderId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Lists_HighestEducationLevelId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Lists_LocationUnitId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Lists_WorkingPositionId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Municipalities_MunicipalityResidenceId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_AspNetUsers_CreatedById",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_AspNetUsers_DeletedById",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_AspNetUsers_LastChangedById",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Employees_EmployeeId",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Lists_AccessId",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Lists_DatabaseDevelopmentId",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Lists_ExcelId",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSkills_Lists_WordId",
                table: "EmployeeSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperiences_AspNetUsers_CreatedById",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperiences_AspNetUsers_DeletedById",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperiences_AspNetUsers_LastChangedById",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkExperiences_Employees_EmployeeId",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_AspNetUsers_CreatedById",
                table: "PoliticalParties");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_AspNetUsers_DeletedById",
                table: "PoliticalParties");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_AspNetUsers_LastChangedById",
                table: "PoliticalParties");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_Elections_ElectionId",
                table: "PoliticalParties");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalParties_Municipalities_MunicipalityId",
                table: "PoliticalParties");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyControls_Lists_ControlNameId",
                table: "PoliticalPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyControls_PoliticalParties_PoliticalPartyId",
                table: "PoliticalPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersons_AspNetUsers_CreatedById",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersons_AspNetUsers_DeletedById",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersons_AspNetUsers_LastChangedById",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersons_Lists_PersonTypeId",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersons_Municipalities_MunicipalityId",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyPersons_PoliticalParties_PoliticalPartyId",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropTable(
                name: "CandidateDetailPoliticParties");

            migrationBuilder.DropTable(
                name: "CandidatePoliticalPartySupports");

            migrationBuilder.DropTable(
                name: "EmployeeEvaluationTraining");

            migrationBuilder.DropTable(
                name: "EmployeeLanguageSkills");

            migrationBuilder.DropTable(
                name: "voters");

            migrationBuilder.DropTable(
                name: "EmployeeEvaluates");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticalPartyPersons",
                table: "PoliticalPartyPersons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticalPartyControls",
                table: "PoliticalPartyControls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PoliticalParties",
                table: "PoliticalParties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeWorkExperiences",
                table: "EmployeeWorkExperiences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeSkills",
                table: "EmployeeSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeEduactionTrainings",
                table: "EmployeeEduactionTrainings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentDownloadableTranslations",
                table: "DocumentDownloadableTranslations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DocumentDownloadables",
                table: "DocumentDownloadables");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticPartyControls",
                table: "CandidatePoliticPartyControls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticPartyCommunities",
                table: "CandidatePoliticPartyCommunities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticParties",
                table: "CandidatePoliticParties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CandidatePoliticalPartyPersons",
                table: "CandidatePoliticalPartyPersons");

            migrationBuilder.RenameTable(
                name: "PoliticalPartyPersons",
                newName: "PoliticalPartyPerson");

            migrationBuilder.RenameTable(
                name: "PoliticalPartyControls",
                newName: "PoliticalPartyControl");

            migrationBuilder.RenameTable(
                name: "PoliticalParties",
                newName: "PoliticalParty");

            migrationBuilder.RenameTable(
                name: "EmployeeWorkExperiences",
                newName: "EmployeeWorkExperience");

            migrationBuilder.RenameTable(
                name: "EmployeeSkills",
                newName: "EmployeeSkill");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "EmployeeEduactionTrainings",
                newName: "EmployeeEduactionTraining");

            migrationBuilder.RenameTable(
                name: "DocumentDownloadableTranslations",
                newName: "DocumentDownloadableTranslation");

            migrationBuilder.RenameTable(
                name: "DocumentDownloadables",
                newName: "DocumentDownloadable");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticPartyControls",
                newName: "CandidatePoliticPartyControl");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticPartyCommunities",
                newName: "CandidatePoliticPartyCommunity");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticParties",
                newName: "CandidatePoliticParty");

            migrationBuilder.RenameTable(
                name: "CandidatePoliticalPartyPersons",
                newName: "CandidatePoliticalPartyPerson");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPersons_PoliticalPartyId",
                table: "PoliticalPartyPerson",
                newName: "IX_PoliticalPartyPerson_PoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPersons_PersonTypeId",
                table: "PoliticalPartyPerson",
                newName: "IX_PoliticalPartyPerson_PersonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPersons_MunicipalityId",
                table: "PoliticalPartyPerson",
                newName: "IX_PoliticalPartyPerson_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPersons_LastChangedById",
                table: "PoliticalPartyPerson",
                newName: "IX_PoliticalPartyPerson_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPersons_DeletedById",
                table: "PoliticalPartyPerson",
                newName: "IX_PoliticalPartyPerson_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyPersons_CreatedById",
                table: "PoliticalPartyPerson",
                newName: "IX_PoliticalPartyPerson_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyControls_PoliticalPartyId",
                table: "PoliticalPartyControl",
                newName: "IX_PoliticalPartyControl_PoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalPartyControls_ControlNameId",
                table: "PoliticalPartyControl",
                newName: "IX_PoliticalPartyControl_ControlNameId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParties_MunicipalityId",
                table: "PoliticalParty",
                newName: "IX_PoliticalParty_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParties_LastChangedById",
                table: "PoliticalParty",
                newName: "IX_PoliticalParty_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParties_ElectionId",
                table: "PoliticalParty",
                newName: "IX_PoliticalParty_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParties_DeletedById",
                table: "PoliticalParty",
                newName: "IX_PoliticalParty_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_PoliticalParties_CreatedById",
                table: "PoliticalParty",
                newName: "IX_PoliticalParty_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperiences_LastChangedById",
                table: "EmployeeWorkExperience",
                newName: "IX_EmployeeWorkExperience_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperiences_EmployeeId",
                table: "EmployeeWorkExperience",
                newName: "IX_EmployeeWorkExperience_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperiences_DeletedById",
                table: "EmployeeWorkExperience",
                newName: "IX_EmployeeWorkExperience_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkExperiences_CreatedById",
                table: "EmployeeWorkExperience",
                newName: "IX_EmployeeWorkExperience_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_WordId",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_WordId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_LastChangedById",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_ExcelId",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_ExcelId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_EmployeeId",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_DeletedById",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_DatabaseDevelopmentId",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_DatabaseDevelopmentId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_CreatedById",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeSkills_AccessId",
                table: "EmployeeSkill",
                newName: "IX_EmployeeSkill_AccessId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_WorkingPositionId",
                table: "Employee",
                newName: "IX_Employee_WorkingPositionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_MunicipalityResidenceId",
                table: "Employee",
                newName: "IX_Employee_MunicipalityResidenceId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_LocationUnitId",
                table: "Employee",
                newName: "IX_Employee_LocationUnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_LastChangedById",
                table: "Employee",
                newName: "IX_Employee_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_HighestEducationLevelId",
                table: "Employee",
                newName: "IX_Employee_HighestEducationLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_GenderId",
                table: "Employee",
                newName: "IX_Employee_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ElectionId",
                table: "Employee",
                newName: "IX_Employee_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DeletedById",
                table: "Employee",
                newName: "IX_Employee_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CreatedById",
                table: "Employee",
                newName: "IX_Employee_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_BankNameId",
                table: "Employee",
                newName: "IX_Employee_BankNameId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTrainings_LastChangedById",
                table: "EmployeeEduactionTraining",
                newName: "IX_EmployeeEduactionTraining_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTrainings_EmployeeId",
                table: "EmployeeEduactionTraining",
                newName: "IX_EmployeeEduactionTraining_EmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTrainings_EducationTraningId",
                table: "EmployeeEduactionTraining",
                newName: "IX_EmployeeEduactionTraining_EducationTraningId");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTrainings_DeletedById",
                table: "EmployeeEduactionTraining",
                newName: "IX_EmployeeEduactionTraining_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeEduactionTrainings_CreatedById",
                table: "EmployeeEduactionTraining",
                newName: "IX_EmployeeEduactionTraining_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadableTranslations_LanguageId",
                table: "DocumentDownloadableTranslation",
                newName: "IX_DocumentDownloadableTranslation_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadableTranslations_DocumentId",
                table: "DocumentDownloadableTranslation",
                newName: "IX_DocumentDownloadableTranslation_DocumentId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadableTranslations_DocumentDownloadableId",
                table: "DocumentDownloadableTranslation",
                newName: "IX_DocumentDownloadableTranslation_DocumentDownloadableId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadables_LastChangedById",
                table: "DocumentDownloadable",
                newName: "IX_DocumentDownloadable_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadables_DocumentTypeId",
                table: "DocumentDownloadable",
                newName: "IX_DocumentDownloadable_DocumentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadables_DeletedById",
                table: "DocumentDownloadable",
                newName: "IX_DocumentDownloadable_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_DocumentDownloadables_CreatedById",
                table: "DocumentDownloadable",
                newName: "IX_DocumentDownloadable_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControls_LastChangedById",
                table: "CandidatePoliticPartyControl",
                newName: "IX_CandidatePoliticPartyControl_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControls_DeletedById",
                table: "CandidatePoliticPartyControl",
                newName: "IX_CandidatePoliticPartyControl_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControls_CreatedById",
                table: "CandidatePoliticPartyControl",
                newName: "IX_CandidatePoliticPartyControl_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControls_ControlNameId",
                table: "CandidatePoliticPartyControl",
                newName: "IX_CandidatePoliticPartyControl_ControlNameId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyControls_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControl",
                newName: "IX_CandidatePoliticPartyControl_CandidatePoliticPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunities_LastChangedById",
                table: "CandidatePoliticPartyCommunity",
                newName: "IX_CandidatePoliticPartyCommunity_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunities_DeletedById",
                table: "CandidatePoliticPartyCommunity",
                newName: "IX_CandidatePoliticPartyCommunity_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunities_CreatedById",
                table: "CandidatePoliticPartyCommunity",
                newName: "IX_CandidatePoliticPartyCommunity_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunities_CommunityId",
                table: "CandidatePoliticPartyCommunity",
                newName: "IX_CandidatePoliticPartyCommunity_CommunityId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticPartyCommunities_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunity",
                newName: "IX_CandidatePoliticPartyCommunity_CandidatePoliticPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParties_TypePoliticalPartyId",
                table: "CandidatePoliticParty",
                newName: "IX_CandidatePoliticParty_TypePoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParties_PoliticalPartyId",
                table: "CandidatePoliticParty",
                newName: "IX_CandidatePoliticParty_PoliticalPartyId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParties_LastChangedById",
                table: "CandidatePoliticParty",
                newName: "IX_CandidatePoliticParty_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParties_ElectionId",
                table: "CandidatePoliticParty",
                newName: "IX_CandidatePoliticParty_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParties_DeletedById",
                table: "CandidatePoliticParty",
                newName: "IX_CandidatePoliticParty_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticParties_CreatedById",
                table: "CandidatePoliticParty",
                newName: "IX_CandidatePoliticParty_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPersons_PersonTypeId",
                table: "CandidatePoliticalPartyPerson",
                newName: "IX_CandidatePoliticalPartyPerson_PersonTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPersons_MunicipalityId",
                table: "CandidatePoliticalPartyPerson",
                newName: "IX_CandidatePoliticalPartyPerson_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPersons_LastChangedById",
                table: "CandidatePoliticalPartyPerson",
                newName: "IX_CandidatePoliticalPartyPerson_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPersons_DeletedById",
                table: "CandidatePoliticalPartyPerson",
                newName: "IX_CandidatePoliticalPartyPerson_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPersons_CreatedById",
                table: "CandidatePoliticalPartyPerson",
                newName: "IX_CandidatePoliticalPartyPerson_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_CandidatePoliticalPartyPersons_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPerson",
                newName: "IX_CandidatePoliticalPartyPerson_CandidatePoliticPartyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticalPartyPerson",
                table: "PoliticalPartyPerson",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticalPartyControl",
                table: "PoliticalPartyControl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PoliticalParty",
                table: "PoliticalParty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeWorkExperience",
                table: "EmployeeWorkExperience",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeSkill",
                table: "EmployeeSkill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeEduactionTraining",
                table: "EmployeeEduactionTraining",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentDownloadableTranslation",
                table: "DocumentDownloadableTranslation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DocumentDownloadable",
                table: "DocumentDownloadable",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticPartyControl",
                table: "CandidatePoliticPartyControl",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticPartyCommunity",
                table: "CandidatePoliticPartyCommunity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticParty",
                table: "CandidatePoliticParty",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CandidatePoliticalPartyPerson",
                table: "CandidatePoliticalPartyPerson",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_CreatedById",
                table: "CandidatePoliticalPartyPerson",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_DeletedById",
                table: "CandidatePoliticalPartyPerson",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_AspNetUsers_LastChangedById",
                table: "CandidatePoliticalPartyPerson",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "CandidatePoliticalPartyPerson",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_Lists_PersonTypeId",
                table: "CandidatePoliticalPartyPerson",
                column: "PersonTypeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticalPartyPerson_Municipalities_MunicipalityId",
                table: "CandidatePoliticalPartyPerson",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParty_AspNetUsers_CreatedById",
                table: "CandidatePoliticParty",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParty_AspNetUsers_DeletedById",
                table: "CandidatePoliticParty",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParty_AspNetUsers_LastChangedById",
                table: "CandidatePoliticParty",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParty_Elections_ElectionId",
                table: "CandidatePoliticParty",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParty_Lists_TypePoliticalPartyId",
                table: "CandidatePoliticParty",
                column: "TypePoliticalPartyId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticParty_PoliticalParty_PoliticalPartyId",
                table: "CandidatePoliticParty",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyCommunity",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyCommunity",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyCommunity",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyCommunity",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyCommunity_Lists_CommunityId",
                table: "CandidatePoliticPartyCommunity",
                column: "CommunityId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControl_AspNetUsers_CreatedById",
                table: "CandidatePoliticPartyControl",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControl_AspNetUsers_DeletedById",
                table: "CandidatePoliticPartyControl",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControl_AspNetUsers_LastChangedById",
                table: "CandidatePoliticPartyControl",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControl_CandidatePoliticParty_CandidatePoliticPartyId",
                table: "CandidatePoliticPartyControl",
                column: "CandidatePoliticPartyId",
                principalTable: "CandidatePoliticParty",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CandidatePoliticPartyControl_Lists_ControlNameId",
                table: "CandidatePoliticPartyControl",
                column: "ControlNameId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadable_AspNetUsers_CreatedById",
                table: "DocumentDownloadable",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadable_AspNetUsers_DeletedById",
                table: "DocumentDownloadable",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadable_AspNetUsers_LastChangedById",
                table: "DocumentDownloadable",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadable_Lists_DocumentTypeId",
                table: "DocumentDownloadable",
                column: "DocumentTypeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadableTranslation_DocumentDownloadable_DocumentDownloadableId",
                table: "DocumentDownloadableTranslation",
                column: "DocumentDownloadableId",
                principalTable: "DocumentDownloadable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadableTranslation_Documents_DocumentId",
                table: "DocumentDownloadableTranslation",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentDownloadableTranslation_Languages_LanguageId",
                table: "DocumentDownloadableTranslation",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");

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
                name: "FK_DocumentTranslations_DocumentDownloadable_DocumentDownloadableId",
                table: "DocumentTranslations",
                column: "DocumentDownloadableId",
                principalTable: "DocumentDownloadable",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_CreatedById",
                table: "Employee",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_DeletedById",
                table: "Employee",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_LastChangedById",
                table: "Employee",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Elections_ElectionId",
                table: "Employee",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Lists_BankNameId",
                table: "Employee",
                column: "BankNameId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Lists_GenderId",
                table: "Employee",
                column: "GenderId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Lists_HighestEducationLevelId",
                table: "Employee",
                column: "HighestEducationLevelId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Lists_LocationUnitId",
                table: "Employee",
                column: "LocationUnitId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Lists_WorkingPositionId",
                table: "Employee",
                column: "WorkingPositionId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Municipalities_MunicipalityResidenceId",
                table: "Employee",
                column: "MunicipalityResidenceId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTraining_AspNetUsers_CreatedById",
                table: "EmployeeEduactionTraining",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTraining_AspNetUsers_DeletedById",
                table: "EmployeeEduactionTraining",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTraining_AspNetUsers_LastChangedById",
                table: "EmployeeEduactionTraining",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTraining_Employee_EmployeeId",
                table: "EmployeeEduactionTraining",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeEduactionTraining_Lists_EducationTraningId",
                table: "EmployeeEduactionTraining",
                column: "EducationTraningId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_AspNetUsers_CreatedById",
                table: "EmployeeSkill",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_AspNetUsers_DeletedById",
                table: "EmployeeSkill",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_AspNetUsers_LastChangedById",
                table: "EmployeeSkill",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Employee_EmployeeId",
                table: "EmployeeSkill",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Lists_AccessId",
                table: "EmployeeSkill",
                column: "AccessId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Lists_DatabaseDevelopmentId",
                table: "EmployeeSkill",
                column: "DatabaseDevelopmentId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Lists_ExcelId",
                table: "EmployeeSkill",
                column: "ExcelId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSkill_Lists_WordId",
                table: "EmployeeSkill",
                column: "WordId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperience_AspNetUsers_CreatedById",
                table: "EmployeeWorkExperience",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperience_AspNetUsers_DeletedById",
                table: "EmployeeWorkExperience",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperience_AspNetUsers_LastChangedById",
                table: "EmployeeWorkExperience",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkExperience_Employee_EmployeeId",
                table: "EmployeeWorkExperience",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParty_AspNetUsers_CreatedById",
                table: "PoliticalParty",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParty_AspNetUsers_DeletedById",
                table: "PoliticalParty",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParty_AspNetUsers_LastChangedById",
                table: "PoliticalParty",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParty_Elections_ElectionId",
                table: "PoliticalParty",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalParty_Municipalities_MunicipalityId",
                table: "PoliticalParty",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyControl_Lists_ControlNameId",
                table: "PoliticalPartyControl",
                column: "ControlNameId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyControl_PoliticalParty_PoliticalPartyId",
                table: "PoliticalPartyControl",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParty",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPerson_AspNetUsers_CreatedById",
                table: "PoliticalPartyPerson",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPerson_AspNetUsers_DeletedById",
                table: "PoliticalPartyPerson",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPerson_AspNetUsers_LastChangedById",
                table: "PoliticalPartyPerson",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPerson_Lists_PersonTypeId",
                table: "PoliticalPartyPerson",
                column: "PersonTypeId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPerson_Municipalities_MunicipalityId",
                table: "PoliticalPartyPerson",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyPerson_PoliticalParty_PoliticalPartyId",
                table: "PoliticalPartyPerson",
                column: "PoliticalPartyId",
                principalTable: "PoliticalParty",
                principalColumn: "Id");
        }
    }
}
