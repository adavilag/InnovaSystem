using InnovaSystem.CrossCutting.Models;
using MediatR;

namespace InnovaSystem.Core.Application.Common.Interfaces.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
    {
    }
}
