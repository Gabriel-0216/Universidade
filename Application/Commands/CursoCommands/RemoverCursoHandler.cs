using Infraestrutura.Repositorios.CursoRepositorio;
using MediatR;

namespace Application.Commands.CursoCommands;

public class RemoverCursoHandler : IRequestHandler<RemoverCursoCommand, Response>
{
    private readonly ICursoRepositorio _cursoRepositorio;

    public RemoverCursoHandler(ICursoRepositorio cursoRepositorio)
    {
        _cursoRepositorio = cursoRepositorio;
    }

    public async Task<Response> Handle(RemoverCursoCommand request, CancellationToken cancellationToken)
    {
        var resposta = new Response();
        try
        {
            var curso = await _cursoRepositorio.SelecionarPorId(request.Id);
            if (curso is null)
            {
                resposta.AdicionaErro("O curso informado não existe.");
                return resposta;
            }

            var deletado = await _cursoRepositorio.Remover(curso);
            if (deletado) return resposta;
            
            resposta.AdicionaErro("Não foi possível deletar o curso.");
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.AdicionaErro(ex.Message);
            return resposta;
        }
    }
}