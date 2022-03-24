using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using rastreiebrasil.Models;

namespace rastreiebrasil.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
           return View();
        }

        public IActionResult Cotacao()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cotacao(Formulario user)
        {
            FormularioRepository x = new FormularioRepository();
            x.Inserir(user);
            
            return RedirectToAction ("Cotacao");
        }
        public IActionResult Lista ()
        {
            FormularioRepository x = new FormularioRepository();
            List<Formulario> listagem = x.Listar();
            return View ("Cotacao");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
