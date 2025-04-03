namespace Events.Application.Models;

public class Event
{
    public Guid EventId { get; set; }
    public string EventType { get; set; }
    public DateTime Timestamp { get; set; }
    public TimeSpan? Duration { get; set; }
    public string Metadata { get; set; }
}