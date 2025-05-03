using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class changelanguage2Listtranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55660013-d101-427f-a62a-f6568b936af1",
                column: "ConcurrencyStamp",
                value: "5722bd62-bb15-4a00-88b7-d1d56485f075");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0568ef-f131-4044-9bd9-8d49d186d278",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9ef44d57-3c43-4630-972c-ccef6d9896e0", "AQAAAAEAACcQAAAAEH91OBUfFpsDuTdrWljC/2ADf1EztVhvc5F1emG/rrRJU+ycviXrXLRzUahp3tRX2Q==", "6b69109c-cc56-4405-8eb7-88ced51265b6" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 957, DateTimeKind.Local).AddTicks(5976));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 957, DateTimeKind.Local).AddTicks(6059));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 957, DateTimeKind.Local).AddTicks(6066));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 957, DateTimeKind.Local).AddTicks(6071));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 957, DateTimeKind.Local).AddTicks(6075));

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7737), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7744), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7749), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7754), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7759), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7764), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7769), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7774), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7779), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7784), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7896), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7902), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7907), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7912), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7917), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7921), 1 });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7926), 1 });

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7278));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7328));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7334));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7350));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7355));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7366));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7372));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7376));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7381));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7386));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7441));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7446));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7451));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7456));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7461));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7466));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7518));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7526));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7532));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7537));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7557));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7563));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7568));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7593));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7653));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7665));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7670));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7674));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7687));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 16, 3, 28, 961, DateTimeKind.Local).AddTicks(7692));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9180), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9184), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9187), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9189), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9191), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9194), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9196), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9198), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9200), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9202), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9204), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9207), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9209), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9211), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9213), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9215), null });

            migrationBuilder.UpdateData(
                table: "ListTranslations",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "LanguageId" },
                values: new object[] { new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9217), null });

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

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9112));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9117));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9120));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9123));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9125));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9127));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9129));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9131));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9133));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9136));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9141));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9148));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9150));

            migrationBuilder.UpdateData(
                table: "Lists",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 15, 23, 24, 938, DateTimeKind.Local).AddTicks(9152));
        }
    }
}
