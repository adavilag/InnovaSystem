using InnovaSystem.Core.Domain.Common;
using MediatR;

namespace InnovaSystem.Core.Application.Common.Interfaces
{
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
