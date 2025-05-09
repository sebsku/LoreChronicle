using Dapper;
using Events.Application.Database;
using Events.Application.Models;

namespace Events.Application.Repositories;

public class EventRepository : IEventRepository
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public EventRepository(IDbConnectionFactory connectionFactory)
    {
        _dbConnectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<Event>> GetEventsAsync(CancellationToken cancellationToken = default)
    {
        using var connection = await _dbConnectionFactory.GetOpenConnectionAsync(cancellationToken);

        const string query =
            "SELECT event_id AS EventId, event_type AS EventType, timestamp, duration, metadata FROM events";
        return await connection.QueryAsync<Event>(query);
    }

    public async Task<Event?> GetEventAsync(Guid id, CancellationToken cancellationToken = default)
    {
        using var connection = await _dbConnectionFactory.GetOpenConnectionAsync(cancellationToken);

        const string query = "SELECT * FROM events WHERE id = @id";
        return await connection.QuerySingleOrDefaultAsync<Event>(query, new { id });
    }

    public async Task<bool> CreateEventAsync(Event eventItem, CancellationToken cancellationToken = default)
    {
        using var connection = await _dbConnectionFactory.GetOpenConnectionAsync(cancellationToken);

        const string query = """
                             INSERT INTO events (event_id, event_type, timestamp, duration, metadata)
                             VALUES (@EventId, @EventType, @Timestamp, @Duration, @Metadata)
                             """;

        var result = await connection.ExecuteAsync(new CommandDefinition(query, eventItem, cancellationToken: cancellationToken));
        
        return result > 0;
    }
}