using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tfi.Data.Context;
using Tfi.Domain.Common;
using Tfi.Domain.Repository;

namespace Tfi.Data.Repository;

public class Repository : IRepository
{
    private readonly ARContext _context;
    public Repository(ARContext context)
    {
        _context = context;
    }
    public async Task Actualizar<TEntity>(TEntity entidad) where TEntity : EntityBase
    {
        _context.Update(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task Agregar<TEntity>(TEntity entidad) where TEntity : EntityBase
    {
        await _context.Set<TEntity>().AddAsync(entidad);
        await _context.SaveChangesAsync();
    }

    public async Task Eliminar<TEntity>(TEntity entidad) where TEntity : EntityBase
    {
        _context.Set<TEntity>().Remove(entidad);
        await _context.SaveChangesAsync();
    }

    private IQueryable<TEntity> Incluir<TEntity>(IQueryable<TEntity> consulta, string[] incluidos) where TEntity : EntityBase
    {
        var incluidosConsulta = consulta;

        foreach (var incluido in incluidos)
        {
            incluidosConsulta = incluidosConsulta.Include(incluido);
        }

        return incluidosConsulta;
    }
    private IQueryable<TEntity> Incluir<TEntity>(IQueryable<TEntity> consulta, params Expression<Func<TEntity, object>>[] includes) where TEntity : EntityBase
    {
        foreach (var include in includes)
        {
            consulta = consulta.Include(include);
        }

        return consulta;
    }
    public async Task<List<TEntity>> Listar<TEntity>(Expression<Func<TEntity, bool>> predicado, params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).Where(predicado).ToListAsync();
    }

    public async Task<List<TEntity>> ListarTodos<TEntity>(params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).ToListAsync();
    }
    public async Task<List<TEntity>> ListarTodosCon<TEntity>(params Expression<Func<TEntity, object>>[] includes) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), includes).ToListAsync();
    }
    public async Task<TEntity?> ObtenerElPrimero<TEntity>(Expression<Func<TEntity, bool>> predicado, params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).FirstOrDefaultAsync(predicado);
    }
    public async Task<TEntity?> ObtenerPorId<TEntity>(int id, params string[] incluidos) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), incluidos).SingleOrDefaultAsync(e => e.Id == id);
    }
    public async Task<TEntity> ObtenerPorIdCon<TEntity>(int id, params Expression<Func<TEntity, object>>[] includes) where TEntity : EntityBase
    {
        return await Incluir(_context.Set<TEntity>(), includes).SingleOrDefaultAsync(e => e.Id == id);
    }
    public async Task<List<TEntity>> ObtenerTodos<TEntity>() where TEntity : EntityBase
    {
        return await _context.Set<TEntity>().ToListAsync();
    }
}
