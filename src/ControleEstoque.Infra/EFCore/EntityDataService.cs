using ControleEstoque.Dominio.Interfaces;
using ControleEstoque.Infra.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ControleEstoque.Infra.EFCore;

public abstract class EntityDataService<TEntity>(ControleEstoqueDbContext dbContext) : IEntityDataService<TEntity>
    where TEntity : class, new()
{
    protected readonly ControleEstoqueDbContext Db = dbContext;
    protected readonly DbSet<TEntity> DbSet = dbContext.Set<TEntity>();

    public virtual async Task<TEntity> GetById<TId>(TId id)
    {
        return await Db.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<IList<TEntity>> GetAll()
    {
        return await Db.Set<TEntity>().AsNoTracking().ToListAsync();
    }

    public virtual async Task<TEntity> Add(TEntity entity)
    {
        var obj = Db.Add(entity);
        await SaveChangesAsync();
        return obj.Entity;
    }

    public virtual async Task<TEntity> Update(TEntity entity)
    {
        var obj = Db.Update(entity);
        await SaveChangesAsync();
        return obj.Entity;
    }

    public virtual async Task Delete(TEntity entity)
    {
        Db.Remove(entity);
        await SaveChangesAsync();
    }

    public virtual async Task Delete(Guid id)
    {
        var entity = await Db.Set<TEntity>().FindAsync(id);
        if (entity != null) await Delete(entity);
    }

    public void Dispose()
    {
        Db.Dispose();
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await Db.SaveChangesAsync();
    }
}