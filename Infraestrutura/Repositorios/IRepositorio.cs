using Dominio.Entidades;

namespace Infraestrutura.Repositorios;

public interface IRepositorio<T> where T: EntidadeBase
{
    Task<bool> Adicionar(T entity);
    Task<bool> Remover(T entity);
    Task<bool> Atualizar(T entity);
    Task<T?> SelecionarPorId(int id);
}