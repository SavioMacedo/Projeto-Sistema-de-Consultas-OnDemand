﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Persistencia;
using System;

namespace Projeto_Barbar.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("Model.Assoc_usua_consu", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID");

                    b.Property<long>("ConsultaID")
                        .HasColumnName("ConsultaID");

                    b.Property<DateTime>("DT_CRIACAO")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DT_CRIACAO");

                    b.Property<long>("Tipo_AssociacaoID")
                        .HasColumnName("Tipo_AssociacaoID");

                    b.Property<long>("UsuarioID")
                        .HasColumnName("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("ConsultaID");

                    b.HasIndex("Tipo_AssociacaoID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Assoc_usua_consus");
                });

            modelBuilder.Entity("Model.Atualiza", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID");

                    b.Property<long>("ConsultaID")
                        .HasColumnName("ConsultaID");

                    b.Property<string>("DESCRICAO")
                        .IsRequired()
                        .HasColumnName("DESCRICAO");

                    b.Property<DateTime>("DT_ATUALIZACAO")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DT_ATUALIZACAO");

                    b.Property<long>("UsuarioID")
                        .HasColumnName("UsuarioID");

                    b.HasKey("ID");

                    b.HasIndex("ConsultaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Atualizas");
                });

            modelBuilder.Entity("Model.Consulta", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID");

                    b.Property<string>("DESCRICAO")
                        .IsRequired()
                        .HasColumnName("DESCRICAO");

                    b.Property<DateTime>("DT_CRIACAO")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DT_CRIACAO");

                    b.Property<string>("IC_ATIVO")
                        .IsRequired()
                        .HasColumnName("IC_ATIVO");

                    b.Property<string>("NOME");

                    b.HasKey("ID");

                    b.ToTable("Consultas");
                });

            modelBuilder.Entity("Model.PARAMETRO_CONSULTA", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID");

                    b.Property<string>("DESCRICAO")
                        .IsRequired()
                        .HasColumnName("DESCRICAO");

                    b.Property<string>("NOME")
                        .IsRequired()
                        .HasColumnName("NOME");

                    b.Property<long>("PARAMETRO_CONSULTAID");

                    b.Property<long>("Tipo_ParametroID");

                    b.Property<long>("VersaoID")
                        .HasColumnName("VersaoID");

                    b.HasKey("ID");

                    b.HasIndex("PARAMETRO_CONSULTAID");

                    b.HasIndex("VersaoID");

                    b.ToTable("PARAMETRO_CONSULTAs");
                });

            modelBuilder.Entity("Model.SQL_LINHA", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("NU_LINHA")
                        .IsRequired()
                        .HasColumnName("NU_LINHA");

                    b.Property<string>("SQL")
                        .IsRequired()
                        .HasColumnName("SQL");

                    b.Property<long>("VersaoID")
                        .HasColumnName("VersaoID");

                    b.HasKey("ID");

                    b.HasIndex("VersaoID");

                    b.ToTable("SQL_LINHAs");
                });

            modelBuilder.Entity("Model.Tipo_Associacao", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID");

                    b.Property<string>("TP_ASSOC")
                        .IsRequired()
                        .HasColumnName("TP_ASSOC");

                    b.HasKey("ID");

                    b.ToTable("Tipo_Associacaos");
                });

            modelBuilder.Entity("Model.Tipo_Parametro", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID");

                    b.Property<string>("NOME")
                        .IsRequired()
                        .HasColumnName("NOME");

                    b.HasKey("ID");

                    b.ToTable("Tipo_Parametros");
                });

            modelBuilder.Entity("Model.Usuario", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("EMAIL")
                        .IsRequired()
                        .HasColumnName("EMAIL");

                    b.Property<string>("NOME")
                        .IsRequired()
                        .HasColumnName("NOME");

                    b.Property<string>("SENHA")
                        .IsRequired()
                        .HasColumnName("SENHA");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Model.Versao", b =>
                {
                    b.Property<long>("ID")
                        .HasColumnName("ID");

                    b.Property<long>("ConsultaID")
                        .HasColumnName("ConsultaID");

                    b.Property<string>("DESCRICAO")
                        .IsRequired()
                        .HasColumnName("DESCRICAO");

                    b.Property<DateTime>("DT_CRIACAO")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("DT_CRIACAO");

                    b.Property<short>("NU_VERSAO")
                        .HasColumnName("NU_VERSAO");

                    b.HasKey("ID");

                    b.HasIndex("ConsultaID");

                    b.ToTable("Versaos");
                });

            modelBuilder.Entity("Model.Assoc_usua_consu", b =>
                {
                    b.HasOne("Model.Consulta", "Consulta")
                        .WithMany("Assoc_usua_consus")
                        .HasForeignKey("ConsultaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Tipo_Associacao", "Tipo_Associacao")
                        .WithMany("Assoc_usua_consus")
                        .HasForeignKey("Tipo_AssociacaoID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Usuario", "Usuario")
                        .WithMany("Assoc_usua_consus")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Atualiza", b =>
                {
                    b.HasOne("Model.Consulta", "AtualizaConsulta")
                        .WithMany("Atualizas")
                        .HasForeignKey("ConsultaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Usuario", "Usuario")
                        .WithMany("Atualiza")
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.PARAMETRO_CONSULTA", b =>
                {
                    b.HasOne("Model.Tipo_Parametro", "Tipo_Parametro")
                        .WithMany("PARAMETRO_CONSULTAs")
                        .HasForeignKey("PARAMETRO_CONSULTAID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Versao", "Versao")
                        .WithMany("PARAMETRO_CONSULTAs")
                        .HasForeignKey("VersaoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.SQL_LINHA", b =>
                {
                    b.HasOne("Model.Versao", "Versao")
                        .WithMany("SQL_LINHAs")
                        .HasForeignKey("VersaoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Versao", b =>
                {
                    b.HasOne("Model.Consulta", "Consulta")
                        .WithMany("Versaos")
                        .HasForeignKey("ConsultaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
