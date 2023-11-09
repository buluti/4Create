using _4Create.Domain.Entities;
using _4Create.Domain.Enums;

namespace _4Create.Domain.Interfaces;

public interface IEmployeeService
{
    Task<Employee> AddCompanyToExistingEmployeeUsingStringId(string employeeId);
    Employee CreateNewEmployeeForNewCompany(string email, Title title, List<Company> companies);
    void AddListOfNewEmployeesWithCompany(List<Employee> newEmployees);
    void AddCompanyToEmployee(Guid employeeId, Company company);
}
