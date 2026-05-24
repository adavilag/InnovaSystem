using InnovaSystem.CrossCutting.Models;
using MediatR;

namespace InnovaSystem.Core.Application.Common.Interfaces.CQRS
{
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
