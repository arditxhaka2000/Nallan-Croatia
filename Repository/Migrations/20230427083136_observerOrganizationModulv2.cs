using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class observerOrganizationModulv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ConfirmNotDiscualifition",
                table: "ObserversApplications",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "ObserverOrganizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    ObserversApplicationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ObserverOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizations_ObserversApplications_ObserversApplicationId",
                        column: x => x.ObserversApplicationId,
                        principalTable: "ObserversApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObserverOrganizationPersons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonalNr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObserverOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ObserverOrganizationPersons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationPersons_ObserverOrganizations_ObserverOrganizationId",
                        column: x => x.ObserverOrganizationId,
                        principalTable: "ObserverOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObserverOrganizationTranslations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ObserverOrganizationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_ObserverOrganizationTranslations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ObserverOrganizationTranslations_ObserverOrganizations_ObserverOrganizationId",
                        column: x => x.ObserverOrganizationId,
                        principalTable: "ObserverOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_CreatedById",
                table: "ObserverOrganizationPersons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_DeletedById",
                table: "ObserverOrganizationPersons",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_LastChangedById",
                table: "ObserverOrganizationPersons",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationPersons_ObserverOrganizationId",
                table: "ObserverOrganizationPersons",
                column: "ObserverOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_CreatedById",
                table: "ObserverOrganizations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_DeletedById",
                table: "ObserverOrganizations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_LastChangedById",
                table: "ObserverOrganizations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_MunicipalityId",
                table: "ObserverOrganizations",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizations_ObserversApplicationId",
                table: "ObserverOrganizations",
                column: "ObserversApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_CreatedById",
                table: "ObserverOrganizationTranslations",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_DeletedById",
                table: "ObserverOrganizationTranslations",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_LastChangedById",
                table: "ObserverOrganizationTranslations",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_ObserverOrganizationId",
                table: "ObserverOrganizationTranslations",
                column: "ObserverOrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObserverOrganizationPersons");

            migrationBuilder.DropTable(
                name: "ObserverOrganizationTranslations");

            migrationBuilder.DropTable(
                name: "ObserverOrganizations");

            migrationBuilder.DropColumn(
                name: "ConfirmNotDiscualifition",
                table: "ObserversApplications");
        }
    }
}
