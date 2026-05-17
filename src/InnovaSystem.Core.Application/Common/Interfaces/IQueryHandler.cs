using InnovaSystem.Core.Domain.Common;
using MediatR;

namespace InnovaSystem.Core.Application.Common.Interfaces
{
    public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>
    {
    }
}
