using ControleMedicamentos.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ControleMedicamentos.Controllers
{
    [PaginaParaUsuarioLogado]
    public class RestritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
