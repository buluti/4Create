using _4Create.Domain.Enums;
using _4Create.Domain.Primitives;

namespace _4Create.Domain.Entities;
public class SystemLog : Entity
{
    public SystemLog()
    {
    }

    public SystemLog(Guid id, Type resourceType, Event eventType, string changeset, string comment) : base(id)
    {
        ResourceType = resourceType;
        EventType = eventType;
        ChangeSet = changeset;
        Comment = comment;
    }
    public Guid Id { get; set; }
    public Type ResourceType { get; set; }
    public Event EventType { get; set; }
    public string ChangeSet { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAtUtc { get; set; }
}

