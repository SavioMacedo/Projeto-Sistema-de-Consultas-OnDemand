using Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using OfficeOpenXml;
using Projeto_Barbar.Models.ViewModels.Consultas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
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

        public Consulta ListarConsulta (long Id)
        {
            return _unitOfWork.GetRepository<Consulta>().GetFirstOrDefault(predicate: x => x.ID == Id, include: source => source.Include(versao => versao.Versaos).ThenInclude(parametros => parametros.PARAMETRO_CONSULTAs).ThenInclude(tipo => tipo.Tipo_Parametro));
        }

        public String Executar(long Id, Dictionary<string, string> parametro_view )
        {
            long versaoID = _unitOfWork.GetRepository<Versao>().GetFirstOrDefault(predicate: filtro => filtro.ConsultaID == Id && filtro.IC_ATIVO == "Sim").ID;

            List<PARAMETRO_CONSULTA> parametros = new List<PARAMETRO_CONSULTA>(_unitOfWork.GetRepository<PARAMETRO_CONSULTA>().GetPagedList(predicate: versao => versao.VersaoID == versaoID, include: include => include.Include(tipo => tipo.Tipo_Parametro)).Items);

            string SQL = string.Join(" ", new List<string>(_unitOfWork.GetRepository<SQL_LINHA>().GetPagedList(predicate: versao => versao.VersaoID == versaoID,orderBy: order => order.OrderBy(ordena => ordena.NU_LINHA),selector: selecao => selecao.SQL).Items));

            string conexaoString = "Server=localhost\\SQLEXPRESS;Database=AdventureWorks2014;Trusted_Connection=True;";

            string sFileName = @"Temp\demo.xlsx";

            using (SqlConnection conexao = new SqlConnection(conexaoString))
            {
                using (SqlCommand comando = new SqlCommand
                {
                    CommandText = SQL,
                    CommandType = System.Data.CommandType.Text,
                    Connection = conexao
                })
                {
                    foreach (PARAMETRO_CONSULTA parametro in parametros)
                    {
                        switch (parametro.Tipo_Parametro.NM_LABEL)
                        {
                            case "number":
                                comando.Parameters.Add("@" + parametro.NOME, System.Data.SqlDbType.BigInt).Value = long.Parse(parametro_view.Where(o => o.Key == parametro.NOME).First().Value);
                                break;
                            case "date":
                                comando.Parameters.Add("@" + parametro.NOME, System.Data.SqlDbType.Date).Value = DateTime.Parse(parametro_view.Where(o => o.Key == parametro.NOME).First().Value).Date;
                                break;
                            case "datetime-local":
                                comando.Parameters.Add("@" + parametro.NOME, System.Data.SqlDbType.DateTime).Value = DateTime.Parse(parametro_view.Where(o => o.Key == parametro.NOME).First().Value);
                                break;
                            case "text":
                                comando.Parameters.Add("@" + parametro.NOME, System.Data.SqlDbType.VarChar).Value = parametro_view.Where(o => o.Key == parametro.NOME).First().Value;
                                break;
                        }
                    }

                    conexao.Open();

                    List<Dictionary<string, object>> dicionario = new List<Dictionary<string, object>>();
                    
                    FileInfo file = new FileInfo(sFileName);
                    if (file.Exists)
                    {
                        file.Delete();
                        file = new FileInfo(sFileName);
                    }

                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.HasRows)
                        {
                            using (ExcelPackage package = new ExcelPackage(file))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha1");
                                
                                int linha = 2;
                                Boolean PrimeiraVez = true;
                                while(resultado.Read())
                                {
                                    if (PrimeiraVez)
                                    {
                                        for (int i = 0; i < resultado.FieldCount; i++)
                                        {
                                            worksheet.Cells[1, i+1].Value = resultado.GetName(i);
                                            worksheet.Cells[1, i+1].Style.Font.Bold = true;
                                        }
                                        PrimeiraVez = false;
                                    }
                                    for (int i = 0; i<resultado.FieldCount;i++)
                                    {
                                        worksheet.Cells[linha, i+1].Value = resultado.GetValue(i);
                                    }
                                    linha++;
                                }

                                package.Save();
                            }
                        }
                        else
                        {
                            using (ExcelPackage package = new ExcelPackage(file))
                            {
                                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Planilha1");
                                
                                worksheet.Cells[1, 1].Value = "Esta consulta não retornou resultados.";
                                worksheet.Cells[1, 1].Style.Font.Bold = true;

                                package.Save();
                            }
                        }
                    }
                }
                conexao.Close();
            }

         return sFileName;
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
            await _unitOfWork.SaveChangesAsync();

            Versao versao = new Versao
            {
                ConsultaID = consulta.ID,
                DESCRICAO = cadastro.Versao_descricao,
                NU_VERSAO = 1,
                DT_CRIACAO = cadastro.Versao_dt_criacao,
                IC_ATIVO = "Sim"
            };

            _unitOfWork.GetRepository<Versao>().Insert(versao);
            await _unitOfWork.SaveChangesAsync();

            foreach(PARAMETRO_CONSULTA param in cadastro.Parametros)
            {
                _unitOfWork.GetRepository<PARAMETRO_CONSULTA>().Insert(new PARAMETRO_CONSULTA
                {
                    DESCRICAO = param.DESCRICAO,
                    NOME = param.NOME,
                    VersaoID = versao.ID,
                    Tipo_ParametroID = param.Tipo_ParametroID
                });

                await _unitOfWork.SaveChangesAsync();
            }
            
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
            _unitOfWork.GetRepository<Assoc_usua_consu>().Insert(usuario_criador);
             await _unitOfWork.SaveChangesAsync();
        }

        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public List<Consulta> ListarConsultas()
        {
            return new List<Consulta>(_unitOfWork.GetRepository<Consulta>().GetPagedList().Items).ToList();
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
