using Infraestrutura.Repositorios.ContratoRepositorio;
using MediatR;

namespace Application.Queries.ContratoQueries;

public class SelecionarContratoHandler : IRequestHandler<SelecionarContratosQuery, IList<SelecionarContratoResposta>>
{
    private readonly IContratoRepositorio _contratoRepositorio;

    public SelecionarContratoHandler(IContratoRepositorio contratoRepositorio)
    {
        _contratoRepositorio = contratoRepositorio;
    }

    public async Task<IList<SelecionarContratoResposta>> Handle(SelecionarContratosQuery request, CancellationToken cancellationToken)
    {
        var consulta = await _contratoRepositorio.SelecionarTodos(request.ApenasQuitados, request.ApenasAtivos, request.IncluirCurso, request.IncluirEstudante,0, 25);
        if(consulta.Any())
            return consulta.Select(item => new SelecionarContratoResposta(item.Id, item.DataCriacao,
                item.DataAtualizacao, item.UsuarioEditor, item.Ativo, item.Quitado)).ToList();

        return new List<SelecionarContratoResposta>();
    }
}