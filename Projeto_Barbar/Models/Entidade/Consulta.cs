﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Entity Developer tool using EF Core template.
// Code is generated on: 22/10/2017 17:47:49
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Data;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;

namespace Entidade
{
    public partial class Consulta {

        public Consulta()
        {
            this.Atualizas = new List<Atualiza>();
            this.Versaos = new List<Versao>();
            this.Assoc_usua_consus = new List<Assoc_usua_consu>();
            OnCreated();
        }

        public virtual long ID
        {
            get;
            set;
        }

        public virtual string DESCRICAO
        {
            get;
            set;
        }

        public virtual System.DateTime DT_CRIACAO
        {
            get;
            set;
        }

        public virtual string IC_ATIVO
        {
            get;
            set;
        }

        public virtual string NOME
        {
            get;
            set;
        }

        public virtual IList<Atualiza> Atualizas
        {
            get;
            set;
        }

        public virtual IList<Versao> Versaos
        {
            get;
            set;
        }

        public virtual IList<Assoc_usua_consu> Assoc_usua_consus
        {
            get;
            set;
        }
    
        #region Extensibility Method Definitions

        partial void OnCreated();
        
        #endregion
    }

}
