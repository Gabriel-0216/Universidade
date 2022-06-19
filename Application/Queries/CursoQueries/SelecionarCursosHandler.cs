using Application.Dtos;
using Dominio.Entidades;
using Infraestrutura.Repositorios.CursoRepositorio;
using MediatR;

namespace Application.Queries.CursoQueries;

public class SelecionarCursosHandler : IRequestHandler<SelecionarCursosQuery, IList<SelecionarCursosResposta>>
{
    private readonly ICursoRepositorio _cursoRepositorio;

    public SelecionarCursosHandler(ICursoRepositorio cursoRepositorio)
    {
        _cursoRepositorio = cursoRepositorio;
    }

    public async Task<IList<SelecionarCursosResposta>> Handle(SelecionarCursosQuery request, CancellationToken cancellationToken)
    {
        var cursos = await _cursoRepositorio.SelecionarCursos();
        var enumerable = cursos as Curso[] ?? cursos.ToArray();
        return enumerable.Any() ? MapearCursos(enumerable) : new List<SelecionarCursosResposta>();
    }

    private IList<SelecionarCursosResposta> MapearCursos(IEnumerable<Curso> cursos)
    {
        return cursos.Select(item => new SelecionarCursosResposta
                    (new CursoDto(item.Id, item.Nome, item.Descricao, item.DuracaoMeses, item.ValorTotal), item.Id))
                    .ToList();
    }
}