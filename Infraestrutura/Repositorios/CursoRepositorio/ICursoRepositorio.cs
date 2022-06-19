using Dominio.Entidades;

namespace Infraestrutura.Repositorios.CursoRepositorio;

public interface ICursoRepositorio : IRepositorio<Curso>
{
    Task<IList<Curso>> SelecionarCursos(int skip = 0, int take = 25);
    Task<IList<Curso>> SelecionarPorNome(string nome);
}