using MediatR;

namespace Application.Queries.EstudanteQueries;

public class SelecionarEstudantesQuery : IRequest<IList<SelecionarEstudanteResposta>>
{
    public bool IncluirTelefone { get; set; } = false;
    public bool IncluirEnderecos { get; set; } = false;

    public bool ApenasContrato { get; set; } = false;
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 25;

    public SelecionarEstudantesQuery(bool incluiTelefone, bool incluiEndereco, int skip, int take)
    {
        IncluirTelefone = incluiTelefone;
        IncluirEnderecos = incluiEndereco;
        Skip = skip;
        Take = take;
    }

    public SelecionarEstudantesQuery()
    {
        
    }

    public SelecionarEstudantesQuery(bool apenasContrato, bool incluirTelefone, bool incluirEndereco, int skip, int take)
    {
        ApenasContrato = apenasContrato;
        IncluirEnderecos = incluirEndereco;
        IncluirTelefone = incluirTelefone;
        Skip = skip;
        Take = take;
    }
    
}