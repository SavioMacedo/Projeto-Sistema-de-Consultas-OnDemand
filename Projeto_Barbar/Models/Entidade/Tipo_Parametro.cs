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
    public partial class Tipo_Parametro {

        public Tipo_Parametro()
        {
            OnCreated();
        }

        public virtual long ID
        {
            get;
            set;
        }

        public virtual string NOME
        {
            get;
            set;
        }

        public virtual string NM_LABEL
        {
            get;
            set;
        }

        public virtual PARAMETRO_CONSULTA PARAMETRO_CONSULTA
        {
            get;
            set;
        }
    
        #region Extensibility Method Definitions

        partial void OnCreated();
        
        #endregion
    }

}
