using Dominio.Interfaces.Services;
using Dominio.Interfaces.Servicos;
using Entidade;
using Microsoft.AspNetCore.Mvc;
using CrossCutting.Models.ViewModels.Consultas;
using System.Threading.Tasks;
using System.IO;
using CrossCutting.Models.ViewModels;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;
using Identity.Models;
using MVC.Extensoes;

namespace MVC.Controllers
{
    [Authorize]
    public class ConsultasController : Controller
    {
        private readonly IConsultaService _service;
        private readonly IParametrosService _parametrosService;
        
        // GET: Consultas
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Consultas.ToListAsync());
        //}

        public ConsultasController(IConsultaService service, IParametrosService parametrosService)
        {
            _service = service;
            _parametrosService = parametrosService;
        }

        public IActionResult Cadastrar()
        {
            ViewBag.Usuarios = _service.ListarUsuarios();
            ViewBag.TipoParametros = _parametrosService.PuxarTodos();

            return View();
        }

        public IActionResult Ver(long Id)
        {
            Consulta consulta = _service.ListarConsulta(Id);

            return View(consulta);
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody]Cadastro cadastro)
        {
           if(ModelState.IsValid)
            {
                cadastro.Usuario_Criador = User.Identificador();

                _service.InserirAsync(cadastro);

                return RedirectToAction("Index","Home");
            }



            return View(cadastro);
        }

        [HttpGet]
        public IActionResult Editar(long Id)
        {
            try
            {
                var entidade = _service.ListarConsulta(Id);
                return View(entidade);
            }
            catch(Exception erro)
            {
                throw erro;
            }
        }

        [HttpPost]
        public ActionResult Executar([FromBody]Execucao parametro)
        {
            string handle = Guid.NewGuid().ToString();

            MemoryStream memoryStream = _service.Executar(parametro.Id, parametro.Parametros);
            TempData[handle] = memoryStream.ToArray();

            TempData["SucessoTitulo"] = "Pronto!";
            TempData["SucessoDescricao"] = "Arquivo gerado com sucesso, o download começara em instantes!";

            return new JsonResult(new { Data = new { FileGuid = handle, FileName = $"Consulta {parametro.Id}.xlsx" } });
        }

        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                TempData["ErrorTitulo"] = "Ops!";
                TempData["ErrorDescricao"] = "Houve um problema na geração do Excel!";
                return new BadRequestResult();
            }
        }

    }
}
