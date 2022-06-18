using Dominio.Entidades;

namespace Infraestrutura.Repositorios.CursoRepositorio;

public interface ICursoRepositorio : IRepositorio<Curso>
{
    Task<IEnumerable<Curso>> SelecionarCursos(int skip = 0, int take = 25);
}