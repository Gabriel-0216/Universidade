using Dominio.Entidades;

namespace Infraestrutura.Repositorios.EstudanteRepositorio;

public interface IEstudanteRepositorio : IRepositorio<Estudante>
{
    Task<IList<Estudante>> SelecionarTodos(int skip = 0, int take = 25, bool incluirEndereco = false, bool incluirTelefone = false);
    Task<IList<Estudante>> SelecionaComContrato(bool apenasContratoAberto = false, int skip = 0, int take = 25);

    Task<Estudante?> SelecionarEstudantePorId(int id, bool incluirEndereco = false, bool incluirTelefone = false,
        bool incluirContrato = false, bool incluirCurso = false, bool tracking = false);

    Task<IList<Estudante>> SelecionarEstudantesPorNome(string nome);
}