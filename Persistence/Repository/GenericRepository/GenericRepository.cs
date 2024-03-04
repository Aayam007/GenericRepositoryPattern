using Microsoft.EntityFrameworkCore;
using Persistence.Interfaces.GenericRepository;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Persistence.Repository.GenericRepository
{

public class GenericRepository<T> : IGenericRepository<T> where T : class, new()
{
    public readonly DbContext Context;

    public GenericRepository(DbContext dbContext)
    {
        Context = dbContext;
    }

    public async Task<T> InsertAsync(T entity)
    {
        Context.Attach(entity);
        var entityEntry = await Context.Set<T>().AddAsync(entity);

        await SaveDatabaseAsync();

        return entityEntry.Entity;
    }

    public async Task<T> FindByIdAsync(object primaryKey)
    {
        var entity = await Context.Set<T>().FindAsync(primaryKey);

        return entity;
    }

    public async Task<T> FindAsync(Expression<Func<T, bool>> whereClause)
    {
        var entity = await Context.Set<T>().FirstOrDefaultAsync(whereClause);

        if (entity != null)
        {
            return entity;
        }

        return new T();
    }

    public async Task<IEnumerable<T>> FindAllAsync()
    {
        var entity = await Context.Set<T>().ToListAsync();

        if (entity != null)
        {
            return (IEnumerable<T>)entity;
        }

        return new List<T>();
    }

    public async Task DeleteAsync(T entity, Func<T, bool> predicate = default!)
    {

        Context.Set<T>().Remove(entity);

        await SaveDatabaseAsync();
    }

    public async Task UpdateAsync(T entity, Func<T, bool> predicate = default!)
    {

        Context.Set<T>().Update(entity);

        await SaveDatabaseAsync();
    }

    private async Task SaveDatabaseAsync()
    {
        await Context.SaveChangesAsync();
    }

}
}

