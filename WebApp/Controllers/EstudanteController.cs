using Application.Commands.EstudanteCommands.CadastrarEstudante;
using Application.Commands.EstudanteCommands.DeletarEstudante;
using Application.Queries.EstudanteQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mapeamentos;
using WebApp.ViewModels.EstudanteViewModel;

namespace WebApp.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly IMediator _mediator;

        public EstudanteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var consulta = new SelecionarEstudantesQuery(true, false, 0, 25);
            var listaConsulta = await _mediator.Send(consulta);
            var listaMapeada = EstudanteMapper.MapearEstudantesVm(listaConsulta);
            return View(listaMapeada);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(EstudanteVm estudanteVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Erro de validação", "Erro");
                return View(estudanteVm);
            }

            var cadastrarCommando = new CriarEstudanteCommand()
            {
                Nome = estudanteVm.Nome,
                Sobrenome = estudanteVm.Sobrenome,
                DataNascimento = estudanteVm.DataNascimento,
            };
            var resultado = await _mediator.Send(cadastrarCommando);
            if (resultado.OperacaoSucesso()) return RedirectToAction("Index");

            foreach (var item in resultado.Erros)
            {
                ModelState.AddModelError("", item.ToString());
            }

            return View(estudanteVm);

        }

        [HttpPost]
        public async Task<JsonResult> Remover(int estudanteId)
        {
            var removerComando = new DeletarEstudanteCommand(estudanteId);
            var resultado = await _mediator.Send(removerComando);
            if (resultado.OperacaoSucesso())
                return Json(new
                {
                    success = true,
                });
            
            return Json(new
            {
                success = false,
                erros = resultado.Erros,
            });

        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var consulta = new SelecionarEstudantePorIdQuery(id, true, true);
            var estudante = await _mediator.Send(consulta);
            var estudanteMapeadoVm = EstudanteMapper.MapearEstudanteVm(estudante);
            return View(estudanteMapeadoVm);
        }

        [HttpGet]
        public async Task<IActionResult> Cursos(int id)
        {
            var consulta = new SelecionarEstudantePorIdQuery(id, false, false, true, false);
            var estudante = await _mediator.Send(consulta);
            var estudanteMapeado = EstudanteMapper.MapearEstudanteVm(estudante);
            return View(estudanteMapeado);
        }
        [HttpGet]
        public async Task<IActionResult> Contratos(int id)
        {
            var consulta = new SelecionarEstudantePorIdQuery(id, false, false, false, true);
            var estudante = await _mediator.Send(consulta);
            var estudanteMapeado = EstudanteMapper.MapearEstudanteVm(estudante);
            return View(estudanteMapeado);
        }
    }
}