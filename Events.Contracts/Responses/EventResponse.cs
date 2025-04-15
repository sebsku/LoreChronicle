namespace Events.Contracts.Responses;

public record EventResponse
{
    public required Guid EventId { get; init; }
    public required string EventType { get; init; }
    public required DateTime Timestamp { get; init; }
    public TimeSpan? Duration { get; init; }
    public string Metadata { get; init; }
}