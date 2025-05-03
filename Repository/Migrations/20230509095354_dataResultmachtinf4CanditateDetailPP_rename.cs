using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class dataResultmachtinf4CanditateDetailPP_rename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataResultsMatchingCaditatePPEmployees");

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingCandidatePPEmployees",
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
                    table.PrimaryKey("PK_DataResultsMatchingCandidatePPEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultMatchings_DataResultsMatchingId",
                        column: x => x.DataResultsMatchingId,
                        principalTable: "DataResultMatchings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingCandidateDetailPPs_DataResultsMatchingCandidateDetailPPId",
                        column: x => x.DataResultsMatchingCandidateDetailPPId,
                        principalTable: "DataResultsMatchingCandidateDetailPPs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DataResultsMatchingCandidatePPEmployees_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_CreatedById",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingCandidateDetailPPId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DataResultsMatchingCandidateDetailPPId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DataResultsMatchingId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DataResultsMatchingId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_DeletedById",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_EmployeeId",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_DataResultsMatchingCandidatePPEmployees_LastChangedById",
                table: "DataResultsMatchingCandidatePPEmployees",
                column: "LastChangedById");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataResultsMatchingCandidatePPEmployees");

            migrationBuilder.CreateTable(
                name: "DataResultsMatchingCaditatePPEmployees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    DataResultsMatchingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataResultsMatchingCandidateDetailPPId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
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
        }
    }
}
