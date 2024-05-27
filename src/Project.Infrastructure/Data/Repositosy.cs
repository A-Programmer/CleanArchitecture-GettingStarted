using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Project.Domain.Contracts;

namespace Project.Infrastructure.Data;

public abstract class Repository<TEntity>
    : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext Context;
    protected DbSet<TEntity> Entity;
    public Repository(ApplicationDbContext context)
    {
        this.Context = context;
        Entity = Context.Set<TEntity>();
    }

    public virtual async Task AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Entity.AddAsync(entity, cancellationToken);
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities,
        CancellationToken cancellationToken = default)
    {
        await Entity.AddRangeAsync(entities, cancellationToken);
    }

    public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return Entity.Where(predicate);
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Entity.ToListAsync(cancellationToken);
    }

    public virtual async ValueTask<TEntity> GetByIdAsync(object id,
        CancellationToken cancellationToken = default)
    {
        return await Entity.FindAsync(new[] { id }, cancellationToken);
    }

    public virtual void Remove(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public virtual void RemoveRange(IEnumerable<TEntity> entities)
    {
        Entity.RemoveRange(entities);
    }

    public virtual async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        return await Entity.SingleOrDefaultAsync(predicate, cancellationToken);
    }
    
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await Context.SaveChangesAsync(cancellationToken);
    }
}