using Dominio.Entidades;

namespace Infraestrutura.Repositorios.EstudanteRepositorio;

public interface IEstudanteRepositorio : IRepositorio<Estudante>
{
    Task<IEnumerable<Estudante>> SelecionarTodos(int skip = 0, int take = 25, bool incluirEndereco = false, bool incluirTelefone = false);
    Task<IEnumerable<Estudante>> SelecionaComContrato(bool apenasContratoAberto = false, int skip = 0, int take = 25);
}