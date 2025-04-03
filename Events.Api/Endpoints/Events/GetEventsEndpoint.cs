using Events.Application.Repositories;

namespace Events.Api.Endpoints.Events;

public static class GetEventsEndpoint
{
    public static string Name = "GetEvents";

    public static IEndpointRouteBuilder MapGetEvents(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/events", async (IEventRepository eventRepository, CancellationToken cancellationToken) =>
        {
            var events = await eventRepository.GetEventsAsync(cancellationToken);
            return TypedResults.Ok(events);
        });
        return app;
    }
}