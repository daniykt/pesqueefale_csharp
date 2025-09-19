using Microsoft.AspNetCore.Mvc;

namespace Versão_SegundoSemestre.Controllers
{
    public class ScriptController : Controller
    {
        private static string[] navLinks = { "#home", "#sobre", "#contato" };
        private static int activeIndex = 0;


        [HttpGet]
        public IActionResult OnScroll(int scrollY)
        {
            int[,] sections = { { 0, 800 }, { 800, 600 }, { 1400, 500 } };
            int scrollPos = scrollY + 120;
            for (int i = 0; i < sections.GetLength(0); i++)
            {
                int top = sections[i, 0];
                int height = sections[i, 1];
                if (top <= scrollPos && (top + height) > scrollPos)
                {
                    activeIndex = i;
                    break;
                }
            }
            return Ok($"Link ativo: {navLinks[activeIndex]}");
        }
    }
}
