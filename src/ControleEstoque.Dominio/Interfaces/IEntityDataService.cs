﻿namespace ControleEstoque.Dominio.Interfaces;

public interface IEntityDataService<TEntity> :IDisposable where TEntity : class, new () 
{
    Task<TEntity> GetById<TId>(TId id);
    Task<IList<TEntity>> GetAll();
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task Delete(TEntity entity);
    Task Delete(Guid id);
}