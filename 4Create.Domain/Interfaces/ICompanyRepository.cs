using _4Create.Domain.Entities;
using _4Create.Domain.Enums;

namespace _4Create.Domain.Interfaces;
public interface ICompanyRepository
{
    Company? GetById(Guid id);

    bool IsNameUnique(string name);

    void Add(Company Company);
    void UpdateCompany(Company company);
    bool IsEmployeeTitleUniqueWithinCompany(Title title, Guid companyId);
}
