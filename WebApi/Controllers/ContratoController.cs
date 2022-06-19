using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ContratoCommands;
using Application.Queries.ContratoQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContratoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> GerarContrato(GerarContratoCommand comando)
        {
            var resultado = await _mediator.Send(comando);
            return resultado.OperacaoSucesso() ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarTodos()
        {
            var consulta = new SelecionarContratosQuery();
            var resultado = await _mediator.Send(consulta);
            return resultado.Any() ? Ok(resultado) : NoContent();
        }
    }
}
