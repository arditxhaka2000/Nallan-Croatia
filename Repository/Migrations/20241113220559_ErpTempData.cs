using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class ErpTempData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ErpTemps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DokumentID = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtikullBarcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtikullEmri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArtikullNjesia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SasiaPaketim = table.Column<int>(type: "int", nullable: false),
                    Cmimi_me_TVSH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KohaRegjistrimit = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kodi_Shitjes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataModifikim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ErpStatus = table.Column<int>(type: "int", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErpTemps", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ErpTemps");
        }
    }
}
