using _4Create.Domain.Entities;
using _4Create.Domain.Interfaces;

namespace _4Create.Domain.DomainEvents;

public sealed record CompanyCreatedDomainEvent(
    Guid Id,
    string Name,
    List<Employee> Employees,
    string CommentParam) : IDomainEvent
{
    public string Comment { get; set; } = CommentParam;
}
