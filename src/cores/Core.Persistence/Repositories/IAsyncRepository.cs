using System.Linq.Expressions;
using Core.Persistence.Entities;
namespace Core.Persistence.Repositories;
public interface IAsyncRepository<TEntity, TId> where TEntity: Entity<TId>
{
    Task<TEntity> AddAsync(TEntity entity,CancellationToken cancellationToken=default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true, bool include = true, CancellationToken cancellationToken = default);
    Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter, bool enableTracking = true, bool include = true, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>>? filter = null, bool enableTracking = true, CancellationToken cancellationToken = default);
    Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities,CancellationToken cancellationToken = default);
}