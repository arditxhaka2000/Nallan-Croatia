using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addedList4Listtype2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55660013-d101-427f-a62a-f6568b936af1",
                column: "ConcurrencyStamp",
                value: "e3154499-b09b-40f9-8f22-96c993311114");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0568ef-f131-4044-9bd9-8d49d186d278",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f50da936-1b46-458c-8431-3dc7d1ff499e", "AQAAAAEAACcQAAAAEMsO9hAMNGJ+e6ZLyoo4y/RVvR4DHdEX4/de3Q61StVfvzD5qoXgi+ADe/dyjSTq7g==", "af53a232-6e90-4538-9d51-d7d84ddb0b4e" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 936, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 936, DateTimeKind.Local).AddTicks(5113));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 936, DateTimeKind.Local).AddTicks(5118));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 936, DateTimeKind.Local).AddTicks(5121));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 936, DateTimeKind.Local).AddTicks(5125));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9039));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9042));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9045));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9049));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9051));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9054));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9056));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9058));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9060));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9066));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9068));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9070));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9080));

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "Code", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "IsActive", "IsDeleted", "LastChangedById", "LastChangedDate", "ListTypeId", "OrderIndex" },
                values: new object[,]
                {
                    { 1, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9112), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0 },
                    { 2, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9117), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0 },
                    { 3, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9120), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0 },
                    { 4, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9123), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0 },
                    { 5, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9125), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0 },
                    { 6, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9127), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0 },
                    { 7, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9129), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 0 },
                    { 8, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9131), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 0 },
                    { 9, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9133), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 0 },
                    { 10, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9136), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0 },
                    { 11, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9139), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 0 },
                    { 12, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9141), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 0 },
                    { 13, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9143), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 0 },
                    { 14, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9146), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, 0 },
                    { 15, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9148), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, 0 },
                    { 16, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9150), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, 0 },
                    { 17, null, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9152), null, null, true, false, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, 0 }
                });

            migrationBuilder.InsertData(
                table: "ListTranslations",
                columns: new[] { "Id", "CreatedById", "CreatedDate", "DeletedById", "DeletedDate", "IsDeleted", "LanguageId", "LastChangedById", "LastChangedDate", "ListId", "Name", "NameTransitive" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9180), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Zgjedhet lokale", null },
                    { 2, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9184), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "E rregullt", null },
                    { 3, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9187), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Djal", null },
                    { 4, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9189), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Aprovim", null },
                    { 5, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9191), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Regjistrimi i partisë politike", null },
                    { 6, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9194), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Person Kontaktues", null },
                    { 7, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9196), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Egjiptas", null },
                    { 8, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9198), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, "Tarif 500 E", null },
                    { 9, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9200), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, "Statusi i partis politike", null },
                    { 10, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9202), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, "Koalucion", null },
                    { 11, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9204), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, "Zyrtar i transportit", null },
                    { 12, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9207), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, "Divizioni per logjistik dhe transport", null },
                    { 13, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9209), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, "Edukimi Univerzitar", null },
                    { 14, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9211), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14, "I Dobet", null },
                    { 15, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9213), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15, "Trajnimi per Kryesues", null },
                    { 16, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9215), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 16, "Shqip", null },
                    { 17, null, new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9217), null, null, false, null, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 17, "Dobet", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55660013-d101-427f-a62a-f6568b936af1",
                column: "ConcurrencyStamp",
                value: "e9025143-cab3-4b34-a92e-03052e9215bf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0568ef-f131-4044-9bd9-8d49d186d278",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76c9d112-5e10-472c-8cf0-7561f8390202", "AQAAAAEAACcQAAAAELGFGBP7RfZqOBOy1FdRIM8WFXQgEo8MoKUmo0b0nPN9GTnDGfUmHqD4oR/6iJsH/w==", "2a1c1089-bb88-4a9e-84a9-40a4110dad78" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 548, DateTimeKind.Local).AddTicks(9047));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 548, DateTimeKind.Local).AddTicks(9087));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 548, DateTimeKind.Local).AddTicks(9089));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 548, DateTimeKind.Local).AddTicks(9091));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 548, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3946));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3954));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3956));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3957));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3959));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3960));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3962));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3963));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3965));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3966));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3968));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3969));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3971));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3972));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3973));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3975));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 6, 35, 550, DateTimeKind.Local).AddTicks(3976));
        }
    }
}
