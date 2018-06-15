using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dominio.Interfaces;
using Dominio.Interfaces.Services;
using Entidade;
using OfficeOpenXml;
using CrossCutting.Models.ViewModels.Consultas;
using Dominio.Enums;
using System.Data.Common;
using Dominio.Entidades;
using CrossCutting.Models.ViewModels;
using Identity.Models.AccountViewModels;
using Identity.Models;
using Identity.Data;
using AutoMapper;
using ViewModels.Usuario;

namespace Dominio.Servicos
{
    public class ConsultaService : ServiceBase, IConsultaService
    {
        private readonly IUnitOfWorkDB _unitOfWorkDB;

        public ConsultaService(IUnitOfWork unitOfWork, IUnitOfWorkDB unitOfWorkDB, IMapper mapper) : base(unitOfWork, mapper)
        {
            _unitOfWorkDB = unitOfWorkDB;
        }

        public Consulta ListarConsulta(long Id)
        {
            return _unitOfWork.GetRepository<Consulta>().GetFirstOrDefault(predicate: x => x.ID == Id, includeProperties: "Versaos,Versaos.PARAMETRO_CONSULTAs,Versaos.PARAMETRO_CONSULTAs.Tipo_Parametro");
        }

        public List<Consulta> ListarConsultas()
        {
            return new List<Consulta>(_unitOfWork.GetRepository<Consulta>().GetPagedList()).ToList();
        }

        public MemoryStream Executar(long Id, List<Parametro> _parametros)
        {
            string dependenciasConsulta = "Versaos,Versaos.PARAMETRO_CONSULTAs,Versaos.SQL_LINHAs,TipoBancoDados";

            Consulta Consulta = _unitOfWork.GetRepository<Consulta>().GetFirstOrDefault(predicate: filtro => filtro.ID == Id, includeProperties: dependenciasConsulta);
            TipoBancoDados TipoBancoDados = Consulta.TipoBancoDados;
            Versao Versao = Consulta.Versaos.Where(predicate: filtro => filtro.IC_ATIVO == "Sim").FirstOrDefault();
            List<PARAMETRO_CONSULTA> parametros = Versao.PARAMETRO_CONSULTAs.ToList();

            string SQL = string.Join(" ", Versao.SQL_LINHAs.OrderBy(a => a.NU_LINHA).Select(select => select.SQL));
            
            Enum.TryParse(TipoBancoDados.DESCRICAO, out ConexaoDados conexaoDados);

            List<DbParameter> _params = new List<DbParameter>();
            foreach(Parametro param in _parametros)
            {
                if (!String.IsNullOrEmpty(param.DESCRICAO))
                {
                    _params.Add(new SqlParameter()
                    {
                        ParameterName = param.NOME,
                        SqlDbType = System.Data.SqlDbType.NVarChar,
                        Direction = System.Data.ParameterDirection.Input,
                        Value = param.DESCRICAO
                    });
                }
            }

            _unitOfWorkDB.ConnectionString = TipoBancoDados.ConnectionString;
            _unitOfWorkDB.AutoConfig(conexaoDados);
            
            SqlDataReader _resultado = (SqlDataReader) _unitOfWorkDB.FromSql(SQL, _params.ToArray());

            MemoryStream stream = new MemoryStream();

            if (_resultado.HasRows)
            {
                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Resultado");

                    int linha = 2;
                    Boolean PrimeiraVez = true;
                    while (_resultado.Read())
                    {
                        if (PrimeiraVez)
                        {
                            for (int i = 0; i < _resultado.FieldCount; i++)
                            {
                                worksheet.Cells[1, i + 1].Value = _resultado.GetName(i);
                                worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                            }
                            PrimeiraVez = false;
                        }
                        for (int i = 0; i < _resultado.FieldCount; i++)
                        {
                            worksheet.Cells[linha, i + 1].Value = _resultado.GetValue(i);
                        }
                        linha++;
                    }

                    package.Save();
                }
            }

            return stream;
        }

        public void InserirAsync(Cadastro cadastro)
        {
            Consulta consulta = new Consulta
            {
                DESCRICAO = cadastro.Descricao,
                DT_CRIACAO = cadastro.DT_CRIACAO,
                IC_ATIVO = cadastro.IC_ATIVO,
                NOME = cadastro.Nome,
                TipoBancoDadosID = 1
            };

            _unitOfWork.GetRepository<Consulta>().Insert(consulta);

            _unitOfWork.SaveChanges();

            Versao versao = new Versao
            {
                ConsultaID = consulta.ID,
                DESCRICAO = cadastro.Versao_descricao,
                NU_VERSAO = 1,
                DT_CRIACAO = cadastro.Versao_dt_criacao,
                IC_ATIVO = "Sim"
            };

            _unitOfWork.GetRepository<Versao>().Insert(versao);

            _unitOfWork.SaveChanges();

            String[] parametro = { "\n" };

            List<string> SQL_Splitado = cadastro.SQL.Split(parametro, StringSplitOptions.RemoveEmptyEntries).ToList();

            int linha = 1;
            foreach (string sql in SQL_Splitado)
            {
                _unitOfWork.GetRepository<SQL_LINHA>().Insert(new SQL_LINHA
                {
                    NU_LINHA = linha.ToString(),
                    SQL = sql,
                    VersaoID = versao.ID
                });
                _unitOfWork.SaveChanges();

                linha++;
            }

            foreach(var param in cadastro.Parametros)
            {
                _unitOfWork.GetRepository<PARAMETRO_CONSULTA>().Insert(new PARAMETRO_CONSULTA {
                    DESCRICAO = param.DESCRICAO,
                    NOME = param.NOME,
                    Tipo_ParametroID = param.Tipo_ParametroID,
                    VersaoID = versao.ID
                });
                _unitOfWork.SaveChanges();
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
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<UsuarioViewModel> ListarUsuarios()
        {
            try
            {
                var entidades = _unitOfWork.FromSql<ApplicationUser>("select * from dbo.AspNetUsers").ToList();
                var viewModels =  _mapper.Map<IEnumerable<UsuarioViewModel>>(entidades);

                return viewModels;
            }
            catch(Exception erro)
            {
                throw erro;
            }

        }
    }
}
