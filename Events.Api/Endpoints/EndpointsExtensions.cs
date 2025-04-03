using Events.Api.Endpoints.Events;

namespace Events.Api.Endpoints;

public static class EndpointsExtensions
{
    public static IEndpointRouteBuilder MapApiEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapEventEndpoints();
        return app;
    }
}