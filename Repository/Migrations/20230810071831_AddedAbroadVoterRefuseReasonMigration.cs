using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class AddedAbroadVoterRefuseReasonMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbroadVoterRefuseReasons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RefuseReasonId = table.Column<int>(type: "int", nullable: true),
                    AbroadVoterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_AbroadVoterRefuseReasons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AbroadVoters_AbroadVoterId",
                        column: x => x.AbroadVoterId,
                        principalTable: "AbroadVoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterRefuseReasons_Lists_RefuseReasonId",
                        column: x => x.RefuseReasonId,
                        principalTable: "Lists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_AbroadVoterId",
                table: "AbroadVoterRefuseReasons",
                column: "AbroadVoterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_CreatedById",
                table: "AbroadVoterRefuseReasons",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_DeletedById",
                table: "AbroadVoterRefuseReasons",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_LastChangedById",
                table: "AbroadVoterRefuseReasons",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterRefuseReasons_RefuseReasonId",
                table: "AbroadVoterRefuseReasons",
                column: "RefuseReasonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbroadVoterRefuseReasons");
        }
    }
}
