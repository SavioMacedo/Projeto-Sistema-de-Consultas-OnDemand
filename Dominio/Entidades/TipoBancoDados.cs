using Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public partial class TipoBancoDados
    {
        public TipoBancoDados()
        {
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

        public virtual string ConnectionString
        {
            get;
            set;
        }

        public IList<Consulta> Consultas
        { get; set; }

        #region Extensibility Method Definitions

        partial void OnCreated();

        #endregion
    }
}
