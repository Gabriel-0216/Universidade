using Application.Dtos;
using MediatR;

namespace Application.Queries.CursoQueries;

public class SelecionarCursosQuery : IRequest<IList<SelecionarCursosResposta>>
{
    public CursoDto Curso { get; set; }

    public bool ComContrato { get; set; } = false;

    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 25;

    public SelecionarCursosQuery()
    {
        
    }

    public SelecionarCursosQuery(bool apenasContrato = false, int skip = 0, int take = 25)
    {
        ComContrato = apenasContrato;
        Skip = skip;
        Take = take;
    }


}