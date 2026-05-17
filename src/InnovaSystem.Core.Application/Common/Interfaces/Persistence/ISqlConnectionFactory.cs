using System.Data;

namespace InnovaSystem.Core.Application.Common.Interfaces.Persistence
{
    public interface ISqlConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
