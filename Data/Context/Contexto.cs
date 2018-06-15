﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 22/10/2017 18:15:42
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Entidade;
using Dominio.Interfaces;
using Dominio.Entidades;
using Identity.Models;

namespace Infra.Data.Context
{

    public partial class Contexto : DbContext
    {

        public Contexto() :
            base()
        {
            OnCreated();
        }

        public Contexto(DbContextOptions<Contexto> options) :
            base(options)
        {
            OnCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\99003731\\Desktop\\Projeto-Sistema-de-Consultas-OnDemand-master\\database.mdf;Integrated Security=True;Connect Timeout=30");
        }

        private static string GetConnectionString(string connectionStringName)
        {
            var configurationBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            var configuration = configurationBuilder.Build();
            return configuration.GetConnectionString(connectionStringName);
        }

        partial void CustomizeConfiguration(ref DbContextOptionsBuilder optionsBuilder);
        
        public virtual DbSet<Atualiza> Atualizas
        {
            get;
            set;
        }

        public virtual DbSet<Consulta> Consultas
        {
            get;
            set;
        }

        public virtual DbSet<Versao> Versaos
        {
            get;
            set;
        }

        public virtual DbSet<SQL_LINHA> SQL_LINHAs
        {
            get;
            set;
        }

        public virtual DbSet<PARAMETRO_CONSULTA> PARAMETRO_CONSULTAs
        {
            get;
            set;
        }

        public virtual DbSet<Tipo_Parametro> Tipo_Parametros
        {
            get;
            set;
        }

        public virtual DbSet<Tipo_Associacao> Tipo_Associacaos
        {
            get;
            set;
        }

        public virtual DbSet<Assoc_usua_consu> Assoc_usua_consus
        {
            get;
            set;
        }

        public virtual DbSet<TipoBancoDados> TipoBancoDados
        {
            get;
            set;
        }

        public virtual DbSet<ApplicationUser> ApplicationUser
        {
            get;set;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.AtualizaMapping(modelBuilder);
            this.CustomizeAtualizaMapping(modelBuilder);

            this.ConsultaMapping(modelBuilder);
            this.CustomizeConsultaMapping(modelBuilder);

            this.VersaoMapping(modelBuilder);
            this.CustomizeVersaoMapping(modelBuilder);

            this.SQL_LINHAMapping(modelBuilder);
            this.CustomizeSQL_LINHAMapping(modelBuilder);

            this.PARAMETRO_CONSULTAMapping(modelBuilder);
            this.CustomizePARAMETRO_CONSULTAMapping(modelBuilder);

            this.Tipo_ParametroMapping(modelBuilder);
            this.CustomizeTipo_ParametroMapping(modelBuilder);

            this.Tipo_AssociacaoMapping(modelBuilder);
            this.CustomizeTipo_AssociacaoMapping(modelBuilder);

            this.Assoc_usua_consuMapping(modelBuilder);
            this.CustomizeAssoc_usua_consuMapping(modelBuilder);

            RelationshipsMapping(modelBuilder);
            CustomizeMapping(ref modelBuilder);
        }
    
        #region Atualiza Mapping

        private void AtualizaMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.Atualiza>().ToTable(@"Atualizas");
            modelBuilder.Entity<Entidade.Atualiza>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Atualiza>().Property<System.DateTime>(x => x.DT_ATUALIZACAO).HasColumnName(@"DT_ATUALIZACAO").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Atualiza>().Property<string>(x => x.DESCRICAO).HasColumnName(@"DESCRICAO").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Atualiza>().Property<long>(x => x.ConsultaID).HasColumnName(@"ConsultaID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Atualiza>().Property<string>(x => x.UsuarioID).HasColumnName(@"UsuarioID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Atualiza>().HasKey(@"ID");
        }
	
        partial void CustomizeAtualizaMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region Consulta Mapping

        private void ConsultaMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.Consulta>().ToTable(@"Consultas");
            modelBuilder.Entity<Entidade.Consulta>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Consulta>().Property<string>(x => x.DESCRICAO).HasColumnName(@"DESCRICAO").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Consulta>().Property<System.DateTime>(x => x.DT_CRIACAO).HasColumnName(@"DT_CRIACAO").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Consulta>().Property<string>(x => x.IC_ATIVO).HasColumnName(@"IC_ATIVO").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Consulta>().Property<string>(x => x.NOME).HasColumnName(@"NOME").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Consulta>().HasKey(@"ID");
        }
	
        partial void CustomizeConsultaMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region Versao Mapping

        private void VersaoMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.Versao>().ToTable(@"Versaos");
            modelBuilder.Entity<Entidade.Versao>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Versao>().Property<short>(x => x.NU_VERSAO).HasColumnName(@"NU_VERSAO").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Versao>().Property<System.DateTime>(x => x.DT_CRIACAO).HasColumnName(@"DT_CRIACAO").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Versao>().Property<string>(x => x.DESCRICAO).HasColumnName(@"DESCRICAO").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Versao>().Property<long>(x => x.ConsultaID).HasColumnName(@"ConsultaID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Versao>().Property<string>(x => x.IC_ATIVO).HasColumnName(@"IC_ATIVO").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Versao>().HasKey(@"ID");
        }
	
        partial void CustomizeVersaoMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region SQL_LINHA Mapping

        private void SQL_LINHAMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.SQL_LINHA>().ToTable(@"SQL_LINHAs");
            modelBuilder.Entity<Entidade.SQL_LINHA>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.SQL_LINHA>().Property<string>(x => x.NU_LINHA).HasColumnName(@"NU_LINHA").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.SQL_LINHA>().Property<string>(x => x.SQL).HasColumnName(@"SQL").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.SQL_LINHA>().Property<long>(x => x.VersaoID).HasColumnName(@"VersaoID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.SQL_LINHA>().HasKey(@"ID");
        }
	
        partial void CustomizeSQL_LINHAMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region PARAMETRO_CONSULTA Mapping

        private void PARAMETRO_CONSULTAMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().ToTable(@"PARAMETRO_CONSULTAs");
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().Property<string>(x => x.NOME).HasColumnName(@"NOME").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().Property<string>(x => x.DESCRICAO).HasColumnName(@"DESCRICAO").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().Property<long>(x => x.VersaoID).HasColumnName(@"VersaoID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().Property<long>(x => x.Tipo_ParametroID).HasColumnName(@"Tipo_ParametroID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().HasKey(@"ID");
        }
	
        partial void CustomizePARAMETRO_CONSULTAMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region Tipo_Parametro Mapping

        private void Tipo_ParametroMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.Tipo_Parametro>().ToTable(@"Tipo_Parametros");
            modelBuilder.Entity<Entidade.Tipo_Parametro>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Tipo_Parametro>().Property<string>(x => x.NOME).HasColumnName(@"NOME").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Tipo_Parametro>().Property<string>(x => x.NM_LABEL).HasColumnName(@"NM_LABEL").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Tipo_Parametro>().HasKey(@"ID");
        }
	
        partial void CustomizeTipo_ParametroMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region Tipo_Associacao Mapping

        private void Tipo_AssociacaoMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.Tipo_Associacao>().ToTable(@"Tipo_Associacaos");
            modelBuilder.Entity<Entidade.Tipo_Associacao>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Tipo_Associacao>().Property<string>(x => x.TP_ASSOC).HasColumnName(@"TP_ASSOC").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Tipo_Associacao>().HasKey(@"ID");
        }
	
        partial void CustomizeTipo_AssociacaoMapping(ModelBuilder modelBuilder);

        #endregion
    
        #region Assoc_usua_consu Mapping

        private void Assoc_usua_consuMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().ToTable(@"Assoc_usua_consus");
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().Property<long>(x => x.ID).HasColumnName(@"ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().Property<System.DateTime>(x => x.DT_CRIACAO).HasColumnName(@"DT_CRIACAO").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().Property<long>(x => x.Tipo_AssociacaoID).HasColumnName(@"Tipo_AssociacaoID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().Property<string>(x => x.UsuarioID).HasColumnName(@"UsuarioID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().Property<long>(x => x.ConsultaID).HasColumnName(@"ConsultaID").ValueGeneratedNever();
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().HasKey(@"ID");
        }
	
        partial void CustomizeAssoc_usua_consuMapping(ModelBuilder modelBuilder);

        #endregion

        #region TipoBancoDados

        private void TipoBancoDadosMapping(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoBancoDados>().ToTable("TipoBancoDados");
            modelBuilder.Entity<TipoBancoDados>().Property(x => x.ID).HasColumnName("ID").IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<TipoBancoDados>().Property(x => x.DESCRICAO).HasColumnName("Descricao").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<TipoBancoDados>().Property(x => x.ConnectionString).HasColumnName("ConnectionString").IsRequired().ValueGeneratedNever();
            modelBuilder.Entity<TipoBancoDados>().HasKey("ID");
        }

        #endregion

        private void RelationshipsMapping(ModelBuilder modelBuilder)
        {

        #region Atualiza Navigation properties

            modelBuilder.Entity<Entidade.Atualiza>().HasOne(x => x.AtualizaConsulta).WithMany(op => op.Atualizas).IsRequired(true).HasForeignKey(@"ConsultaID");

        #endregion

        #region Consulta Navigation properties

            modelBuilder.Entity<Entidade.Consulta>().HasMany(x => x.Atualizas).WithOne(op => op.AtualizaConsulta).IsRequired(true).HasForeignKey(@"ConsultaID");
            modelBuilder.Entity<Entidade.Consulta>().HasMany(x => x.Versaos).WithOne(op => op.Consulta).IsRequired(true).HasForeignKey(@"ConsultaID");
            modelBuilder.Entity<Entidade.Consulta>().HasMany(x => x.Assoc_usua_consus).WithOne(op => op.Consulta).IsRequired(true).HasForeignKey(@"ConsultaID");
            modelBuilder.Entity<Entidade.Consulta>().HasOne(x => x.TipoBancoDados).WithMany(op => op.Consultas).IsRequired(true).HasForeignKey(@"TipoBancoDadosID");

            #endregion

            #region Versao Navigation properties

            modelBuilder.Entity<Entidade.Versao>().HasOne(x => x.Consulta).WithMany(op => op.Versaos).IsRequired(true).HasForeignKey(@"ConsultaID");
            modelBuilder.Entity<Entidade.Versao>().HasMany(x => x.SQL_LINHAs).WithOne(op => op.Versao).IsRequired(true).HasForeignKey(@"VersaoID");
            modelBuilder.Entity<Entidade.Versao>().HasMany(x => x.PARAMETRO_CONSULTAs).WithOne(op => op.Versao).IsRequired(true).HasForeignKey(@"VersaoID");

        #endregion

        #region SQL_LINHA Navigation properties

            modelBuilder.Entity<Entidade.SQL_LINHA>().HasOne(x => x.Versao).WithMany(op => op.SQL_LINHAs).IsRequired(true).HasForeignKey(@"VersaoID");

        #endregion

        #region PARAMETRO_CONSULTA Navigation properties

            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().HasOne(x => x.Versao).WithMany(op => op.PARAMETRO_CONSULTAs).IsRequired(true).HasForeignKey(@"VersaoID");
            modelBuilder.Entity<Entidade.PARAMETRO_CONSULTA>().HasOne(x => x.Tipo_Parametro).WithMany(op => op.PARAMETRO_CONSULTAs).IsRequired(true).HasForeignKey(@"Tipo_ParametroID");

        #endregion

        #region Tipo_Parametro Navigation properties

            modelBuilder.Entity<Entidade.Tipo_Parametro>().HasMany(x => x.PARAMETRO_CONSULTAs).WithOne(op => op.Tipo_Parametro).IsRequired(true).HasForeignKey(@"Tipo_ParametroID");

        #endregion

        #region Tipo_Associacao Navigation properties

            modelBuilder.Entity<Entidade.Tipo_Associacao>().HasMany(x => x.Assoc_usua_consus).WithOne(op => op.Tipo_Associacao).IsRequired(true).HasForeignKey(@"Tipo_AssociacaoID");

        #endregion

        #region Assoc_usua_consu Navigation properties

            modelBuilder.Entity<Entidade.Assoc_usua_consu>().HasOne(x => x.Tipo_Associacao).WithMany(op => op.Assoc_usua_consus).IsRequired(true).HasForeignKey(@"Tipo_AssociacaoID");
            modelBuilder.Entity<Entidade.Assoc_usua_consu>().HasOne(x => x.Consulta).WithMany(op => op.Assoc_usua_consus).IsRequired(true).HasForeignKey(@"ConsultaID");

            #endregion

        #region TipoBancoDados

            modelBuilder.Entity<TipoBancoDados>().HasMany(x => x.Consultas).WithOne(a => a.TipoBancoDados).IsRequired(true).HasForeignKey(@"TipoBancoDadosID");

            #endregion

        }

        partial void CustomizeMapping(ref ModelBuilder modelBuilder);

        public bool HasChanges()
        {
            return ChangeTracker.Entries().Any(e => e.State == Microsoft.EntityFrameworkCore.EntityState.Added || e.State == Microsoft.EntityFrameworkCore.EntityState.Modified || e.State == Microsoft.EntityFrameworkCore.EntityState.Deleted);
        }

        partial void OnCreated();
    }
}
