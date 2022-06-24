using Application.Queries.ContratoQueries;
using Application.Queries.CursoQueries;
using Application.Queries.EstudanteQueries;
using MediatR;
using Negocios.Configuracoes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Negocios.Dtos;
using Negocios.Regras;
using WebApp.Mapeamentos;
using WebApp.ViewModels.ContratoViewModel;

namespace WebApp.Controllers
{
    public class ContratoController : Controller
    {
        private readonly IMediator _mediator;

        public ContratoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index(bool quitados = false, bool ativos = false, int? pag = 20)
        {
            var consulta = new SelecionarContratosQuery(quitados, ativos, false, false);
            var resposta = await _mediator.Send(consulta);
            if (!resposta.Any()) return View(new List<ContratoVm>());

            var contratosMapeados = ContratoMapper.MapearContratos(resposta);
            return View(contratosMapeados);
        }

        [HttpGet]
        public async Task<IActionResult> GerarContrato(int estudanteId)
        { //Colocar a geração de contrato via Woerker
            //refatorar a busca de cursos
            //ToDo LAYOUT DA TELA
            var estudanteConsulta = new SelecionarEstudantePorIdQuery(estudanteId, false, false);
            var estudante = await _mediator.Send(estudanteConsulta);
            var model = new GerarContratoVm(estudanteId, EstudanteMapper.MapearEstudanteVm(estudante));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GerarContrato(GerarContratoVm contratoVm)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Erro", "Erro de validação");
                return View(contratoVm);
            }

            var regraGeracaoContrato = new GerarContrato();
            var enviado = regraGeracaoContrato.EnviarMensagem(new GeracaoContratoDto()
            {
                QuantidadeParcelas = contratoVm.QuantidadeParcelas,
                CursoId = contratoVm.CursoId,
                EstudanteId = contratoVm.EstudanteId
            });
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<JsonResult> SelecionarEstudantePorNome(string nome)
        {
            return Json(new { });
        }
        [HttpGet]
        public async Task<JsonResult> SelecionarCursoPorNome(string? nome = "")
        {//ToDo LAYOUT DA TELA
            var consulta = new SelecionarCursoPorNomeQuery(nome);
            var resposta = await _mediator.Send(consulta);
            if (!resposta.Any()) return Json(new {success = false, erro = "nenhum curso cadastrado."});

            var cursos = CursoMapper.MapearCursos(resposta);
            return Json(new
            {
                data = cursos
            });
        }
        [HttpGet]
        public async Task<IActionResult> Mensalidades(int id)
        {
            var selecionarParcelasContrato = new SelecionarContratoPorIdRequest(id, true);
            var resultadoOperacao = await _mediator.Send(selecionarParcelasContrato);
            if (resultadoOperacao is null) return View(new ContratoVm());

            var contratosMapeados = ContratoMapper.MapearContratosComParcela(resultadoOperacao);
            return View(contratosMapeados);
        }
    }
}