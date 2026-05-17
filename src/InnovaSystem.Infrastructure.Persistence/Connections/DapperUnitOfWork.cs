using InnovaSystem.Core.Application.Common.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnovaSystem.Infrastructure.Persistence.Connections
{
    public class DapperUnitOfWork : IUnitOfWork
    {
        public IDbConnection Connection { get; }

        public IDbTransaction Transaction { get; private set; } = default!;

        public DapperUnitOfWork(
            ISqlConnectionFactory connectionFactory)
        {
            Connection = connectionFactory.CreateConnection();
        }

        public async Task BeginTransactionAsync()
        {
            if (Connection.State == ConnectionState.Closed)
            {
                await ((dynamic)Connection).OpenAsync();
            }

            Transaction = Connection.BeginTransaction();
        }

        public Task CommitAsync()
        {
            Transaction.Commit();
            return Task.CompletedTask;
        }

        public Task RollbackAsync()
        {
            Transaction.Rollback();
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }
}
