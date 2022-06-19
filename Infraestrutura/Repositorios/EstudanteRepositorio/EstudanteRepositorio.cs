using Dominio.Entidades;
using Infraestrutura.Persistencia;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorios.EstudanteRepositorio;

public class EstudanteRepositorio : IEstudanteRepositorio
{
    private readonly ApplicationDbContext _dbContext;

    public EstudanteRepositorio(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IList<Estudante>> SelecionarTodos
        (int skip = 0, int take = 25, bool incluirEndereco = false, bool incluirTelefone = false)
    {
        IQueryable<Estudante>? consulta = _dbContext.Estudantes;
        if (incluirEndereco) consulta = consulta?.Include(p => p.Enderecos);
        if (incluirTelefone) consulta = consulta?.Include(p => p.Telefones);
        
        if(consulta is not null) return await consulta.AsNoTracking().Skip(skip).Take(take).ToListAsync();
        return new List<Estudante>();
    }

    public async Task<IList<Estudante>> SelecionaComContrato(bool apenasContratoAberto = false, int skip = 0, int take = 25)
    {
        IQueryable<Estudante>? consulta = _dbContext.Estudantes;

        if(consulta is not null) return await consulta.Skip(skip).Take(take).ToListAsync();
        return new List<Estudante>();
    }

    public async Task<Estudante?> SelecionarEstudantePorId(int id, bool incluirEndereco = false, bool incluirTelefone = false,
        bool incluirContrato = false, bool incluirCurso = false, bool tracking = false)
    {
        if (_dbContext.Estudantes is null) return null;
        
        IQueryable<Estudante> consulta = _dbContext.Estudantes;
        if (incluirEndereco) consulta = consulta.Include(p => p.Enderecos);
        if (incluirTelefone) consulta = consulta.Include(p => p.Telefones);
        if (incluirContrato) consulta = consulta.Include(p => p.Contratos);
        if (incluirCurso) consulta = consulta.Include(p => p.Contratos)!.ThenInclude(p=> p.Curso);
        if (!tracking) consulta = consulta.AsNoTracking();

        return await consulta.Where(p => p.Id == id).FirstOrDefaultAsync();


    }

    public async Task<IList<Estudante>> SelecionarEstudantesPorNome(string nome)
    {
        if (_dbContext.Estudantes is null) return new List<Estudante>();
        return await _dbContext.Estudantes
            .Where(p => p.Nome.Contains(nome) ||
                        p.Sobrenome.Contains(nome))
            .ToListAsync();
    }

    public async Task<bool> Adicionar(Estudante entity)
    {
        if (!entity.IsValid) return false;
        _dbContext.Add(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Remover(Estudante entity)
    {
        if (!entity.IsValid) return false;
        _dbContext.Remove(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> Atualizar(Estudante entity)
    {
        if (!entity.IsValid) return false;
        _dbContext.Update(entity);
        return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<Estudante?> SelecionarPorId(int id)
    {
        if(_dbContext.Estudantes is not null) 
            return await _dbContext.Estudantes.Where(p => p.Id == id)
            .Include(p=> p.Enderecos)
            .Include(p=> p.Telefones)
            .FirstOrDefaultAsync();
        return null;
    }
}