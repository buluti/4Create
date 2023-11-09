using _4Create.Domain.Shared;
using MediatR;
using Microsoft.Extensions.Logging;

namespace _4Create.Application.Behaviour;

internal class LoggingPipelineBehaviour<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : Result
{
    private readonly ILogger<LoggingPipelineBehaviour<TRequest,TResponse>> _logger;
    public LoggingPipelineBehaviour(ILogger<LoggingPipelineBehaviour<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }
    public async Task<TResponse> Handle(
        TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Starting request {@RequestName}, {DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        var result = await next();

        if (result.IsFailure)
            _logger.LogError(
                "Request failure {@RequestName}, {@ErrorCode}:{@ErrorMessage}, {DateTimeUtc}",
            typeof(TRequest).Name,
            result.Error.Code,
            result.Error.Message,
            DateTime.UtcNow);


        _logger.LogInformation(
            "Completed request {@RequestName}, {DateTimeUtc}",
            typeof(TRequest).Name,
            DateTime.UtcNow);

        return result;
    }
}
