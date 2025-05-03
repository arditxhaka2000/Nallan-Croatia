using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addedList4Listtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "55660013-d101-427f-a62a-f6568b936af1",
                column: "ConcurrencyStamp",
                value: "a5380100-246e-4100-a43c-c74834d5f0e4");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e0568ef-f131-4044-9bd9-8d49d186d278",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8288859-e743-43fc-a44e-2e0bcf4a8b5f", "AQAAAAEAACcQAAAAEA/ofuZ4Hg1Yb2a6x5mPenDVgMwj47CqgedfVHEYJ7UAIkl6xWaXKMlwt0xQyb72cQ==", "d4306225-bbee-4316-9bf9-f5d43209669f" });

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4929));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4965));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4966));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4968));

            migrationBuilder.UpdateData(
                table: "Languages",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 382, DateTimeKind.Local).AddTicks(4970));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9368));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9379));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9381));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9383));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9384));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9386));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9389));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9390));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9391));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9393));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9394));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9395));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9397));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9398));

            migrationBuilder.UpdateData(
                table: "ListTypes",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 10, 14, 15, 23, 383, DateTimeKind.Local).AddTicks(9399));
        }
    }
}
