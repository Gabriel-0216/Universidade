using Application.Dtos;

namespace Application.Queries.CursoQueries;

public class SelecionarCursosResposta : RespostaGenerica
{
    public int Id { get; set; }
    public CursoDto Curso { get; private set; }

    public SelecionarCursosResposta()
    {
        
    }

    public SelecionarCursosResposta(CursoDto curso, int id)
    {
        Id = id;
        Curso = curso;
    }
}