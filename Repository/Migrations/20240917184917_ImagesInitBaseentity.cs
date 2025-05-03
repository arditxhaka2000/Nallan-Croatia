using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ImagesInitBaseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "DeletedById",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Images",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Images",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LastChangedById",
                table: "Images",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangedDate",
                table: "Images",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Images_CreatedById",
                table: "Images",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_DeletedById",
                table: "Images",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LastChangedById",
                table: "Images",
                column: "LastChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_CreatedById",
                table: "Images",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_DeletedById",
                table: "Images",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_AspNetUsers_LastChangedById",
                table: "Images",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_CreatedById",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_DeletedById",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Images_AspNetUsers_LastChangedById",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_CreatedById",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_DeletedById",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_LastChangedById",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedById",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "LastChangedById",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "LastChangedDate",
                table: "Images");
        }
    }
}
