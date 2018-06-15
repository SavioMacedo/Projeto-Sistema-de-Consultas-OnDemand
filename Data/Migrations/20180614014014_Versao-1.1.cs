using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Data.Migrations
{
    public partial class Versao11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assoc_usua_consus_Usuarios_UsuarioID",
                table: "Assoc_usua_consus");

            migrationBuilder.DropForeignKey(
                name: "FK_Atualizas_Usuarios_UsuarioID",
                table: "Atualizas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Atualizas_UsuarioID",
                table: "Atualizas");

            migrationBuilder.DropIndex(
                name: "IX_Assoc_usua_consus_UsuarioID",
                table: "Assoc_usua_consus");

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Atualizas",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<string>(
                name: "UsuarioID",
                table: "Assoc_usua_consus",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioID",
                table: "Atualizas",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "UsuarioID",
                table: "Assoc_usua_consus",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Atualizas_UsuarioID",
                table: "Atualizas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Assoc_usua_consus_UsuarioID",
                table: "Assoc_usua_consus",
                column: "UsuarioID");

            migrationBuilder.AddForeignKey(
                name: "FK_Assoc_usua_consus_Usuarios_UsuarioID",
                table: "Assoc_usua_consus",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Atualizas_Usuarios_UsuarioID",
                table: "Atualizas",
                column: "UsuarioID",
                principalTable: "Usuarios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
