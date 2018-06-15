using Dominio.Interfaces.UnitOfWorkDBs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos.BancosExec
{
    public class SqlServerService : DBServiceBase
    {
        private readonly IUnitOfWorkSqlServer _unitOfWorkSqlServer;

        public SqlServerService(IUnitOfWorkSqlServer unitOfWorkSqlServer)
        {
            _unitOfWorkSqlServer = unitOfWorkSqlServer;
        }

        public void Executar(string sql)
        {
            var oi = _unitOfWorkSqlServer.FromSql(sql);
        }
    }
}
