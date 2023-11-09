using _4Create.Application.Abstractions;
using _4Create.Contracts.Companies;
using _4Create.Domain.Entities;

namespace _4Create.Application.Members.CreateCompany;
public sealed record CreateCompanyCommand(
    string Name, 
    List<NewEmployee> newEmployees,
    List<ExistingEmployee> existingEmployees) : ICommand;
