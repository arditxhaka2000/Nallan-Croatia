using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class dropPollingStationChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PollingStationChanges_PollingStationChangeId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "PollingStationChanges");

            migrationBuilder.RenameColumn(
                name: "PollingStationChangeId",
                table: "Documents",
                newName: "PollingCenterChangeId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_PollingStationChangeId",
                table: "Documents",
                newName: "IX_Documents_PollingCenterChangeId");

            migrationBuilder.CreateTable(
                name: "PollingCenterChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CurrentPollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    RequestedPollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    MAEComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefusalReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_PollingCenterChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_PollingCenters_CurrentPollingCenterId",
                        column: x => x.CurrentPollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingCenterChanges_PollingCenters_RequestedPollingCenterId",
                        column: x => x.RequestedPollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_CreatedById",
                table: "PollingCenterChanges",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_CurrentPollingCenterId",
                table: "PollingCenterChanges",
                column: "CurrentPollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_DecisionId",
                table: "PollingCenterChanges",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_DeletedById",
                table: "PollingCenterChanges",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_ElectionId",
                table: "PollingCenterChanges",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_GenderId",
                table: "PollingCenterChanges",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_LastChangedById",
                table: "PollingCenterChanges",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_MunicipalityId",
                table: "PollingCenterChanges",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingCenterChanges_RequestedPollingCenterId",
                table: "PollingCenterChanges",
                column: "RequestedPollingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PollingCenterChanges_PollingCenterChangeId",
                table: "Documents",
                column: "PollingCenterChangeId",
                principalTable: "PollingCenterChanges",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documents_PollingCenterChanges_PollingCenterChangeId",
                table: "Documents");

            migrationBuilder.DropTable(
                name: "PollingCenterChanges");

            migrationBuilder.RenameColumn(
                name: "PollingCenterChangeId",
                table: "Documents",
                newName: "PollingStationChangeId");

            migrationBuilder.RenameIndex(
                name: "IX_Documents_PollingCenterChangeId",
                table: "Documents",
                newName: "IX_Documents_PollingStationChangeId");

            migrationBuilder.CreateTable(
                name: "PollingStationChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CurrentPollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DecisionId = table.Column<int>(type: "int", nullable: true),
                    DeletedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ElectionId = table.Column<int>(type: "int", nullable: true),
                    GenderId = table.Column<int>(type: "int", nullable: true),
                    LastChangedById = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    RequestedPollingCenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Apartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApplicantCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAEComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefusalReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StreetNr = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PollingStationChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Elections_ElectionId",
                        column: x => x.ElectionId,
                        principalTable: "Elections",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Lists_DecisionId",
                        column: x => x.DecisionId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Lists_GenderId",
                        column: x => x.GenderId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_PollingCenters_CurrentPollingCenterId",
                        column: x => x.CurrentPollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PollingStationChanges_PollingCenters_RequestedPollingCenterId",
                        column: x => x.RequestedPollingCenterId,
                        principalTable: "PollingCenters",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_CreatedById",
                table: "PollingStationChanges",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_CurrentPollingCenterId",
                table: "PollingStationChanges",
                column: "CurrentPollingCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_DecisionId",
                table: "PollingStationChanges",
                column: "DecisionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_DeletedById",
                table: "PollingStationChanges",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_ElectionId",
                table: "PollingStationChanges",
                column: "ElectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_GenderId",
                table: "PollingStationChanges",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_LastChangedById",
                table: "PollingStationChanges",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_MunicipalityId",
                table: "PollingStationChanges",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_PollingStationChanges_RequestedPollingCenterId",
                table: "PollingStationChanges",
                column: "RequestedPollingCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documents_PollingStationChanges_PollingStationChangeId",
                table: "Documents",
                column: "PollingStationChangeId",
                principalTable: "PollingStationChanges",
                principalColumn: "Id");
        }
    }
}
