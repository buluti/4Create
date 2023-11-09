using _4Create.Application.Members.CreateEmployee;
using _4Create.Contracts.Employees;
using _4Create.Domain.Entities;
using _4Create.Domain.Interfaces;
using _4Create.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4Create.Presentation.Controllers;

[ApiController]
[Route("/api/employees")]
public sealed class EmployeeController : ApiController
{
    public EmployeeController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CancellationToken cancellationToken, [FromBody] CreateEmployeeRequest request)
    {        
        var command = new CreateEmployeeCommand(
            request.Email, request.Title, 
            request.Companies == null ? new List<Guid>():request.Companies);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }
}
