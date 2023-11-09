using _4Create.Domain.DomainEvents;
using _4Create.Domain.Enums;
using _4Create.Domain.Primitives;

namespace _4Create.Domain.Entities;

public class Employee : Entity, IAuditableEntity
{
    public Employee()
    {
    }

    public Employee(Guid id, string email, Title title)
        : base(id)
    {
        Email = email;
        Title = title;
        Companies = new List<Company>();
        CreatedAtUtc = DateTime.UtcNow;
        RaiseDomainEvent(new EmployeeCreatedDomainEvent(
            Id, Title, Email, $"new employee %{Email}% was created"));
    }
    public Employee(Guid id, string email, Title title, List<Company> companies) : base(id)
    {
        Email = email;
        Title = title;
        Companies = companies;
        CreatedAtUtc = DateTime.UtcNow;
        RaiseDomainEvent(new EmployeeCreatedDomainEvent(
            Id, Title, Email, $"new employee %{Email}% was created"));
    }

    public Employee(string email, Title title, List<Company> companies) : base(Guid.NewGuid())
    {
        Email = email;
        Title = title;
        Companies = companies;
        CreatedAtUtc = DateTime.UtcNow;
        RaiseDomainEvent(new EmployeeCreatedDomainEvent(
            Id, Title, Email, $"new employee %{Email}% was created"));
    }
    public Employee(string email, Title title, Company company) : base(Guid.NewGuid())
    {
        Email = email;
        Title = title;
        Companies = new List<Company>() { company };
        CreatedAtUtc = DateTime.UtcNow;

        RaiseDomainEvent(new EmployeeCreatedDomainEvent(
            Id, Title, Email, $"new employee %{Email}% was created"));
    }

    public string Email { get; set; }
    public Title Title { get; set; }
    public DateTime CreatedAtUtc { get; set; }
    public List<Company> Companies { get; set; } = new List<Company>();

}

