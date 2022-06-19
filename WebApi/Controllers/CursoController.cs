using Application.Commands.CursoCommands.CadastrarCurso;
using Application.Commands.CursoCommands.DeletarCurso;
using Application.Queries.CursoQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CursoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> SelecionaCursos()
        {
            var consulta = new SelecionarCursosQuery();
            var resultado = await _mediator.Send(consulta);
            return resultado.Count > 0 ? Ok(resultado) : NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverCurso(int id)
        {
            var comando = new RemoverCursoCommand(id);
            var resultado = await _mediator.Send(comando);
            return resultado.OperacaoSucesso() ? Ok() : BadRequest(resultado);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarCursoCommand comando)
        {
            var resultado = await _mediator.Send(comando);
            return resultado.OperacaoSucesso() ? Ok(resultado) : BadRequest(resultado);
        }
    }
}
