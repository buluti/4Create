using _4Create.Domain.Enums;

namespace _4Create.Contracts.Employees

{
    public record CreateEmployeeResponse(
        Guid Id,
        string Email,
        Title Title,
        DateTime CreatedAt
    );
}
