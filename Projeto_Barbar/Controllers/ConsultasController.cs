using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using Projeto_Barbar.Models.BLL;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult Cadastrar()
        {
            using (Tipo_ParametrosLogics parametros = new Tipo_ParametrosLogics(_unitOfWork))
            {
                ViewBag.TipoParametros = parametros.PuxarTodos();
            }

            return View();
        }

    }
}
