using _4Create.Domain.DomainEvents;
using _4Create.Domain.Primitives;

namespace _4Create.Domain.Entities;
public class Company : Entity, IAuditableEntity
{
    public Company()
    {
        CreatedAtUtc = DateTime.UtcNow;
        Employees = new List<Employee>();
        RaiseDomainEvent(new CompanyCreatedDomainEvent(
             Id, Name, Employees, $"new company %{Name}% was created"));
    }

    public Company(Guid id, string name) : base(id)
    {
        Name = name;
        CreatedAtUtc = DateTime.UtcNow;
        Employees = new List<Employee>();
        RaiseDomainEvent(new CompanyCreatedDomainEvent(
             Id, Name, Employees, $"new company %{Name}% was created"));
    }
    public Company(string name) : base(Guid.NewGuid())
    {
        Name = name;
        CreatedAtUtc = DateTime.UtcNow;
        Employees = new List<Employee>();
        RaiseDomainEvent(new CompanyCreatedDomainEvent(
             Id, Name, Employees, $"new company %{Name}% was created"));
    }
    public string Name { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public List<Employee> Employees { get; set; } = new List<Employee>();
}