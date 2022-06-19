using Application.Dtos;
using MediatR;

namespace Application.Queries.ContratoQueries;

public class SelecionarContratoResposta
{
    public int ContratoId { get; set; }
    public DateTime DataGeracao { get; set; }
    public DateTime DataAtualizacao { get; set; }
    public string UsuarioAuditoria { get; set; } = string.Empty;
    public CursoDto Curso { get; set; }
    public EstudanteDto Estudante { get; set; }
    public IList<ParcelaDto> Parcelas { get; set; } = new List<ParcelaDto>();
    public bool Ativo { get; set; }
    public bool Quitado { get; set; }
    public int QuantidadeParcelas { get; set; }

    public SelecionarContratoResposta()
    {
        
    }

    public SelecionarContratoResposta(int contratoId, DateTime dataGeracao, DateTime dataAtualizacao, string usuarioAuditoria,
        bool ativo, bool quitado)
    {
        ContratoId = contratoId;
        DataGeracao = dataGeracao;
        DataAtualizacao = dataAtualizacao;
        UsuarioAuditoria = usuarioAuditoria;
        Ativo = ativo;
        Quitado = quitado;
    }
    
}