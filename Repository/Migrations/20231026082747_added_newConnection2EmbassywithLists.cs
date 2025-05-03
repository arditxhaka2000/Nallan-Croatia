using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class added_newConnection2EmbassywithLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiplomaticRelationTypeId",
                table: "Embassies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Embassies_DiplomaticRelationTypeId",
                table: "Embassies",
                column: "DiplomaticRelationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Embassies_Lists_DiplomaticRelationTypeId",
                table: "Embassies",
                column: "DiplomaticRelationTypeId",
                principalTable: "Lists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Embassies_Lists_DiplomaticRelationTypeId",
                table: "Embassies");

            migrationBuilder.DropIndex(
                name: "IX_Embassies_DiplomaticRelationTypeId",
                table: "Embassies");

            migrationBuilder.DropColumn(
                name: "DiplomaticRelationTypeId",
                table: "Embassies");
        }
    }
}
