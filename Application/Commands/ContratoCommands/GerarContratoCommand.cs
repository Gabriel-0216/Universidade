using MediatR;

namespace Application.Commands.ContratoCommands;

public class GerarContratoCommand : IRequest<GerarContratoResponse>
{
    public int CursoId { get; set; }
    public int EstudanteId { get; set; }
    public int QuantidadeParcelas { get; set; }
}