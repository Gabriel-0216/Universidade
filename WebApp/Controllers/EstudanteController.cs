using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels.EstudanteViewModel;

namespace WebApp.Controllers
{
    public class EstudanteController : Controller
    {
        public IActionResult Index()
        {
            var lista = new List<EstudanteVm>();
            lista.Add(new EstudanteVm(){Id = 0, Nome = "teste", Sobrenome = "Teste", DataNascimento = DateTime.Now});
            lista.Add(new EstudanteVm(){Id = 1, Nome = "teste", Sobrenome = "Teste", DataNascimento = DateTime.Now});
            lista.Add(new EstudanteVm(){Id = 2, Nome = "teste", Sobrenome = "Teste", DataNascimento = DateTime.Now});
            return View(lista);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cadastrar(EstudanteVm estudanteVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Erro de validação", "Erro");
                return View(estudanteVm);
            }
            return View(estudanteVm);
        }

        [HttpPost]
        public JsonResult Remover(int estudanteId)
        {
            return Json(new
            {
                success = true,
            });
        }

        public IActionResult Editar()
        {
            return View();
        }
    }
}