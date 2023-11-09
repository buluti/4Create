using _4Create.Application.Abstractions;
using _4Create.Domain.Entities;
using _4Create.Domain.Errors;
using _4Create.Domain.Interfaces;
using _4Create.Domain.Shared;
namespace _4Create.Application.Members.CreateEmployee;

internal class CreateEmployeeCommandHandler : ICommandHandler<CreateEmployeeCommand>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICompanyService _companyService;

    public CreateEmployeeCommandHandler(
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork,
        ICompanyService companyService)
    {
        _employeeRepository = employeeRepository;
        _unitOfWork = unitOfWork;
        _companyService = companyService;
    }

    public async Task<Result> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        if (!_employeeRepository.IsEmailUnique(request.Email))
            return Result.Failure(DomainErrors.Member.EmailAlreadyInUse);

        List<Company> companies = _companyService.GetListOfCompaniesFromListOfGuids(request.Companies);

        var employee = new Employee(
                    request.Email,
                    request.Title,
                    companies.Where(c =>
                        _companyService.IsEmployeeTitleUniqueWithinCompany(request.Title, c.Id)).ToList()
                );

        _employeeRepository.Add(employee);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
