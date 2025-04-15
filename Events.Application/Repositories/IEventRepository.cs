using Events.Application.Models;

namespace Events.Application.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetEventsAsync(CancellationToken cancellationToken = default);
    Task<Event?> GetEventAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> CreateEventAsync(Event eventItem, CancellationToken cancellationToken = default);
}