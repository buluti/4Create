using _4Create.Domain.Shared;
using MediatR;

namespace _4Create.Application.Abstractions;

public interface ICommand : IRequest<Result>
{}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{ }

