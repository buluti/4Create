using _4Create.Domain.Entities;
using _4Create.Domain.Enums;
using _4Create.Domain.Interfaces;

namespace _4Create.Domain.DomainEvents;

public sealed record EmployeeCreatedDomainEvent (
    Guid Id,
    Title Title,
    string Email,
    string CommentParam
): IDomainEvent
{
    public string Comment { get; set; } = CommentParam;
}
