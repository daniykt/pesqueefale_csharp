using Microsoft.AspNetCore.Mvc;
using Versão_SegundoSemestre.Models;

namespace Versão_SegundoSemestre.Controllers
{
    public class IndexController : Controller
    {
        [HttpGet]
        public IActionResult AnimateCounter(int index)
        {
            int[] statsTargets = { 500, 1000, 5000 };
            if (index < 0 || index >= statsTargets.Length) return BadRequest();


            int target = statsTargets[index];
            int current = 0;
            int increment = Math.Max(1, target / 100);
            while (current < target)
            {
                current += increment;
                if (current > target) current = target;
            }
            return Ok($"Contador {index}: {target}");

        }
    }
}
