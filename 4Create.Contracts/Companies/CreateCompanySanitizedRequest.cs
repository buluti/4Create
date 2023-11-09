using _4Create.Domain.Enums;

namespace _4Create.Contracts.Companies
{
    public record CreateCompanySanitizedRequest(
        string CompanyName,
        List<NewEmployee> NewEmployees,
        List<ExistingEmployee> ExistingEmployees
    )
    {
        public CreateCompanySanitizedRequest(string companyName)
            : this(companyName, new List<NewEmployee>(), new List<ExistingEmployee>()) { }

        public static CreateCompanySanitizedRequest Sanitize(CreateCompanyRequest request)
        {
            var sanitized = new CreateCompanySanitizedRequest(request.CompanyName);
            if (request.Employees == null)
                return sanitized;

            request.Employees.ForEach(e =>
            {
                if (!e.Id.HasValue
                        && !string.IsNullOrEmpty(e.Email)
                        && e.Title.HasValue)
                {
                    if(e.Title.HasValue)
                    {
                        sanitized.NewEmployees.Add(new NewEmployee(e.Email, e.Title.Value));
                    }
                }
                else if (e.Id.HasValue
                        && string.IsNullOrEmpty(e.Email)
                        && !e.Title.HasValue)
                {
                    sanitized.ExistingEmployees.Add(new ExistingEmployee(e.Id.Value));
                }
            });

            return sanitized;
        }
    }
}