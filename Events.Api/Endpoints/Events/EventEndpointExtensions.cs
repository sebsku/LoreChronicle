namespace Events.Api.Endpoints.Events;

public static class EventEndpointExtensions
{
    public static IEndpointRouteBuilder MapEventEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGetEvents();
        
        return app;
    }
}