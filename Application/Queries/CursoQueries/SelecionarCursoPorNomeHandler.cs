using Application.Dtos;
using Dominio.Entidades;
using Infraestrutura.Repositorios.CursoRepositorio;
using MediatR;

namespace Application.Queries.CursoQueries;

public class SelecionarCursoPorNomeHandler : IRequestHandler<SelecionarCursoPorNomeQuery, List<SelecionarCursosResposta>>
{
    private readonly ICursoRepositorio _cursoRepositorio;

    public SelecionarCursoPorNomeHandler(ICursoRepositorio cursoRepositorio)
    {
        _cursoRepositorio = cursoRepositorio;
    }

    public async Task<List<SelecionarCursosResposta>> Handle(SelecionarCursoPorNomeQuery request, CancellationToken cancellationToken)
    {
        var cursos = await _cursoRepositorio.SelecionarPorNome(request.Nome);
        return cursos.Any() ? MapearCursos(cursos) : new List<SelecionarCursosResposta>();
    }
    private List<SelecionarCursosResposta> MapearCursos(IEnumerable<Curso> cursos)
    {
        return cursos.Select(item => new SelecionarCursosResposta
                (new CursoDto(item.Id, item.Nome, item.Descricao, item.DuracaoMeses, item.ValorTotal), item.Id))
            .ToList();
    }
}