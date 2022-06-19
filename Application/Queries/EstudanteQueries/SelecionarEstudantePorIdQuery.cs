using MediatR;

namespace Application.Queries.EstudanteQueries;

public class SelecionarEstudantePorIdQuery : IRequest<SelecionarEstudanteResposta>
{
    public int Id { get; set; }
    public bool IncluirEndereco { get; set; }
    public bool IncluirTelefone { get; set; }
    public bool IncluirCursos { get; set; }
    public bool IncluirContratos { get; set; }

    public SelecionarEstudantePorIdQuery()
    {
        
    }

    public SelecionarEstudantePorIdQuery(int id, bool incluirEndereco, bool incluirTelefone,
        bool incluirCursos = false, bool incluirContratos = false)
    {
        Id = id;
        IncluirEndereco = incluirEndereco;
        IncluirTelefone = incluirTelefone;
        IncluirContratos = incluirContratos;
        IncluirCursos = incluirCursos;
    }
}