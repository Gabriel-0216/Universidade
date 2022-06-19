using Application.Dtos;
using MediatR;

namespace Application.Commands.CursoCommands.CadastrarCurso;

public class CadastrarCursoCommand : IRequest<CadastrarCursoResponse>
{
    public CursoDto Curso { get; set; }

    public CadastrarCursoCommand()
    {
        
    }

    public CadastrarCursoCommand(CursoDto curso)
    {
        Curso = curso;
    }
}