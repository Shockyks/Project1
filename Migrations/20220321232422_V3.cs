using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebProjekat.Migrations
{
    public partial class V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letovi_Aerodromi_Aerodrom1ID",
                table: "Letovi");

            migrationBuilder.DropForeignKey(
                name: "FK_Letovi_Aerodromi_Aerodrom2ID",
                table: "Letovi");

            migrationBuilder.DropIndex(
                name: "IX_Letovi_Aerodrom1ID",
                table: "Letovi");

            migrationBuilder.DropColumn(
                name: "Aerodrom1ID",
                table: "Letovi");

            migrationBuilder.DropColumn(
                name: "BrojPutnika",
                table: "Letovi");

            migrationBuilder.DropColumn(
                name: "Cena",
                table: "Letovi");

            migrationBuilder.RenameColumn(
                name: "Aerodrom2ID",
                table: "Letovi",
                newName: "AerodromID");

            migrationBuilder.RenameIndex(
                name: "IX_Letovi_Aerodrom2ID",
                table: "Letovi",
                newName: "IX_Letovi_AerodromID");

            migrationBuilder.AlterColumn<string>(
                name: "VremePolaska",
                table: "Letovi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AlterColumn<string>(
                name: "VremeDolaska",
                table: "Letovi",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "time");

            migrationBuilder.AddForeignKey(
                name: "FK_Letovi_Aerodromi_AerodromID",
                table: "Letovi",
                column: "AerodromID",
                principalTable: "Aerodromi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Letovi_Aerodromi_AerodromID",
                table: "Letovi");

            migrationBuilder.RenameColumn(
                name: "AerodromID",
                table: "Letovi",
                newName: "Aerodrom2ID");

            migrationBuilder.RenameIndex(
                name: "IX_Letovi_AerodromID",
                table: "Letovi",
                newName: "IX_Letovi_Aerodrom2ID");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "VremePolaska",
                table: "Letovi",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "VremeDolaska",
                table: "Letovi",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Aerodrom1ID",
                table: "Letovi",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BrojPutnika",
                table: "Letovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cena",
                table: "Letovi",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Letovi_Aerodrom1ID",
                table: "Letovi",
                column: "Aerodrom1ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Letovi_Aerodromi_Aerodrom1ID",
                table: "Letovi",
                column: "Aerodrom1ID",
                principalTable: "Aerodromi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Letovi_Aerodromi_Aerodrom2ID",
                table: "Letovi",
                column: "Aerodrom2ID",
                principalTable: "Aerodromi",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
