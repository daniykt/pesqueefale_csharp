using Microsoft.AspNetCore.Mvc;
using Versão_SegundoSemestre.Models;

namespace Versão_SegundoSemestre.Controllers
{
    public class MenuController : Controller
    {
        private static string Theme = "light";


        [HttpPost]
        public IActionResult ToggleTheme()
        {
            Theme = Theme == "dark" ? "light" : "dark";
            return Ok($"Tema alterado para: {Theme}");
        }
    }
}
