using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Model;
using Projeto_Barbar.Models.ViewModel.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Projeto_Barbar.Models.BLL
{
    public class ConsultaLogics:IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public ConsultaLogics(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InserirAsync(Cadastro cadastro)
        {
            Consulta consulta = new Consulta
            {
                DESCRICAO = cadastro.Descricao,
                DT_CRIACAO = cadastro.DT_CRIACAO,
                IC_ATIVO = cadastro.IC_ATIVO,
                NOME = cadastro.Nome
            };

            _unitOfWork.GetRepository<Consulta>().Insert(consulta);
            _unitOfWork.SaveChangesAsync();

            Versao versao = new Versao
            {
                ConsultaID = consulta.ID,
                DESCRICAO = cadastro.Versao_descricao,
                NU_VERSAO = 1,
                DT_CRIACAO = cadastro.Versao_dt_criacao
            };

            _unitOfWork.GetRepository<Versao>().Insert(versao);
            _unitOfWork.SaveChangesAsync();

            List<string> SQL_Splitado = cadastro.SQL.Split("/n").ToList();

            int linha = 1;
            foreach (string sql in SQL_Splitado)
            {
                _unitOfWork.GetRepository<SQL_LINHA>().Insert( new SQL_LINHA
                {
                    NU_LINHA = linha.ToString(),
                    SQL = sql,
                    VersaoID = versao.ID
                });
                _unitOfWork.SaveChanges();

                linha++;
            }

            Assoc_usua_consu usuario_chave = new Assoc_usua_consu
            {
                ConsultaID = consulta.ID,
                DT_CRIACAO = cadastro.Assoc_dt_criacao,
                Tipo_AssociacaoID = cadastro.Assoc_tipo_usuachave,
                UsuarioID = cadastro.Usua_Chave
            };

            Assoc_usua_consu usuario_criador = new Assoc_usua_consu
            {
                ConsultaID = consulta.ID,
                DT_CRIACAO = cadastro.Assoc_dt_criacao,
                Tipo_AssociacaoID = cadastro.Assoc_tipo_criador,
                UsuarioID = cadastro.Usuario_Criador
            };

            _unitOfWork.GetRepository<Assoc_usua_consu>().Insert(usuario_chave);
            _unitOfWork.GetRepository<Assoc_usua_consu>().Insert(usuario_chave);
             await _unitOfWork.SaveChangesAsync();
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
                handle.Dispose();

            disposed = true;
        }
    }
}
