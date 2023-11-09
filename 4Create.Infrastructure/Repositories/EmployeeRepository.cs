using _4Create.Domain.Entities;
using _4Create.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Infrastructure.Repositories
{
    public sealed class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

            if (_dbContext.Employees == null)
                throw new ArgumentNullException(nameof(_dbContext.Employees));
        }

        public void Add(Employee employee)
        {
            if (_dbContext.Employees == null)
                throw new ArgumentNullException(nameof(_dbContext.Employees));

            if (IsEmailUnique(employee.Email))
                _dbContext.Employees.Add(employee);
        }

        public void AddRange(List<Employee> employees)
        {
            foreach (Employee employee in employees)
            {
                if (IsEmailUnique(employee.Email))
                    Add(employee);
            }
        }

        public Employee? GetById(Guid id)
        {
            if (_dbContext.Employees == null)
                throw new ArgumentNullException(nameof(_dbContext.Employees));
            return _dbContext.Employees.SingleOrDefault(e => e.Id == id);
        }

        public bool IsEmailUnique(string email)
        {
            if (_dbContext.Employees == null)
                throw new ArgumentNullException(nameof(_dbContext.Employees));
            return !_dbContext.Employees.Any(e => e.Email.Equals(email));
        }

        public void UpdateEmployee(Employee employee)
        {
            if (_dbContext.Employees == null)
                throw new ArgumentNullException(nameof(_dbContext.Employees));

            _dbContext.Employees.Attach(employee);
            var entry = _dbContext.Entry(employee);
            entry.State = EntityState.Modified;
        }
    }
}
