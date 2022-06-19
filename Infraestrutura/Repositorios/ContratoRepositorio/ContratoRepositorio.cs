using Dominio.Entidades;
using Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios.ContratoRepositorio;

public class ContratoRepositorio : IContratoRepositorio
{
    private readonly ApplicationDbContext _context;

    public ContratoRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Adicionar(Contrato entity)
    {
        if (!entity.IsValid) return false;
        _context.Add(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Remover(Contrato entity)
    {
        if (!entity.IsValid) return false;
        _context.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Atualizar(Contrato entity)
    {
        if (!entity.IsValid) return false;
        _context.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Contrato?> SelecionarPorId(int id)
    {
        if (_context.Contratos is null) return null;
        return await _context.Contratos.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IList<Contrato>> SelecionarTodos(bool quitados, bool ativos, bool incluirCurso, bool incluirEstudante, int skip = 0, int take = 25)
    {
        if (_context.Contratos is null) return new List<Contrato>();
        IQueryable<Contrato> consulta = _context.Contratos;
        if (quitados) consulta = consulta.Where(p => p.Quitado == true);
        if (ativos) consulta = consulta.Where(p => p.Ativo == true);
        if (incluirCurso) consulta = consulta.Include(p => p.Curso);
        if (incluirEstudante) consulta = consulta.Include(p => p.Estudante);
        
        return await consulta.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Contrato?> SelecionaContratoPorId(int id, bool incluirEstudante = false, bool incluirParcelas = false)
    {
        if (_context.Contratos is null) return null;
        IQueryable<Contrato> consulta = _context.Contratos;
        if (incluirEstudante) consulta = consulta.Include(p => p.Estudante);
        if (incluirParcelas) consulta = consulta.Include(p => p.Parcelas);
        return await consulta.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IList<Contrato>> SelecionarQuitados(int skip = 0, int take = 25)
    {
        if (_context.Contratos is null) return new List<Contrato>();
        return await _context.Contratos.Skip(skip).Take(take).Where(p => p.Quitado == true).ToListAsync();
    }
}