using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class addlanguageIdInObserverOrganizationTranslation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ObserverOrganizationTranslations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ObserverOrganizationTranslations_LanguageId",
                table: "ObserverOrganizationTranslations",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_ObserverOrganizationTranslations_Languages_LanguageId",
                table: "ObserverOrganizationTranslations",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ObserverOrganizationTranslations_Languages_LanguageId",
                table: "ObserverOrganizationTranslations");

            migrationBuilder.DropIndex(
                name: "IX_ObserverOrganizationTranslations_LanguageId",
                table: "ObserverOrganizationTranslations");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ObserverOrganizationTranslations");
        }
    }
}
