using MediatR;

namespace Application.Queries.ContratoQueries;

public class SelecionarContratosQuery : IRequest<IList<SelecionarContratoResposta>>
{
    public bool ApenasQuitados { get; set; } = false;
    public bool ApenasAtivos { get; set; } = false;
    public bool IncluirCurso { get; set; } = false;
    public bool IncluirEstudante { get; set; } = false;

    public SelecionarContratosQuery()
    {
        
    }

    public SelecionarContratosQuery(bool quitados, bool ativos, bool cursos, bool estudantes)
    {
        ApenasQuitados = quitados;
        ApenasAtivos = ativos;
        IncluirCurso = cursos;
        IncluirEstudante = estudantes;
    }
}