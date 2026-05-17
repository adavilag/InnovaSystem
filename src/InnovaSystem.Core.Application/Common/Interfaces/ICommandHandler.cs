using InnovaSystem.Core.Domain.Common;
using MediatR;

namespace InnovaSystem.Core.Application.Common.Interfaces
{
    public interface ICommandHandler<TCommand, TResponse>
    : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
    {
    }
}
