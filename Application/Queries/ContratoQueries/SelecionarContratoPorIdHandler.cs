using Application.Dtos;
using Infraestrutura.Repositorios.ContratoRepositorio;
using MediatR;

namespace Application.Queries.ContratoQueries;

public class SelecionarContratoPorIdHandler : IRequestHandler<SelecionarContratoPorIdRequest, SelecionarContratoResposta?>
{
    private readonly IContratoRepositorio _contratoRepositorio;

    public SelecionarContratoPorIdHandler(IContratoRepositorio contratoRepositorio)
    {
        _contratoRepositorio = contratoRepositorio;
    }

    public async Task<SelecionarContratoResposta?> Handle(SelecionarContratoPorIdRequest request, CancellationToken cancellationToken)
    {
        var contrato = await _contratoRepositorio.SelecionaContratoPorId(request.Id, true, true);
        if (contrato is null) return null;

        var contratoMapeado = new SelecionarContratoResposta(contrato.Id, contrato.DataCriacao,
            contrato.DataAtualizacao, contrato.UsuarioEditor, contrato.Ativo, contrato.Quitado);
        if (contrato.Parcelas is null || !contrato.Parcelas.Any()) return contratoMapeado;
        
        foreach(var parcela in contrato.Parcelas)
            contratoMapeado.AdicionarParcela(new ParcelaDto(parcela.Id, parcela.Numero, parcela.Valor,
                parcela.DataVencimento, parcela.DataCriacao, parcela.Pago));

        return contratoMapeado;

    }
    
}