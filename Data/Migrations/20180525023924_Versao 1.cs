using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class Versao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tipo_Associacaos",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TP_ASSOC = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Associacaos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Tipo_Parametros",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NM_LABEL = table.Column<string>(nullable: false),
                    NOME = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo_Parametros", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TipoBancoDados",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConnectionString = table.Column<string>(nullable: true),
                    DESCRICAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBancoDados", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EMAIL = table.Column<string>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    SENHA = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRICAO = table.Column<string>(nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(nullable: false),
                    IC_ATIVO = table.Column<string>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    TipoBancoDadosID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Consultas_TipoBancoDados_TipoBancoDadosID",
                        column: x => x.TipoBancoDadosID,
                        principalTable: "TipoBancoDados",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assoc_usua_consus",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsultaID = table.Column<long>(nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(nullable: false),
                    Tipo_AssociacaoID = table.Column<long>(nullable: false),
                    UsuarioID = table.Column<long>(nullable: false)
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
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsultaID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(nullable: false),
                    UsuarioID = table.Column<long>(nullable: false)
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
                name: "Versaos",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConsultaID = table.Column<long>(nullable: false),
                    DESCRICAO = table.Column<string>(nullable: false),
                    DT_CRIACAO = table.Column<DateTime>(nullable: false),
                    IC_ATIVO = table.Column<string>(nullable: false),
                    NU_VERSAO = table.Column<short>(nullable: false)
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
                name: "PARAMETRO_CONSULTAs",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DESCRICAO = table.Column<string>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    Tipo_ParametroID = table.Column<long>(nullable: false),
                    VersaoID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PARAMETRO_CONSULTAs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PARAMETRO_CONSULTAs_Tipo_Parametros_Tipo_ParametroID",
                        column: x => x.Tipo_ParametroID,
                        principalTable: "Tipo_Parametros",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
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
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NU_LINHA = table.Column<string>(nullable: false),
                    SQL = table.Column<string>(nullable: false),
                    VersaoID = table.Column<long>(nullable: false)
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
                name: "IX_Consultas_TipoBancoDadosID",
                table: "Consultas",
                column: "TipoBancoDadosID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETRO_CONSULTAs_Tipo_ParametroID",
                table: "PARAMETRO_CONSULTAs",
                column: "Tipo_ParametroID");

            migrationBuilder.CreateIndex(
                name: "IX_PARAMETRO_CONSULTAs_VersaoID",
                table: "PARAMETRO_CONSULTAs",
                column: "VersaoID");

            migrationBuilder.CreateIndex(
                name: "IX_SQL_LINHAs_VersaoID",
                table: "SQL_LINHAs",
                column: "VersaoID");

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
                name: "PARAMETRO_CONSULTAs");

            migrationBuilder.DropTable(
                name: "SQL_LINHAs");

            migrationBuilder.DropTable(
                name: "Tipo_Associacaos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Tipo_Parametros");

            migrationBuilder.DropTable(
                name: "Versaos");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "TipoBancoDados");
        }
    }
}
