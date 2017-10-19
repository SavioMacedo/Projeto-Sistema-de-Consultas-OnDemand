﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using Projeto_Barbar.Models.BLL;
using Projeto_Barbar.Models.ViewModel.Consultas;
using System.Collections.Generic;
using System.Linq;
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

        public IActionResult Cadastrar()
        {
            using (Tipo_ParametrosLogics parametros = new Tipo_ParametrosLogics(_unitOfWork))
            {
                ViewBag.TipoParametros = parametros.PuxarTodos();
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAsync(Cadastro cadastro)
        {
           if(ModelState.IsValid)
            {
                using (ConsultaLogics consulta_logica = new ConsultaLogics(_unitOfWork))
                {
                    await consulta_logica.InserirAsync(cadastro);
                }
                return RedirectToAction("Index");
            }



            return View(cadastro);
        }

    }
}
