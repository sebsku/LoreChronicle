using Events.Api.Mapping;
using Events.Application.Repositories;

namespace Events.Api.Endpoints.Events;

public static class GetEventsEndpoint
{
    private const string Name = "GetEvents";

    public static IEndpointRouteBuilder MapGetEvents(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/events", async (
                IEventRepository eventRepository, CancellationToken cancellationToken) =>
            {
                var events = await eventRepository.GetEventsAsync(cancellationToken);
                var response = events.MapToResponse();
                return TypedResults.Ok(response);
            })
            .WithName(Name);
        return app;
    }
}