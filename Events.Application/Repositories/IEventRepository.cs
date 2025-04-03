using Events.Application.Models;

namespace Events.Application.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Event>> GetEventsAsync(CancellationToken cancellationToken = default);
}