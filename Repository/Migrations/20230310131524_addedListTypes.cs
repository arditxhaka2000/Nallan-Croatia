using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addedListTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_Lists_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents");

            migrationBuilder.DropColumn(
                name: "DocumentTypeId",
                table: "Documents");

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PoliticalPartyControls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "PoliticalPartyControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "PoliticalPartyControls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "PoliticalPartyControls",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PoliticalPartyControls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastChangedById",
                table: "PoliticalPartyControls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangedDate",
                table: "PoliticalPartyControls",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "55660013-d101-427f-a62a-f6568b936af1", "a5380100-246e-4100-a43c-c74834d5f0e4", "Administrator", "Administrator" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DefaultLanguageId", "Discriminator", "Email", "EmailConfirmed", "FirstName", "JobTitle", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "active" },
                values: new object[] { "9e0568ef-f131-4044-9bd9-8d49d186d278", 0, "e8288859-e743-43fc-a44e-2e0bcf4a8b5f", null, "AppUser", "admin@admin.com", true, "Admin", null, "ADMIN", false, null, "admin@admin.COM", "admin@admin.com", "AQAAAAEAACcQAAAAEA/ofuZ4Hg1Yb2a6x5mPenDVgMwj47CqgedfVHEYJ7UAIkl6xWaXKMlwt0xQyb72cQ==", "+111111111111", true, "d4306225-bbee-4316-9bf9-f5d43209669f", false, "admin@admin.COM", true });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Active", "Code", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "IsDeleted", "LastChangedById", "LastChangedDate", "Name" },
                values: new object[,]
                {
                    { 1, false, "sq", null, new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4929), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Albania" },
                    { 2, false, "en", null, new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4965), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "English" },
                    { 3, false, "sr", null, new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4966), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Serbian" },
                    { 4, false, "tr", null, new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4968), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Turkish" },
                    { 5, false, "bs", null, new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4970), null, null, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bosnian" }
                });

            migrationBuilder.InsertData(
                table: "ListTypes",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "IsActive", "IsDeleted", "LastChangedById", "LastChangedDate", "Name" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9368), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ElectionType" },
                    { 2, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9379), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PollingStationType" },
                    { 3, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9381), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gender" },
                    { 4, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9383), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PollingStationChangeDecision" },
                    { 5, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9384), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "DocumentType" },
                    { 6, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9385), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PersonType" },
                    { 7, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9386), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Community" },
                    { 8, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9388), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ControlName" },
                    { 9, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9389), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PoliticalPartyControlName" },
                    { 10, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9390), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "TypePoliticalParty" },
                    { 11, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9391), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WorkingPosition" },
                    { 12, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9393), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LocationUnit" },
                    { 13, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9394), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EducationTraning" },
                    { 14, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9395), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "SupervisorRating" },
                    { 15, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9397), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CompletedTraining" },
                    { 16, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9398), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EmployeeLanguage" },
                    { 17, null, new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9399), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EmployeeLanguageRationg" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "55660013-d101-427f-a62a-f6568b936af1", "9e0568ef-f131-4044-9bd9-8d49d186d278" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyControls_AspNetUsers_CreatedById",
                table: "PoliticalPartyControls",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyControls_AspNetUsers_DeletedById",
                table: "PoliticalPartyControls",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliticalPartyControls_AspNetUsers_LastChangedById",
                table: "PoliticalPartyControls",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyControls_AspNetUsers_CreatedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyControls_AspNetUsers_DeletedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliticalPartyControls_AspNetUsers_LastChangedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalPartyControls_CreatedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalPartyControls_DeletedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropIndex(
                name: "IX_PoliticalPartyControls_LastChangedById",
                table: "PoliticalPartyControls");

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
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55660013-d101-427f-a62a-f6568b936af1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0568ef-f131-4044-9bd9-8d49d186d278");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "PoliticalPartyControls");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "PoliticalPartyControls");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PoliticalPartyControls");

            migrationBuilder.DropColumn(
                name: "LastChangedById",
                table: "PoliticalPartyControls");

            migrationBuilder.DropColumn(
                name: "LastChangedDate",
                table: "PoliticalPartyControls");

            migrationBuilder.AddColumn<int>(
                name: "DocumentTypeId",
                table: "Documents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_Lists_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId",
                principalTable: "Lists",
                principalColumn: "Id");
        }
    }
}
