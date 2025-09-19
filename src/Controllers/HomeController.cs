using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Versão_SegundoSemestre.Models;

namespace Versão_SegundoSemestre.Controllers
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

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            // <- aqui você deveria validar/registrar usuário com DB. 
            // Pra efeito imediato, vamos assumir sucesso no cadastro/login:
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Email/senha inválidos.");
                return View(); // volta para a view login mostrando erros
            }

            // TODO: criar usuário / verificar credenciais / criar cookie de autenticação
            // após sucesso:
            return RedirectToAction("Home"); // redireciona para Views/Home/Home.cshtml
        }


        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Pesquisar()
        {
            return View();
        }

        public IActionResult MelhoresLocais()
        {
            return View();
        }

        public IActionResult Notificacao()
        {
            return View();
        }

        public IActionResult Sobrenos()
        {
            return View();
        }

        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
