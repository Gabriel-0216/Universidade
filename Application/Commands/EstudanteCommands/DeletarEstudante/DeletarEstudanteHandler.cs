using Infraestrutura.Repositorios.EstudanteRepositorio;
using MediatR;

namespace Application.Commands.EstudanteCommands.DeletarEstudante;

public class DeletarEstudanteHandler : IRequestHandler<DeletarEstudanteCommand, Response>
{
    private readonly IEstudanteRepositorio _estudanteRepositorio;

    public DeletarEstudanteHandler(IEstudanteRepositorio estudanteRepositorio)
    {
        _estudanteRepositorio = estudanteRepositorio;
    }

    public async Task<Response> Handle(DeletarEstudanteCommand request, CancellationToken cancellationToken)
    {
        var resposta = new Response();
        try
        {
            var estudante = await _estudanteRepositorio.SelecionarPorId(request.Id);
            if (estudante is null)
            {
                resposta.AdicionaErro("Estudante não existe");
                return resposta;
            }

            var deletado = await _estudanteRepositorio.Remover(estudante);
            if (deletado) return resposta;
            resposta.AdicionaErro("A aplicação não conseguiu remover o estudante");
            return resposta;
        }
        catch (Exception ex)
        {
            resposta.AdicionaErro(ex.Message);
            return resposta;
        }
    }
}