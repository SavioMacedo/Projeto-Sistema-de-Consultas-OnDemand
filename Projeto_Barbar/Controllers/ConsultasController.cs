using Entidade;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Barbar.Models.BLL;
using Projeto_Barbar.Models.ViewModels.Consultas;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Barbar.Controllers
{
    public class ConsultasController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        // GET: Consultas
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Consultas.ToListAsync());
        //}

        public ConsultasController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult TipoParametros()
        {
            using (Tipo_ParametrosLogics parametros = new Tipo_ParametrosLogics(_unitOfWork))
            {
                return Json(parametros.PuxarTodos());
            }
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Ver(long Id)
        {
            Consulta consulta;
            using (ConsultaLogics logica = new ConsultaLogics(_unitOfWork))
            {
                consulta = logica.ListarConsulta(Id);
            }

            return View(consulta);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync([FromBody] Cadastro cadastro)
        {
            if (ModelState.IsValid)
            {
                using (ConsultaLogics consulta_logica = new ConsultaLogics(_unitOfWork))
                {
                    await consulta_logica.InserirAsync(cadastro);
                }
                return RedirectToAction("Index");
            }

            return View(cadastro);
        }

        [HttpGet]
        public FileResult Executar(long Id, Dictionary<string,string> parametros)
        {
            using (ConsultaLogics logica = new ConsultaLogics(_unitOfWork))
            {
                string filepath = $"{logica.Executar(Id,parametros)}";
                string fileName = "Resultado.xlsx";
                byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
                return File(fileBytes, "application/x-msdownload", fileName);
            }
        }

        public FileResult Download()
        {
            string filepath = @"Temp\demo.xlsx";
            string fileName = "Resultado.xlsx";
            byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            return File(fileBytes, "application/x-msdownload", fileName);
        }

        public IActionResult Editar(long Id)
        {
            Consulta consulta;
            using (ConsultaLogics logica = new ConsultaLogics(_unitOfWork))
            {
                consulta = logica.ListarConsulta(Id);
                return View(consulta);
            }
        }
    }
}
