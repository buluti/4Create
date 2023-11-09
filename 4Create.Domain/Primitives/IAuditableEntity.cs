namespace _4Create.Domain.Primitives;
public interface IAuditableEntity
{
    public DateTime CreatedAtUtc { get; set; }
}
