using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ServiceForSpecificMunicipalities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbroadVoter4Municipalities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MunicipalityId = table.Column<int>(type: "int", nullable: true),
                    ServiceConfigurationId = table.Column<int>(type: "int", nullable: true),
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
                    table.PrimaryKey("PK_AbroadVoter4Municipalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_Municipalities_MunicipalityId",
                        column: x => x.MunicipalityId,
                        principalTable: "Municipalities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoter4Municipalities_ServiceConfigurations_ServiceConfigurationId",
                        column: x => x.ServiceConfigurationId,
                        principalTable: "ServiceConfigurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_CreatedById",
                table: "AbroadVoter4Municipalities",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_DeletedById",
                table: "AbroadVoter4Municipalities",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_LastChangedById",
                table: "AbroadVoter4Municipalities",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_MunicipalityId",
                table: "AbroadVoter4Municipalities",
                column: "MunicipalityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoter4Municipalities_ServiceConfigurationId",
                table: "AbroadVoter4Municipalities",
                column: "ServiceConfigurationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbroadVoter4Municipalities");
        }
    }
}
