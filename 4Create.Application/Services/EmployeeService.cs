using _4Create.Domain.Entities;
using _4Create.Domain.Enums;
using _4Create.Domain.Interfaces;

namespace _4Create.Application.Services
{
    internal class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Task<Employee> AddCompanyToExistingEmployeeUsingStringId(string employeeId)
        {
            throw new NotImplementedException();
        }

        public void AddListOfNewEmployeesWithCompany(List<Employee> newEmployees)
        {
            _employeeRepository.AddRange(newEmployees);
        }

        public Employee CreateNewEmployeeForNewCompany(string email, Title title, List<Company> companies)
        {
            var employee = new Employee(
                Guid.NewGuid(),
                email,
                title,
                companies);

            return employee;
        }

        public void AddCompanyToEmployee(Guid employeeId, Company company)
        {
            var employee = _employeeRepository.GetById(employeeId);
            if (employee is null)
                return;

            if (!employee.Companies.Any(c => c.Id == company.Id))
            {
                employee.Companies.Add(company);
                _employeeRepository.UpdateEmployee(employee);
            }
        }
    }
}
