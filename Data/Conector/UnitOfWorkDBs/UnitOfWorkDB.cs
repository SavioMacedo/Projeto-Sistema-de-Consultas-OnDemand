using Data.Context.ContextoDBs;
using Dominio.Enums;
using Dominio.Interfaces;
using Dominio.Interfaces.Context;
using Microsoft.Win32.SafeHandles;
using System;
using System.Data.Common;
using System.Runtime.InteropServices;

namespace Data.Conector
{
    public class UnitOfWorkDB : IUnitOfWorkDB
    { 
        private IContext _context;

        public UnitOfWorkDB()
        {
        }

        public void AutoConfig(ConexaoDados conexaoDados)
        {
            switch (conexaoDados)
            {
                case ConexaoDados.SQLServer:
                    ConfigurarSqlServer();
                    break;
                default:
                    throw new Exception("Enumeration inexistente.");
            }
        }

        protected void ConfigurarSqlServer()
        {
            _context = new ContextoSqlServer(ConnectionString);
        }

        public DbDataReader FromSql(string sql, params object[] parametros)
        {
            return _context.ExecutarSQL(sql, parametros);
        }


        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public string ConnectionString { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">The disposing.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // dispose the db context.
                    //_context.Fechar();
                    handle.Dispose();
                }
            }

            disposed = true;
        }
    }
}
