using MediatR;

namespace Application.Commands.EstudanteCommands.DeletarEstudante;

public class DeletarEstudanteCommand : IRequest<Response>
{
    public DeletarEstudanteCommand(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}