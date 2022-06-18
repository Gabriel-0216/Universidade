using Application.Dtos;
using MediatR;

namespace Application.Queries.CursoQueries;

public class SelecionarCursosQuery : IRequest<IList<SelecionarCursosResposta>>
{
    public CursoDto Curso { get; set; }
}