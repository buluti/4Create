using _4Create.Application.Abstractions;
using _4Create.Domain.Entities;
using _4Create.Domain.Interfaces;
using _4Create.Domain.Shared;

namespace _4Create.Application.Members.CreateCompany;

internal sealed class CreateCompanyCommandHandler : ICommandHandler<CreateCompanyCommand>
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IEmployeeService _employeeService;

    public CreateCompanyCommandHandler(
        ICompanyRepository companyRepository,
        IUnitOfWork unitOfWork,
        IEmployeeService employeeService)
    {
        _companyRepository = companyRepository;
        _unitOfWork = unitOfWork;
        _employeeService = employeeService;
    }

    public async Task<Result> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        // 1. check if the company name is unique
        if (!_companyRepository.IsNameUnique(request.Name))
            return Result.Failure(
                new Error("CreateCompany.NameIsNotUnique", "The name you have specified already exists"));

        // 2. create new company    
        var company = new Company(request.Name);
        _companyRepository.Add(company);

        // 3. get the new employees list

        List<Employee> newEmployees = new List<Employee>();
        request.newEmployees
            .ForEach(employee =>
            {
                newEmployees.Add(new Employee(
                        employee.Email,
                        employee.Title,
                        company
                    ));
            });

        // 4. add new employees        
        _employeeService.AddListOfNewEmployeesWithCompany(newEmployees);

        // 5. get the existing employees list
        List<string> existingEmployeesStringList = new List<string>();

        request.existingEmployees
            .ForEach(employee =>
            {
                _employeeService.AddCompanyToEmployee(employee.Id, company);
            });

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}

