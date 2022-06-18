using Application.Commands.EstudanteCommands.CadastrarEstudante;
using Application.Queries.EstudanteQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudanteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EstudanteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarEstudante([FromBody] CriarEstudanteCommand command)
        {
            var resultado = await _mediator.Send(command);
            return resultado.OperacaoSucesso() ? Ok(resultado) : BadRequest(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> SelecionarEstudantes([FromHeader] int skip = 0, int take = 25,
            bool incluirEndereco = false, bool incluirTelefone = false)
        {
            var consulta = new SelecionarEstudantesQuery(incluirTelefone, incluirEndereco, skip, take);
            var resposta = await _mediator.Send(consulta);
            return resposta.Count > 0 ? Ok(resposta) : NoContent();
        }
    }
}