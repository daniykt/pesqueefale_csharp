using Microsoft.AspNetCore.Mvc;
using Versão_SegundoSemestre.Models;

namespace Versão_SegundoSemestre.Controllers
{
    public class LoginController : Controller
    {
        [HttpPost]
        public IActionResult ResetForm()
        {
            // Simulação de reset de formulário
            return Ok("Formulário reiniciado");
        }


        [HttpPost]
        public IActionResult TogglePasswordVisibility(bool isVisible)
        {
            return Ok(isVisible ? "Senha visível" : "Senha oculta");
        }
    }
}
