using MediatR;

namespace Application.Commands.CursoCommands;

public class RemoverCursoCommand : IRequest<Response>
{
    public int Id { get; set; }

    public RemoverCursoCommand()
    {
        
    }

    public RemoverCursoCommand(int id)
    {
        Id = id;
    }
}