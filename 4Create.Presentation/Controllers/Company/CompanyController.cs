using _4Create.Application.Members.CreateCompany;
using _4Create.Contracts.Companies;
using _4Create.Presentation.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4Create.Presentation.Controllers.Company;

[ApiController]
[Route("/api/companies")]
public sealed class CompanyController : ApiController
{
    public CompanyController(ISender sender) : base(sender)
    {
    }

    [HttpPost]
    public async Task<IActionResult> CreateCompany(CancellationToken cancellationToken, [FromBody] CreateCompanyRequest request)
    {
        var requestSanitized = CreateCompanySanitizedRequest.Sanitize(request);

        var command = new CreateCompanyCommand(
            requestSanitized.CompanyName, 
            requestSanitized.NewEmployees, 
            requestSanitized.ExistingEmployees);

        var result = await Sender.Send(command);

        return result.IsSuccess ? Ok(result) : BadRequest(result.Error);
    }

    
}
