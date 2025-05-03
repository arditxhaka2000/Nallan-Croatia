using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class dataResultmachtinf4CanditateDetailPPv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.RenameColumn(
                name: "DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "DataResultsMatchingId");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingId");

            migrationBuilder.AddColumn<Guid>(
                name: "DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingCaditatePPEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataResultsMatchingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DataResultsMatchingCandidateDetailPPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_DataResultsMatchingCaditatePPEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCaditatePPEmployees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCaditatePPEmployees_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCaditatePPEmployees_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCaditatePPEmployees_DataResultMatchings_DataResultsMatchingId",
                        column: x => x.DataResultsMatchingId,
                        principalTable: "DataResultMatchings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCaditatePPEmployees_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingCandidateDetailPPId",
                        column: x => x.DataResultsMatchingCandidateDetailPPId,
                        principalTable: "DataResultsMatchingCandidateDetailPPs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCaditatePPEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingFormId1");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCaditatePPEmployees_CreatedById",
                table: "DataResultsMatchingCaditatePPEmployees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCaditatePPEmployees_DataResultsMatchingCandidateDetailPPId",
                table: "DataResultsMatchingCaditatePPEmployees",
                column: "DataResultsMatchingCandidateDetailPPId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCaditatePPEmployees_DataResultsMatchingId",
                table: "DataResultsMatchingCaditatePPEmployees",
                column: "DataResultsMatchingId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCaditatePPEmployees_DeletedById",
                table: "DataResultsMatchingCaditatePPEmployees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCaditatePPEmployees_EmployeeId",
                table: "DataResultsMatchingCaditatePPEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCaditatePPEmployees_LastChangedById",
                table: "DataResultsMatchingCaditatePPEmployees",
                column: "LastChangedById");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultMatchings_DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingId",
                principalTable: "DataResultMatchings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingFormId1",
                principalTable: "DataResultsMatchingForms",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultMatchings_DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.DropForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.DropTable(
                name: "DataResultsMatchingCaditatePPEmployees");

            migrationBuilder.DropIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.DropColumn(
                name: "DataResultsMatchingFormId1",
                table: "DataResultsMatchingCandidateDetailPPs");

            migrationBuilder.RenameColumn(
                name: "DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "DataResultsMatchingFormId");

            migrationBuilder.RenameIndex(
                name: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingId",
                table: "DataResultsMatchingCandidateDetailPPs",
                newName: "IX_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingFormId");

            migrationBuilder.AddForeignKey(
                name: "FK_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingForms_DataResultsMatchingFormId",
                table: "DataResultsMatchingCandidateDetailPPs",
                column: "DataResultsMatchingFormId",
                principalTable: "DataResultsMatchingForms",
                principalColumn: "Id");
        }
    }
}
