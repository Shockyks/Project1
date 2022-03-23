using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aerodromi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Grad = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aerodromi", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Klase",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Dodatak = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klase", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Letovi",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aerodrom1ID = table.Column<int>(type: "int", nullable: true),
                    Aerodrom2ID = table.Column<int>(type: "int", nullable: true),
                    Cena = table.Column<int>(type: "int", nullable: false),
                    BrojMesta = table.Column<int>(type: "int", nullable: false),
                    BrojPutnika = table.Column<int>(type: "int", nullable: false),
                    KlasaID = table.Column<int>(type: "int", nullable: true),
                    DatumLeta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremePolaska = table.Column<TimeSpan>(type: "time", nullable: false),
                    VremeDolaska = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Letovi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Letovi_Aerodromi_Aerodrom1ID",
                        column: x => x.Aerodrom1ID,
                        principalTable: "Aerodromi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Letovi_Aerodromi_Aerodrom2ID",
                        column: x => x.Aerodrom2ID,
                        principalTable: "Aerodromi",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Letovi_Klase_KlasaID",
                        column: x => x.KlasaID,
                        principalTable: "Klase",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Letovi_Aerodrom1ID",
                table: "Letovi",
                column: "Aerodrom1ID");

            migrationBuilder.CreateIndex(
                name: "IX_Letovi_Aerodrom2ID",
                table: "Letovi",
                column: "Aerodrom2ID");

            migrationBuilder.CreateIndex(
                name: "IX_Letovi_KlasaID",
                table: "Letovi",
                column: "KlasaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Letovi");

            migrationBuilder.DropTable(
                name: "Aerodromi");

            migrationBuilder.DropTable(
                name: "Klase");
        }
    }
}
