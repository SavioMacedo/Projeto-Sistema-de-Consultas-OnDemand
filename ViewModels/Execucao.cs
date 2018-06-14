using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrossCutting.Models.ViewModels
{
    public class Execucao
    {
        public long Id { get; set; }
        public List<Parametro> Parametros { get; set; }
    }
}
