using _4Create.Domain.Primitives;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Infrastructure;

internal abstract class Repository<TEntity, TEntityId>
        where TEntity : Entity<TEntityId>
        where TEntityId : class
{
    protected readonly ApplicationDbContext _dbContext;

    protected Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual Task<TEntity?> GetByIdAsync(TEntityId id)
    {
        return _dbContext.Set<TEntity>()
            .SingleOrDefaultAsync(p => p.Id == id);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void Remove(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
}