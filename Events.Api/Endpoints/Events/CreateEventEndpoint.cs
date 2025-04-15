using Events.Api.Mapping;
using Events.Application.Repositories;
using Events.Contracts.Requests;

namespace Events.Api.Endpoints.Events;

public static class CreateEventEndpoint
{
    private const string Name = "CreateEvent";

    public static IEndpointRouteBuilder MapCreateEvent(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/events", async (
                CreateEventRequest request, IEventRepository eventRepository, CancellationToken cancellationToken) =>
            {
                var eventItem = request.MapToEvent();
                await eventRepository.CreateEventAsync(eventItem, cancellationToken);
                var response = eventItem.MapToResponse();
                return TypedResults.CreatedAtRoute(response, GetEventEndpoint.Name, new { id = eventItem.EventId });
            })
            .WithName(Name);
        return app;
    }
}