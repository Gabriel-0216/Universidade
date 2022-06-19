namespace Application.Commands.CursoCommands.CadastrarCurso;

public class CadastrarCursoResponse : Response
{
    public int Id { get; set; }

    public CadastrarCursoResponse()
    {
        
    }

    public CadastrarCursoResponse(int id)
    {
        Id = id;
    }

    public void SetarId(int id) => Id = id;
}