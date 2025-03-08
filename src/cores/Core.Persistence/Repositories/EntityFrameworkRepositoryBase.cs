using System.Linq.Expressions;
using Core.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Repositories;

public class EntityFrameworkRepositoryBase<TEntity, TId, TContext>(TContext context) : IAsyncRepository<TEntity, TId>
    where TEntity : Entity<TId>
    where TContext : DbContext
{
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        context.Set<TEntity>().Entry(entity).State = EntityState.Added;
        await context.SaveChangesAsync(cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.UpdateTime = DateTime.Now;
        context.Set<TEntity>().Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        entity.IsDeleted = true;
        entity.UpdateTime = DateTime.Now;
        context.Set<TEntity>().Entry(entity).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken: cancellationToken);
        return entity;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null,
        bool enableTracking = true,
        bool include = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = context.Set<TEntity>();
        if (enableTracking is false)
            query = query.AsNoTracking();
        if (include is false)
            query = query.IgnoreAutoIncludes();
        if (filter is not null)
            query = query.Where(filter);
        return await query.ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, bool enableTracking = true,
        bool include = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = context.Set<TEntity>();
        if (enableTracking is false)
            query = query.AsNoTracking();
        if (include is false)
            query = query.IgnoreAutoIncludes();
        return await query.FirstOrDefaultAsync(predicate: filter, cancellationToken: cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true,
        CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> query = context.Set<TEntity>();
        if (enableTracking is false)
            query = query.AsNoTracking();
        if (filter is not null)
            query = query.Where(filter);
        return await query.AnyAsync(cancellationToken: cancellationToken);
    }

    public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        await context.Set<TEntity>().AddRangeAsync(entities: entities, cancellationToken: cancellationToken);
        await context.SaveChangesAsync(cancellationToken: cancellationToken);
        return entities;
    }
}