using Events.Application.Models;
using Events.Contracts.Requests;
using Events.Contracts.Responses;

namespace Events.Api.Mapping;

public static class ContractMapping
{
    public static EventResponse MapToResponse(this Event eventItem)
    {
        return new EventResponse
        {
            EventId = eventItem.EventId,
            EventType = eventItem.EventType,
            Timestamp = eventItem.Timestamp,
            Duration = eventItem.Duration,
            Metadata = eventItem.Metadata
        };
    }
    
    public static EventsResponse MapToResponse(this IEnumerable<Event> events)
    {
        return new EventsResponse
        {
            Items = events.Select(MapToResponse)
        };
    }

    public static Event MapToEvent(this CreateEventRequest request)
    {
        return new Event
        {
            EventId = Guid.NewGuid(),
            EventType = request.EventType,
            Timestamp = request.Timestamp,
            Duration = request.Duration,
            Metadata = request.Metadata
        };
    }
}