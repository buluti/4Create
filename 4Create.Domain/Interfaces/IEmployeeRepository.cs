using _4Create.Domain.Entities;

namespace _4Create.Domain.Interfaces;
public interface IEmployeeRepository
{
    Employee? GetById(Guid id);

    bool IsEmailUnique(string email);
    void Add(Employee employee);
    void AddRange(List<Employee> employee);
    void UpdateEmployee(Employee employee);
}
