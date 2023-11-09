using _4Create.Contracts.Employees;
using _4Create.Domain.Entities;
using _4Create.Domain.Enums;
using _4Create.Domain.Interfaces;

namespace _4Create.Application.Services;

sealed class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public List<Company> GetListOfCompaniesFromListOfGuids(List<Guid> companyIds)
    {
        List<Company> companies = new List<Company>();
        foreach (var companyId in companyIds)
        {
            var company = _companyRepository.GetById(companyId);
            if (company is not null)
                companies.Add(company);
        }

        return companies;
    }

    public bool IsEmployeeTitleUniqueWithinCompany(Title title, Guid companyId)
    {
        return _companyRepository.IsEmployeeTitleUniqueWithinCompany(title, companyId);
    }
}
