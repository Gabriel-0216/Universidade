using MediatR;

namespace Application.Queries.ContratoQueries;

public class SelecionarContratoPorIdRequest : IRequest<SelecionarContratoResposta?>
{
    public int Id { get; set; }
    public bool IncluirParcelas { get; set; }

    public SelecionarContratoPorIdRequest()
    {
        
    }

    public SelecionarContratoPorIdRequest(int id, bool incluirParcelas)
    {
        Id = id;
        IncluirParcelas = incluirParcelas;
    }
}