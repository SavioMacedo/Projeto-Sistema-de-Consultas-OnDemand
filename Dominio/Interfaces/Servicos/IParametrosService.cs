using Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces.Servicos
{
    public interface IParametrosService : IDisposable
    {
        List<Tipo_Parametro> PuxarTodos();
    }
}
