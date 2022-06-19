using Application.Dtos;

namespace Application.Commands.ContratoCommands;

public class GerarContratoResponse : Response
{
    public int EstudanteId { get; set; }
    public int CursoId { get; set; }
    public int ContratoId { get; set; }
    public bool Ativo { get; set; }
    public IList<ParcelaDto> Parcela { get; set; } = new List<ParcelaDto>();

    public GerarContratoResponse()
    {
        
    }

    public void FinalizarOperacao(int estudanteId, int cursoId, int contratoId, bool ativo)
    {
        EstudanteId = estudanteId;
        CursoId = cursoId;
        ContratoId = contratoId;
        Ativo = ativo;
    }

    public void AdicionaParcela(ParcelaDto parcela)
    {
        Parcela.Add(parcela);
    }
}