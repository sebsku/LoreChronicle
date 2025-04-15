using Events.Api.Mapping;
using Events.Application.Models;
using Events.Application.Repositories;

namespace Events.Api.Endpoints.Events;

public static class GetEventEndpoint
{
    private const string Name = "GetEvent";

    public static IEndpointRouteBuilder MapGetEvent(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/events/{{id:guid}}", async (
            Guid id, IEventRepository eventRepository, CancellationToken cancellationToken) =>
        {
            var eventItem = await eventRepository.GetEventAsync(id, cancellationToken);

            if (eventItem == null)
            {
                return Results.NotFound();
            }

            var response = eventItem.MapToResponse();
            return TypedResults.Ok(response);
        })
        .WithName(Name);
        return app;
    }
}