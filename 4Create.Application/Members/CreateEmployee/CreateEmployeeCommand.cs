using _4Create.Application.Abstractions;
using _4Create.Domain.Entities;
using _4Create.Domain.Enums;
using MediatR;

namespace _4Create.Application.Members.CreateEmployee;

public sealed record CreateEmployeeCommand(string Email, Title Title, List<Guid> Companies) : ICommand;

