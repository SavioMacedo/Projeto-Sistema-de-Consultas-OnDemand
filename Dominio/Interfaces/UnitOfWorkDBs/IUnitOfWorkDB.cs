using Dominio.Enums;
using System;
using System.Data.Common;

namespace Dominio.Interfaces
{
    public interface IUnitOfWorkDB : IDisposable
    {
        /// <summary>
        /// Executa os comandos SQL da aplicação.
        /// </summary>
        /// <param name="sql">SQL vindo da aplicação</param>
        /// <param name="parametros">Em caso de SQL com parametrização.</param>
        /// <returns></returns>
        DbDataReader FromSql(string sql, params object[] parametros);
        /// <summary>
        /// Auto preparar a classe unit of work para a conexão adequada dos dados.
        /// </summary>
        /// <param name="conexaoDados"></param>
        void AutoConfig(ConexaoDados conexaoDados);
        string ConnectionString { get; set; }
    }
}
