using AutoMapper;
using Dominio.Interfaces;
using Dominio.Interfaces.Servicos;
using Entidade;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Servicos
{
    public class ParametrosServices : ServiceBase,IParametrosService
    {
        public ParametrosServices(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper) { }

        public List<Tipo_Parametro> PuxarTodos()
        {
            return new List<Tipo_Parametro>(_unitOfWork.GetRepository<Tipo_Parametro>().GetPagedList());
        }
    }
}
