using Entidade;
using CrossCutting.Models.ViewModels.Consultas;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using CrossCutting.Models.ViewModels;
using Identity.Models.AccountViewModels;
using ViewModels.Usuario;

namespace Dominio.Interfaces.Services
{
    public interface IConsultaService : IDisposable
    {
        Consulta ListarConsulta(long Id);
        MemoryStream Executar(long Id, List<Parametro> parametros);
        void InserirAsync(Cadastro cadastro);
        List<Consulta> ListarConsultas();
        IEnumerable<UsuarioViewModel> ListarUsuarios();
    }
}
