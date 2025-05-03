using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ErpTempData2basentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "ErpTemps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "ErpTemps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "ErpTemps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "ErpTemps",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ErpTemps",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastChangedById",
                table: "ErpTemps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangedDate",
                table: "ErpTemps",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_ErpTemps_CreatedById",
                table: "ErpTemps",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ErpTemps_DeletedById",
                table: "ErpTemps",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ErpTemps_LastChangedById",
                table: "ErpTemps",
                column: "LastChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_ErpTemps_AspNetUsers_CreatedById",
                table: "ErpTemps",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ErpTemps_AspNetUsers_DeletedById",
                table: "ErpTemps",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ErpTemps_AspNetUsers_LastChangedById",
                table: "ErpTemps",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ErpTemps_AspNetUsers_CreatedById",
                table: "ErpTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_ErpTemps_AspNetUsers_DeletedById",
                table: "ErpTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_ErpTemps_AspNetUsers_LastChangedById",
                table: "ErpTemps");

            migrationBuilder.DropIndex(
                name: "IX_ErpTemps_CreatedById",
                table: "ErpTemps");

            migrationBuilder.DropIndex(
                name: "IX_ErpTemps_DeletedById",
                table: "ErpTemps");

            migrationBuilder.DropIndex(
                name: "IX_ErpTemps_LastChangedById",
                table: "ErpTemps");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "ErpTemps");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "ErpTemps");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "ErpTemps");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "ErpTemps");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ErpTemps");

            migrationBuilder.DropColumn(
                name: "LastChangedById",
                table: "ErpTemps");

            migrationBuilder.DropColumn(
                name: "LastChangedDate",
                table: "ErpTemps");
        }
    }
}
