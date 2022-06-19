using MediatR;

namespace Application.Queries.CursoQueries;

public class SelecionarCursoPorNomeQuery : IRequest<List<SelecionarCursosResposta>>
{
    public SelecionarCursoPorNomeQuery()
    {
        
    }

    public SelecionarCursoPorNomeQuery(string nome)
    {
        Nome = nome;
    }
    public string Nome { get; set; } = string.Empty;
}