using _4Create.Domain.Entities;
using _4Create.Domain.Enums;
using _4Create.Domain.Interfaces;
using _4Create.Domain.Primitives;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace _4Create.Infrastructure;
internal sealed class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _dbContext;

    public UnitOfWork(ApplicationDbContext dbContext) => _dbContext = dbContext;

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        ConverDomainEventsToSystemLog();
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntities()
    {
        IEnumerable<EntityEntry<IAuditableEntity>> entries =
            _dbContext.ChangeTracker.Entries<IAuditableEntity>();

        foreach (EntityEntry<IAuditableEntity> entityEntry in entries)
        {
            if (entityEntry.State == Microsoft.EntityFrameworkCore.EntityState.Added)
            {
                entityEntry.Property(a => a.CreatedAtUtc).CurrentValue = DateTime.UtcNow;
            }
        }
    }

    private void ConverDomainEventsToSystemLog()
    {
        var domainEvents = _dbContext.ChangeTracker
            .Entries<Entity>()
            .Select(c => c.Entity)
            .SelectMany(e =>
                {
                    var domainEvents = e.GetDomainEvents().ToList();
                    e.ClearDomainEvents();
                    return domainEvents;
                })
            .ToList();

        var systemLogs = domainEvents.Select(domainEvent => new SystemLog()
         {
             Id = Guid.NewGuid(),
             EventType = Event.Create,
             ChangeSet = JsonConvert.SerializeObject(
                domainEvent,
                new JsonSerializerSettings
                { 
                    TypeNameHandling = TypeNameHandling.All,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }),
             ResourceType = domainEvent.GetType(),
             Comment = domainEvent.Comment,
             CreatedAtUtc = DateTime.UtcNow
         }).ToList();

        if (_dbContext.SystemLogs == null)
            throw new ArgumentNullException(nameof(_dbContext.SystemLogs));

        _dbContext.SystemLogs.AddRange(systemLogs);
    }
}
