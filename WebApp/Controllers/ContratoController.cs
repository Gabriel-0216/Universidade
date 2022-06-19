using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Queries.ContratoQueries;
using Application.Queries.CursoQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApp.Mapeamentos;
using WebApp.Models;
using WebApp.ViewModels.ContratoViewModel;
using WebApp.ViewModels.CursoViewModel;

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
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> SelecionarEstudantePorNome(string nome)
        {
            return Json(new { });
        }

        [HttpPost]
        public async Task<JsonResult> SelecionarCursoPorNome(string nome)
        {
            var consulta = new SelecionarCursoPorNomeQuery(nome);
            var resposta = await _mediator.Send(consulta);
            if (!resposta.Any()) return Json(new {success = false, erro = "nenhum curso cadastrado."});

            var cursos = CursoMapper.MapearCursos(resposta);
            return Json(new { });
        }
    }
}