using Application.Queries.ContratoQueries;
using WebApp.ViewModels.ContratoViewModel;

namespace WebApp.Mapeamentos;
public static class ContratoMapper
{
    public static IList<ContratoVm> MapearContratos(IList<SelecionarContratoResposta> contratos)
    {
        return contratos.Select(item =>
            new ContratoVm(item.ContratoId, item.Ativo, item.Quitado, item.DataGeracao, item.DataAtualizacao,
                item.UsuarioAuditoria)).ToList();
    }

    public static ContratoVm MapearContratosComParcela(SelecionarContratoResposta contrato)
    {
        return new ContratoVm(contrato.ContratoId, contrato.Ativo, contrato.Quitado, contrato.DataGeracao, contrato.DataAtualizacao,
            contrato.UsuarioAuditoria, parcelas: contrato.Parcelas.Select(parcela => new ParcelaVm(parcela.Id, parcela.NumeroParcela, parcela.Valor, parcela.DataVencimento, parcela.DataCriacao, parcela.Pago)).ToList());
        
        
    }
}