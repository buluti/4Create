using _4Create.Domain.Entities;
using _4Create.Domain.Enums;
using _4Create.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _4Create.Infrastructure.Repositories;

public sealed class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _dbContext;

    public string Comment { get; set; }

    public CompanyRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Company company)
    {
        if (_dbContext.Companies == null)
            throw new ArgumentNullException(nameof(_dbContext.Companies));
        _dbContext.Companies.Add(company);
    }

    public bool IsNameUnique(string name)
    {
        if (_dbContext.Companies == null)
            throw new ArgumentNullException(nameof(_dbContext.Companies));
        return !_dbContext.Companies.Any(c => c.Name == name);
    }

    public Company? GetById(Guid id)
    {
        if (_dbContext.Companies == null)
            throw new ArgumentNullException(nameof(_dbContext.Companies));
        return _dbContext.Companies.SingleOrDefault(c => c.Id == id);
    }

    public void UpdateCompany(Company company)
    {
        if (_dbContext.Companies == null)
            throw new ArgumentNullException(nameof(_dbContext.Employees));

        _dbContext.Companies.Attach(company);
        var entry = _dbContext.Entry(company);
        entry.State = EntityState.Modified;
    }

    public bool IsEmployeeTitleUniqueWithinCompany(Title title, Guid companyId)
    {
        if (_dbContext.Companies == null)
            throw new ArgumentNullException(nameof(_dbContext.Employees));
        var company = GetById(companyId);
        if (company == null)
            return false;
        return company.Employees.Any(e => e.Title ==title);
    }
}
