using ControleEstoque.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.EFCore;

public abstract class EntityDataService<TEntity>(DbContext dbContext) : IEntityDataService<TEntity>
    where TEntity : class, new()
{
    private readonly DbContext _dbContext = dbContext;

    public virtual async Task<TEntity> GetById<TId>(TId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        var obj = _dbContext.Add(entity);
        await _dbContext.SaveChangesAsync();
        return obj.Entity;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        var obj = _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return obj.Entity;
    }

    public virtual async Task Delete(TEntity entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task Delete(Guid id)
    {
        var entity = await _dbContext.Set<TEntity>().FindAsync(id);
        if (entity != null) await Delete(entity);
    }
}