using System.Data;

namespace Events.Application.Database;

public interface IDbConnectionFactory
{
    Task<IDbConnection> GetOpenConnectionAsync(CancellationToken cancellationToken = default);
}