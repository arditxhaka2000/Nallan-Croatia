using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class added_Box_For_Votes_Is_AbroadVoter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAbroadKosovoPostalBoox",
                table: "AbroadVoters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDiplomaticRepresented",
                table: "AbroadVoters",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsKosovoPostalBoox",
                table: "AbroadVoters",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAbroadKosovoPostalBoox",
                table: "AbroadVoters");

            migrationBuilder.DropColumn(
                name: "IsDiplomaticRepresented",
                table: "AbroadVoters");

            migrationBuilder.DropColumn(
                name: "IsKosovoPostalBoox",
                table: "AbroadVoters");
        }
    }
}
