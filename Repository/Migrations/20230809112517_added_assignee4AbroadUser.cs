using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class added_assignee4AbroadUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssigneeId",
                table: "AbroadVoters",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AbroadVoterUserAssignees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AbroadVoterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssigneeFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Assignee2Date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                    table.PrimaryKey("PK_AbroadVoterUserAssignees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AbroadVoters_AbroadVoterId",
                        column: x => x.AbroadVoterId,
                        principalTable: "AbroadVoters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_DeletedById",
                        column: x => x.DeletedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_LastChangedById",
                        column: x => x.LastChangedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AbroadVoterUserAssignees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoters_AssigneeId",
                table: "AbroadVoters",
                column: "AssigneeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_AbroadVoterId",
                table: "AbroadVoterUserAssignees",
                column: "AbroadVoterId");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_CreatedById",
                table: "AbroadVoterUserAssignees",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_DeletedById",
                table: "AbroadVoterUserAssignees",
                column: "DeletedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_LastChangedById",
                table: "AbroadVoterUserAssignees",
                column: "LastChangedById");

            migrationBuilder.CreateIndex(
                name: "IX_AbroadVoterUserAssignees_UserId",
                table: "AbroadVoterUserAssignees",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbroadVoters_AspNetUsers_AssigneeId",
                table: "AbroadVoters",
                column: "AssigneeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbroadVoters_AspNetUsers_AssigneeId",
                table: "AbroadVoters");

            migrationBuilder.DropTable(
                name: "AbroadVoterUserAssignees");

            migrationBuilder.DropIndex(
                name: "IX_AbroadVoters_AssigneeId",
                table: "AbroadVoters");

            migrationBuilder.DropColumn(
                name: "AssigneeId",
                table: "AbroadVoters");
        }
    }
}
