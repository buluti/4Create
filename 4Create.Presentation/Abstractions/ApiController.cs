using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace _4Create.Presentation.Abstractions;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;
    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}
