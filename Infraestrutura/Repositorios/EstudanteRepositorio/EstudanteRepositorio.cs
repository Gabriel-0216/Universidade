﻿using Dominio.Entidades;
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

    public async Task<IEnumerable<Estudante>> SelecionarTodos
        (int skip = 0, int take = 25, bool incluirEndereco = false, bool incluirTelefone = false)
    {
        IQueryable<Estudante>? consulta = _dbContext.Estudantes;
        if (incluirEndereco) consulta = consulta?.Include(p => p.Enderecos);
        if (incluirTelefone) consulta = consulta?.Include(p => p.Telefones);
        
        if(consulta is not null) return await consulta.AsNoTracking().Skip(skip).Take(take).ToListAsync();
        return Enumerable.Empty<Estudante>();
    }

    public async Task<IEnumerable<Estudante>> SelecionaComContrato(bool apenasContratoAberto = false, int skip = 0, int take = 25)
    {
        IQueryable<Estudante>? consulta = _dbContext.Estudantes;

        if(consulta is not null) return await consulta.Skip(skip).Take(take).ToListAsync();
        return Enumerable.Empty<Estudante>();
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
        if(_dbContext.Estudantes is not null) return await _dbContext.Estudantes.Where(p => p.Id == id).FirstOrDefaultAsync();
        return null;
    }
}