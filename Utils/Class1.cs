using Data.Conector;
using Data.Context.ContextoDBs;
using Infra.Data.Context;
using System;

namespace Utils
{
    public class DI
    {
        public static UnitOfWorkDB<ContextoSqlServer> ConectarSqlServer()
        {
            return new UnitOfWorkDB<ContextoSqlServer>(new ContextoSqlServer());
        }
    }
}
