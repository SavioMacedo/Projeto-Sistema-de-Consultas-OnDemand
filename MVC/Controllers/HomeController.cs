using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CrossCutting.Models;
using Entidade;
using Dominio.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;

namespace CrossCutting.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IConsultaService _service;

        public HomeController(IConsultaService service )
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Consulta> consultas = _service.ListarConsultas();

            return View(consultas);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
