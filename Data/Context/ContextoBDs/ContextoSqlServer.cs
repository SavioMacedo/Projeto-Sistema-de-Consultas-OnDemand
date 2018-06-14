using Dominio.Interfaces.Context;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Data.Context.ContextoDBs
{
    public partial class ContextoSqlServer : IContext
    {
        private readonly SqlConnection _sqlConnection;
        private readonly SqlCommand _comando;

        public ContextoSqlServer(string connectionString)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _comando = new SqlCommand();
            Configurar();
        }

        public void Configurar()
        {
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.Connection = _sqlConnection;
            _sqlConnection.Open();
        }

        public DbDataReader ExecutarSQL(string sql, params object[] parametros)
        {
            _comando.CommandText = sql;
            _comando.Parameters.AddRange(parametros);
            SqlDataReader retorno = _comando.ExecuteReader();
            //_sqlConnection.Close();
            return retorno;
        }

        public void Fechar()
        {
            _sqlConnection.Close();
        }
    }
}
