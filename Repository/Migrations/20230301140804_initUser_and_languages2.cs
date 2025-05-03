using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class initUser_and_languages2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
