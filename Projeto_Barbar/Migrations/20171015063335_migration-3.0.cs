using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Projeto_Barbar.Migrations
{
    public partial class migration30 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tipo_Parametros_PARAMETRO_CONSULTAID",
                table: "Tipo_Parametros");

            migrationBuilder.AddColumn<long>(
                name: "PARAMETRO_CONSULTAID",
                table: "PARAMETRO_CONSULTAs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "Tipo_ParametroID",
                table: "PARAMETRO_CONSULTAs",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETRO_CONSULTAs_PARAMETRO_CONSULTAID",
                table: "PARAMETRO_CONSULTAs",
                column: "PARAMETRO_CONSULTAID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PARAMETRO_CONSULTAs_PARAMETRO_CONSULTAID",
                table: "PARAMETRO_CONSULTAs");
        }
    }
}
