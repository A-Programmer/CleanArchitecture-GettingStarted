using System.Linq.Expressions;

namespace Project.Domain.Contracts;

public interface IRepository<TEntity> where TEntity : class
{
    ValueTask<TEntity> GetByIdAsync(object id,
        CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);

    Task AddAsync(TEntity entity,
        CancellationToken cancellationToken = default);
    
    Task AddRangeAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default);

    void Remove(TEntity entity);
    
    void RemoveRange(IEnumerable<TEntity> entities);

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}