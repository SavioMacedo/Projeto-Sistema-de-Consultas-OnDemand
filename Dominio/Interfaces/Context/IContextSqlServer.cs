using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Dominio.Interfaces.Context
{
    public interface IContext
    {
        void Configurar();
        /// <summary>
        /// Executar SQL passado por parametros para excução.
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        DbDataReader ExecutarSQL(string sql, params object[] parametros);
        void Fechar();
    }
}
