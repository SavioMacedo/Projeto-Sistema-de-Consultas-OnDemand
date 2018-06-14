using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Models.ViewModels
{
    public class Parametro
    {
        public long ID
        {
            get;
            set;
        }

        public string NOME
        {
            get;
            set;
        }

        public string DESCRICAO
        {
            get;
            set;
        }

        public long Tipo_ParametroID
        {
            get;
            set;
        }
    }
}
