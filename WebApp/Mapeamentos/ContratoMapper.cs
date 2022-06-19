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
}