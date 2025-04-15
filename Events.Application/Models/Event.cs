namespace Events.Application.Models;

public class Event
{
    public required Guid EventId { get; set; }
    public required string EventType { get; set; }
    public required DateTime Timestamp { get; set; }
    public TimeSpan? Duration { get; set; }
    public object Metadata { get; set; }
}