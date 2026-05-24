using InnovaSystem.CrossCutting.Models;
using MediatR;

namespace InnovaSystem.Core.Application.Common.Interfaces.CQRS
{
    public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    {
    }
}
