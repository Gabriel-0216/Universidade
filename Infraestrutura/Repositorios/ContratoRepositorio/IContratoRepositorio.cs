using Dominio.Entidades;

namespace Infraestrutura.Repositorios.ContratoRepositorio;

public interface IContratoRepositorio : IRepositorio<Contrato>
{
    Task<IList<Contrato>> SelecionarTodos(bool quitados, bool ativos, bool incluirCurso, bool incluirEstudante, int skip = 0, int take = 25);
    Task<Contrato?> SelecionaContratoPorId(int id, bool incluirEstudante = false, bool incluirParcelas = false);
    Task<IList<Contrato>> SelecionarQuitados(int skip = 0, int take = 25);
    
}