using Application.Commands.CursoCommands.CadastrarCurso;
using Application.Commands.CursoCommands.DeletarCurso;
using Application.Dtos;
using Application.Queries.CursoQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mapeamentos;
using WebApp.ViewModels.CursoViewModel;

namespace WebApp.Controllers
{    
    public class CursoController : Controller
    {
        private readonly IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index(bool contratos = false, int page = 20)
        {
            var consulta = new SelecionarCursosQuery(contratos, 0, page);
            var resultado = await _mediator.Send(consulta);
            if (!resultado.Any()) return View();

            var cursosMapeado = CursoMapper.MapearCursos(resultado);
            return View(cursosMapeado);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Cadastrar(CursoVm curso)
        {
            if (!ModelState.IsValid) return View(curso);
            
            var comando =
                new CadastrarCursoCommand(new CursoDto(0, curso.Nome, curso.Descricao, curso.DuracaoMeses,
                    curso.ValorTotal));
            var resultado = await _mediator.Send(comando);
            if (resultado.OperacaoSucesso()) return RedirectToAction("Index");
            
            foreach(var item in resultado.Erros)
                ModelState.AddModelError("", item.ToString());
            
            return View(curso);
        }
        [HttpPost]
        public async Task<JsonResult> Remover(int cursoId)
        {
            var comando = new RemoverCursoCommand(cursoId);
            var resultado = await _mediator.Send(comando);
            if (resultado.OperacaoSucesso())
                return Json(new {success = true});

            return Json(new
            {
                success = false,
                erros = resultado.Erros,
            });
        }
        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Editar(CursoVm curso)
        {
            return View();
        }
    }
}