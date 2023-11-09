using _4Create.Domain.Entities;
using _4Create.Domain.Enums;

namespace _4Create.Contracts.Employees
{
    public record CreateEmployeeRequest(
        string Email,
        Title Title,
        List<Guid>? Companies
    );
}
