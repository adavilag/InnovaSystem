using InnovaSystem.CrossCutting.Models;
using MediatR;

namespace InnovaSystem.Core.Application.Common.Interfaces.CQRS
{
    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    {
    }
}
