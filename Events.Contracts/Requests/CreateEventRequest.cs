namespace Events.Contracts.Requests;

public class CreateEventRequest
{
    public required string EventType { get; init; }
    public required DateTime Timestamp { get; init; }
    public TimeSpan? Duration { get; init; }
    public object Metadata { get; init; }
}