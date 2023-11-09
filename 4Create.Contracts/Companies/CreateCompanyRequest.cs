using _4Create.Domain.Enums;

namespace _4Create.Contracts.Companies
{
    public record CreateCompanyRequest(
        string CompanyName,
        List<EmployeeBase>? Employees
    );

    public record EmployeeBase(
        string? Email,

        Title? Title,

        Guid? Id
    );
    public record NewEmployee(
        string Email,

        Title Title
    );
    public record ExistingEmployee(
        Guid Id
    );
}