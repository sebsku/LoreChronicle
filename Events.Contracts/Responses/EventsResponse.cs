namespace Events.Contracts.Responses;

public class EventsResponse
{
    public required IEnumerable<EventResponse> Items { get; init; } = Enumerable.Empty<EventResponse>();
}