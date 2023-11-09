using _4Create.Domain.Shared;
using MediatR;

namespace _4Create.Application.Abstractions;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TRespone>
    : IRequestHandler<TCommand, Result<TRespone>>
    where TCommand : ICommand<TRespone>
{
}