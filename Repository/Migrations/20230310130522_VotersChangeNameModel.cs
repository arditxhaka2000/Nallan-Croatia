using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class VotersChangeNameModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_voters_AspNetUsers_CreatedById",
                table: "voters");

            migrationBuilder.DropForeignKey(
                name: "FK_voters_AspNetUsers_DeletedById",
                table: "voters");

            migrationBuilder.DropForeignKey(
                name: "FK_voters_AspNetUsers_LastChangedById",
                table: "voters");

            migrationBuilder.DropForeignKey(
                name: "FK_voters_Elections_ElectionId",
                table: "voters");

            migrationBuilder.DropForeignKey(
                name: "FK_voters_Lists_GenderId",
                table: "voters");

            migrationBuilder.DropForeignKey(
                name: "FK_voters_Municipalities_MunicipalityId",
                table: "voters");

            migrationBuilder.DropForeignKey(
                name: "FK_voters_PollingCenters_PollingCenterId",
                table: "voters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_voters",
                table: "voters");

            migrationBuilder.RenameTable(
                name: "voters",
                newName: "Voters");

            migrationBuilder.RenameIndex(
                name: "IX_voters_PollingCenterId",
                table: "Voters",
                newName: "IX_Voters_PollingCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_voters_MunicipalityId",
                table: "Voters",
                newName: "IX_Voters_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_voters_LastChangedById",
                table: "Voters",
                newName: "IX_Voters_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_voters_GenderId",
                table: "Voters",
                newName: "IX_Voters_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_voters_ElectionId",
                table: "Voters",
                newName: "IX_Voters_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_voters_DeletedById",
                table: "Voters",
                newName: "IX_Voters_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_voters_CreatedById",
                table: "Voters",
                newName: "IX_Voters_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Voters",
                table: "Voters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_AspNetUsers_CreatedById",
                table: "Voters",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_AspNetUsers_DeletedById",
                table: "Voters",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_AspNetUsers_LastChangedById",
                table: "Voters",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_Elections_ElectionId",
                table: "Voters",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_Lists_GenderId",
                table: "Voters",
                column: "GenderId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_Municipalities_MunicipalityId",
                table: "Voters",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Voters_PollingCenters_PollingCenterId",
                table: "Voters",
                column: "PollingCenterId",
                principalTable: "PollingCenters",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Voters_AspNetUsers_CreatedById",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_AspNetUsers_DeletedById",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_AspNetUsers_LastChangedById",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_Elections_ElectionId",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_Lists_GenderId",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_Municipalities_MunicipalityId",
                table: "Voters");

            migrationBuilder.DropForeignKey(
                name: "FK_Voters_PollingCenters_PollingCenterId",
                table: "Voters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Voters",
                table: "Voters");

            migrationBuilder.RenameTable(
                name: "Voters",
                newName: "voters");

            migrationBuilder.RenameIndex(
                name: "IX_Voters_PollingCenterId",
                table: "voters",
                newName: "IX_voters_PollingCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_Voters_MunicipalityId",
                table: "voters",
                newName: "IX_voters_MunicipalityId");

            migrationBuilder.RenameIndex(
                name: "IX_Voters_LastChangedById",
                table: "voters",
                newName: "IX_voters_LastChangedById");

            migrationBuilder.RenameIndex(
                name: "IX_Voters_GenderId",
                table: "voters",
                newName: "IX_voters_GenderId");

            migrationBuilder.RenameIndex(
                name: "IX_Voters_ElectionId",
                table: "voters",
                newName: "IX_voters_ElectionId");

            migrationBuilder.RenameIndex(
                name: "IX_Voters_DeletedById",
                table: "voters",
                newName: "IX_voters_DeletedById");

            migrationBuilder.RenameIndex(
                name: "IX_Voters_CreatedById",
                table: "voters",
                newName: "IX_voters_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_voters",
                table: "voters",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_voters_AspNetUsers_CreatedById",
                table: "voters",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_voters_AspNetUsers_DeletedById",
                table: "voters",
                column: "DeletedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_voters_AspNetUsers_LastChangedById",
                table: "voters",
                column: "LastChangedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_voters_Elections_ElectionId",
                table: "voters",
                column: "ElectionId",
                principalTable: "Elections",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_voters_Lists_GenderId",
                table: "voters",
                column: "GenderId",
                principalTable: "Lists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_voters_Municipalities_MunicipalityId",
                table: "voters",
                column: "MunicipalityId",
                principalTable: "Municipalities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_voters_PollingCenters_PollingCenterId",
                table: "voters",
                column: "PollingCenterId",
                principalTable: "PollingCenters",
                principalColumn: "Id");
        }
    }
}
