using _4Create.Domain.Entities;
using _4Create.Domain.Enums;

namespace _4Create.Domain.Interfaces;

public interface ICompanyService
{
    List<Company> GetListOfCompaniesFromListOfGuids(List<Guid> CompanyIds);
    bool IsEmployeeTitleUniqueWithinCompany(Title title, Guid companyId);
}
