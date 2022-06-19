using Dominio.Entidades;
using Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;
namespace Infraestrutura.Repositorios.CursoRepositorio;

public class CursoRepositorio : ICursoRepositorio
{
    private readonly ApplicationDbContext _context;

    public CursoRepositorio(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<bool> Adicionar(Curso entity)
    {
        if (!entity.IsValid) return false;
        _context.Add(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Remover(Curso entity)
    {
        if (!entity.IsValid) return false;
        _context.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
    public async Task<bool> Atualizar(Curso entity)
    {
        if (!entity.IsValid) return false;
        _context.Update(entity);
        return await _context.SaveChangesAsync() > 0;

    }
    public async Task<Curso?> SelecionarPorId(int id)
    {
        if (_context.Cursos is null) return null;
        return await _context.Cursos.Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IList<Curso>> SelecionarCursos(int skip = 0, int take = 25)
    {
        if (_context.Cursos is null) return new List<Curso>();
        return await _context.Cursos.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IList<Curso>> SelecionarPorNome(string nome)
    {
        if (_context.Cursos is null) return new List<Curso>();
        return await _context.Cursos.AsNoTracking().Where(p => p.Nome.Contains(nome)).ToListAsync();
    }
}