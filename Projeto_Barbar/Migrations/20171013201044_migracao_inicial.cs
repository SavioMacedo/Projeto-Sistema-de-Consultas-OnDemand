using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Projeto_Barbar.Migrations
{
    public partial class migracao_inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    DESCRICAO = table.Column<string>(type: "TEXT", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IC_ATIVO = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Associacaos",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    TP_ASSOC = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Associacaos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EMAIL = table.Column<string>(type: "TEXT", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", nullable: false),
                    SENHA = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Versaos",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    ConsultaID = table.Column<long>(type: "INTEGER", nullable: false),
                    DESCRICAO = table.Column<string>(type: "TEXT", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NU_VERSAO = table.Column<short>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Versaos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Versaos_Consultas_ConsultaID",
                        column: x => x.ConsultaID,
                        principalTable: "Consultas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assoc_usua_consus",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    ConsultaID = table.Column<long>(type: "INTEGER", nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tipo_AssociacaoID = table.Column<long>(type: "INTEGER", nullable: false),
                    UsuarioID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assoc_usua_consus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Assoc_usua_consus_Consultas_ConsultaID",
                        column: x => x.ConsultaID,
                        principalTable: "Consultas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assoc_usua_consus_Tipo_Associacaos_Tipo_AssociacaoID",
                        column: x => x.Tipo_AssociacaoID,
                        principalTable: "Tipo_Associacaos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assoc_usua_consus_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atualizas",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    ConsultaID = table.Column<long>(type: "INTEGER", nullable: false),
                    DESCRICAO = table.Column<string>(type: "TEXT", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UsuarioID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atualizas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atualizas_Consultas_ConsultaID",
                        column: x => x.ConsultaID,
                        principalTable: "Consultas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atualizas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PARAMETRO_CONSULTAs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    DESCRICAO = table.Column<string>(type: "TEXT", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", nullable: false),
                    VersaoID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETRO_CONSULTAs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARAMETRO_CONSULTAs_Versaos_VersaoID",
                        column: x => x.VersaoID,
                        principalTable: "Versaos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SQL_LINHAs",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NU_LINHA = table.Column<string>(type: "TEXT", nullable: false),
                    SQL = table.Column<string>(type: "TEXT", nullable: false),
                    VersaoID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SQL_LINHAs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SQL_LINHAs_Versaos_VersaoID",
                        column: x => x.VersaoID,
                        principalTable: "Versaos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Parametros",
                columns: table => new
                {
                    ID = table.Column<long>(type: "INTEGER", nullable: false),
                    NOME = table.Column<string>(type: "TEXT", nullable: false),
                    PARAMETRO_CONSULTAID = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Parametros", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Tipo_Parametros_PARAMETRO_CONSULTAs_PARAMETRO_CONSULTAID",
                        column: x => x.PARAMETRO_CONSULTAID,
                        principalTable: "PARAMETRO_CONSULTAs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assoc_usua_consus_ConsultaID",
                table: "Assoc_usua_consus",
                column: "ConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_Assoc_usua_consus_Tipo_AssociacaoID",
                table: "Assoc_usua_consus",
                column: "Tipo_AssociacaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Assoc_usua_consus_UsuarioID",
                table: "Assoc_usua_consus",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Atualizas_ConsultaID",
                table: "Atualizas",
                column: "ConsultaID");

            migrationBuilder.CreateIndex(
                name: "IX_Atualizas_UsuarioID",
                table: "Atualizas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETRO_CONSULTAs_VersaoID",
                table: "PARAMETRO_CONSULTAs",
                column: "VersaoID");

            migrationBuilder.CreateIndex(
                name: "IX_SQL_LINHAs_VersaoID",
                table: "SQL_LINHAs",
                column: "VersaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Tipo_Parametros_PARAMETRO_CONSULTAID",
                table: "Tipo_Parametros",
                column: "PARAMETRO_CONSULTAID");

            migrationBuilder.CreateIndex(
                name: "IX_Versaos_ConsultaID",
                table: "Versaos",
                column: "ConsultaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assoc_usua_consus");

            migrationBuilder.DropTable(
                name: "Atualizas");

            migrationBuilder.DropTable(
                name: "SQL_LINHAs");

            migrationBuilder.DropTable(
                name: "Tipo_Parametros");

            migrationBuilder.DropTable(
                name: "Tipo_Associacaos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "PARAMETRO_CONSULTAs");

            migrationBuilder.DropTable(
                name: "Versaos");

            migrationBuilder.DropTable(
                name: "Consultas");
        }
    }
}
