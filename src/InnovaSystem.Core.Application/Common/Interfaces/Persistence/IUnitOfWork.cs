using System.Data;

namespace InnovaSystem.Core.Application.Common.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }

        IDbTransaction Transaction { get; }

        Task BeginTransactionAsync();

        Task CommitAsync();

        Task RollbackAsync();
    }
}
