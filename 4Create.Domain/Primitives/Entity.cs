using _4Create.Domain.Interfaces;

namespace _4Create.Domain.Primitives;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected Entity(Guid id)
    {
        Id = id;
    }

    public Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; private init; }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;

        if (obj.GetType() != GetType())
            return false;


        if (obj is not Entity entity)
            return false;

        return entity.Id == Id;
    }

    public override int GetHashCode() => Id.GetHashCode();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public List<IDomainEvent> GetDomainEvents()
    {
        return _domainEvents;
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}

public abstract class Entity<TEntityId>
{
    protected Entity(TEntityId id) => Id = id;

    protected Entity()
    {
    }

    public TEntityId Id { get; init; }
}
